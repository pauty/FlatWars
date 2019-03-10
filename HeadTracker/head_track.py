#!/usr/bin/python

import cv2
import sys
from pynput import keyboard, mouse
import threading
import tkinter as tk

FIRST_WEBCAM = 0

class HeadTracker:
    #static tracking ids
    BOOSTING_TRACKER_ID = 0
    MIL_TRACKER_ID = 1
    KCF_TRACKER_ID = 2
    TLD_TRACKER_ID = 3
    MEDIANFLOW_TRACKER_ID = 4
    GOTURN_TRACKER_ID = 5
    MOSSE_TRACKER_ID = 6
    CSRT_TRACKER_ID = 7

    #webcam thread class
    class WebcamReadThread(threading.Thread):
        def __init__(self, videosource):
            threading.Thread.__init__(self)
            self.video = cv2.VideoCapture(videosource)
            self.init_ok = True
            if(not self.video.isOpened()):
                print("!!! - Cannot open webcam!")
                self.init_ok = False 
            self.must_stop = False
            self.frame = None
            
        def run(self):
            while(not self.must_stop):
                #Retrieve the latest image from the webcam
                rc, self.frame = self.video.read()
                #Resize the image to 320x240
                #frame = cv2.resize(fullSizeFrame, (video_width, video_height))
            self.video.release()
                
        def stop(self):
            self.must_stop = True
    
    #keyboard listener callback functions     
    def on_press(self, key):
        if(key == keyboard.KeyCode(char='r')):
            self.tracking_ok = False
            print("Reset head tracking")
        elif(key == keyboard.KeyCode(char='m')):
            self.controlling_mouse = not self.controlling_mouse
            print("Controlling mouse: ", self.controlling_mouse)
        
    def on_release(self, key):
        pass
       
    #head tracker functions
    def __init__(self, videosource=0, trackerid=6, showvideo=False):
        self.tracking_ok = False
        self.controlling_mouse = False  
        #Init pynput listeners
        self.mouse_controller = mouse.Controller()
        self.keyboard_listener = keyboard.Listener(on_press = self.on_press, on_release = self.on_release)
        self.keyboard_listener.start() 
        #Init face detector
        self.face_cascade_detector = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')  
        #Choose tracker
        self.tracker_id = trackerid
        
        self.init_ok = True
        self.webcam_thread = self.WebcamReadThread(videosource)
        self.init_ok = self.webcam_thread.init_ok
    
        root = tk.Tk()       
        self.screen_width = root.winfo_screenwidth()
        self.screen_height = root.winfo_screenheight()
        
        self.show_video = False
        if(showvideo):
            self.show_video = True
            #Create a opencv named window
            self.window_name = "Webcam-Track"
            cv2.namedWindow(self.window_name, cv2.WINDOW_AUTOSIZE)
            #Position the window
            #cv2.moveWindow("result-image",400,100)
            #Start the window thread for the windows we are using
            cv2.startWindowThread()  
            #Define rectangle colors
            self.track_rect_color = (255, 0, 0)
            self.detect_rect_color = (0, 165, 255)
   
    def get_new_tracker(self):            
        if self.tracker_id == HeadTracker.BOOSTING_TRACKER_ID:
            tracker = cv2.TrackerBoosting_create()
        elif self.tracker_id == HeadTracker.MIL_TRACKER_ID:
            tracker = cv2.TrackerMIL_create()
        elif self.tracker_id == HeadTracker.KCF_TRACKER_ID:
            tracker = cv2.TrackerKCF_create()
        elif self.tracker_id == HeadTracker.TLD_TRACKER_ID:
            tracker = cv2.TrackerTLD_create()
        elif self.tracker_id == HeadTracker.MEDIANFLOW_TRACKER_ID:
            tracker = cv2.TrackerMedianFlow_create()
        elif self.tracker_id == HeadTracker.GOTURN_TRACKER_ID:
            tracker = cv2.TrackerGOTURN_create()
        elif self.tracker_id == HeadTracker.MOSSE_TRACKER_ID:
            tracker = cv2.TrackerMOSSE_create()
        elif self.tracker_id == HeadTracker.CSRT_TRACKER_ID:
            tracker = cv2.TrackerCSRT_create()
        
        return tracker
           
    def head_track_loop(self):
        if(not self.init_ok):
            print("!!! - Tracker initialization failed!")
            return
            
        self.webcam_thread.start()
        
        while(self.webcam_thread.frame is None):
            pass
            
        video_height, video_width, nchannels = self.webcam_thread.frame.shape
        
        print("Tracking started.")
        
        try:
            while True:    
                #Get most recent frame polled by webcam thread       
                current_frame = self.webcam_thread.frame
                
                #Reset bounding box
                max_area = 0
                x = 0
                y = 0
                w = 0
                h = 0
                
                if(self.tracking_ok):
                    #Update tracker
                    self.tracking_ok, bbox = tracker.update(current_frame)
                    x = int(bbox[0])
                    y = int(bbox[1])
                    w = int(bbox[2])
                    h = int(bbox[3])
                    max_area = w*h
             
                    if(self.show_video and self.tracking_ok):
                        #Draw tracking bounding box on frame
                        p1 = (x, y)
                        p2 = (x+w, y+h)
                        cv2.rectangle(current_frame, p1, p2, self.track_rect_color, 2) 
                
                if(not self.tracking_ok):
                    #For the face detection, we need to make use of a gray colored
                    #image so we will convert the baseImage to a gray-based image
                    gray = cv2.cvtColor(current_frame, cv2.COLOR_BGR2GRAY)
                    #Now use the haar cascade detector to find all faces in the image
                    faces = self.face_cascade_detector.detectMultiScale(gray, 1.3, 5)


                    #For now, we are only interested in the 'largest' face, and we
                    #determine this based on the largest area of the found
                    #rectangle.

                    #Loop over all faces and check if the area for this face is
                    #the largest so far
                    for (_x,_y,_w,_h) in faces:
                        if(_w*_h > max_area):
                            x = _x
                            y = _y
                            w = _w
                            h = _h
                            max_area = w*h

                    #If one or more faces are found, draw a rectangle around the
                    #largest face present in the picture
                    if(max_area > 0):
                        tracker = self.get_new_tracker()
                        self.tracking_ok = tracker.init(current_frame, (x,y,w,h))
                        if(self.show_video):
                            cv2.rectangle(current_frame, (x, y), (x+w, y+h), self.detect_rect_color, 2)
                           
                if(self.controlling_mouse):
                    # Set pointer position
                    x_center = int(((x+w/2)/video_width)*(self.screen_width))
                    y_center = int(((y+h/2)/video_height)*(self.screen_height))
                    self.mouse_controller.position = (x_center, y_center)
                
                if(self.show_video):
                    #Finally, we want to show the image on the screen
                    cv2.imshow(self.window_name, current_frame)             
                    #Check if a key was pressed and if it was Q, then destroy all
                    #opencv windows and exit tracking loop
                    #IMPORTANT: waitKey is necessary to display the image after calling imshow!!!!!
                    pressed_key = cv2.waitKey(1)
                    if(pressed_key == ord('q')):
                        self.keyboard_listener.stop()
                        self.webcam_thread.stop()
                        self.webcam_thread.join()
                        cv2.destroyAllWindows()
                        return 

        #To ensure we can also deal with the user pressing Ctrl-C in the console
        #we have to check for the KeyboardInterrupt exception and destroy
        #all opencv windows (if any) and exit the tracking loop
        except KeyboardInterrupt as e:
            self.keyboard_listener.stop()
            self.webcam_thread.stop()
            self.webcam_thread.join()
            if(self.show_video):
                cv2.destroyAllWindows()
            return 
    
if __name__ == '__main__':
    show_gui = "-gui" in sys.argv
    head_tracker = HeadTracker(FIRST_WEBCAM, HeadTracker.MOSSE_TRACKER_ID, show_gui)
    head_tracker.head_track_loop()
    
    

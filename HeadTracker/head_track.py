#!/usr/bin/python

import cv2
from pynput import keyboard, mouse
import threading
import tkinter as tk

FIRST_WEBCAM = 0

BOOSTING_IDX = 0
MIL_IDX = 1
KCF_IDX = 2
TLD_IDX = 3
MEDIANFLOW_IDX = 4
GOTURN_IDX = 5
MOSSE_IDX = 6
CSR_IDX = 7

class HeadTracker:

    #webcam thread class
    class webcamPollThread(threading.Thread):
        def __init__(self, videosource):
            threading.Thread.__init__(self)
            self.video = cv2.VideoCapture(videosource)
            self.initOk = True
            if(not self.video.isOpened()):
                print("Cannot open webcam")
                self.initOk = False 
            self.mustStop = False
            self.frame = None
            
        def run(self):
            while(not self.mustStop):
                #Retrieve the latest image from the webcam
                rc, self.frame = self.video.read()
                #Resize the image to 320x240
                #frame = cv2.resize(fullSizeFrame, (video_width, video_height))
            self.video.release()
                
        def stop(self):
            self.mustStop = True
    
    #keyboard listener callback functions     
    def on_press(self, key):
        if(key == keyboard.KeyCode(char='r')):
            self.trackingOk = False
            print("reset head tracking")
        elif(key == keyboard.KeyCode(char='m')):
            self.controllingMouse = not self.controllingMouse
            print("controlling mouse: ", self.controllingMouse)
        
    def on_release(self, key):
        pass
       
    #head tracker functions
    def __init__(self, videosource=0, trackeridx=6, showvideo=False):
        self.trackingOk = False
        self.controllingMouse = False  
        #Init pynput listeners
        self.mouseController = mouse.Controller()
        self.keyboardListener = keyboard.Listener(on_press = self.on_press, on_release = self.on_release)
        self.keyboardListener.start() 
        #Init face detector
        self.faceCascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')  
        #Choose tracker
        self.tracker_types = ['BOOSTING', 'MIL','KCF', 'TLD', 'MEDIANFLOW', 'GOTURN', 'MOSSE', 'CSRT']
        self.trackerIdx = trackeridx
        
        self.initOk = True
        self.webcamThread = self.webcamPollThread(videosource)
        self. initOk = self.webcamThread.initOk
    
        root = tk.Tk()       
        self.screen_width = root.winfo_screenwidth()
        self.screen_height = root.winfo_screenheight()
        
        self.showVideo = False
        if(showvideo):
            self.showVideo = True
            #Create a opencv named window
            self.windowName = "Webcam-Track"
            cv2.namedWindow(self.windowName, cv2.WINDOW_AUTOSIZE)
            #Position the window
            #cv2.moveWindow("result-image",400,100)
            #Start the window thread for the windows we are using
            cv2.startWindowThread()  
            #Define rectangle colors
            self.trackRectColor = (255, 0, 0)
            self.detectRectColor = (0, 165, 255)
   
    def getNewTracker(self):   
        tracker_type = self.tracker_types[self.trackerIdx]
          
        if tracker_type == 'BOOSTING':
            tracker = cv2.TrackerBoosting_create()
        elif tracker_type == 'MIL':
            tracker = cv2.TrackerMIL_create()
        elif tracker_type == 'KCF':
            tracker = cv2.TrackerKCF_create()
        elif tracker_type == 'TLD':
            tracker = cv2.TrackerTLD_create()
        elif tracker_type == 'MEDIANFLOW':
            tracker = cv2.TrackerMedianFlow_create()
        elif tracker_type == 'GOTURN':
            tracker = cv2.TrackerGOTURN_create()
        elif tracker_type == 'MOSSE':
            tracker = cv2.TrackerMOSSE_create()
        elif tracker_type == "CSRT":
            tracker = cv2.TrackerCSRT_create()
        
        return tracker
           
    def headTrackLoop(self):
        if(not self.initOk):
            print("initialization failed!")
            return
            
        self.webcamThread.start()
        
        while(self.webcamThread.frame is None):
            pass
            
        video_height, video_width, nchannels = self.webcamThread.frame.shape
        
        try:
            while True:    
                #Get most recent frame polled by webcam thread       
                currentFrame = self.webcamThread.frame
                
                #reset bounding box
                maxArea = 0
                x = 0
                y = 0
                w = 0
                h = 0
                
                if(self.trackingOk):
                    # Update tracker
                    self.trackingOk, bbox = tracker.update(currentFrame)
                    x = int(bbox[0])
                    y = int(bbox[1])
                    w = int(bbox[2])
                    h = int(bbox[3])
                    maxArea = w*h
             
                    if(self.showVideo and self.trackingOk):
                        # Draw tracking bounding box on frame
                        p1 = (x, y)
                        p2 = (x+w, y+h)
                        cv2.rectangle(currentFrame, p1, p2, self.trackRectColor, 2) 
                
                if(not self.trackingOk):
                    #For the face detection, we need to make use of a gray colored
                    #image so we will convert the baseImage to a gray-based image
                    gray = cv2.cvtColor(currentFrame, cv2.COLOR_BGR2GRAY)
                    #Now use the haar cascade detector to find all faces in the image
                    faces = self.faceCascade.detectMultiScale(gray, 1.3, 5)


                    #For now, we are only interested in the 'largest' face, and we
                    #determine this based on the largest area of the found
                    #rectangle. First initialize the required variables to 0

                    #Loop over all faces and check if the area for this face is
                    #the largest so far
                    for (_x,_y,_w,_h) in faces:
                        if(_w*_h > maxArea):
                            x = _x
                            y = _y
                            w = _w
                            h = _h
                            maxArea = w*h

                    #If one or more faces are found, draw a rectangle around the
                    #largest face present in the picture
                    if(maxArea > 0):
                        tracker = self.getNewTracker()
                        self.trackingOk = tracker.init(currentFrame, (x,y,w,h))
                        if(self.showVideo):
                            cv2.rectangle(currentFrame, (x, y), (x+w, y+h), self.detectRectColor, 2)
                           
                if(self.controllingMouse):
                    # Set pointer position
                    xCenter = int(((x+w/2)/video_width)*(self.screen_width))
                    yCenter = int(((y+h/2)/video_height)*(self.screen_height))
                    self.mouseController.position = (xCenter, yCenter)
                
                if(self.showVideo):
                    #Finally, we want to show the image on the screen
                    cv2.imshow(self.windowName, currentFrame)             
                    #Check if a key was pressed and if it was Q, then destroy all
                    #opencv windows and exit tracking loop
                    #IMPORTANT: waitKey is necessary to display the image after calling imshow!!!!!
                    pressedKey = cv2.waitKey(1)
                    if(pressedKey == ord('q')):
                        self.webcamThread.stop()
                        self.webcamThread.join()
                        self.keyboardListener.stop()
                        cv2.destroyAllWindows()
                        return 

        #To ensure we can also deal with the user pressing Ctrl-C in the console
        #we have to check for the KeyboardInterrupt exception and destroy
        #all opencv windows (if any) and exit the tracking loop
        except KeyboardInterrupt as e:
            self.webcamThread.stop()
            self.webcamThread.join()
            self.keyboardListener.stop()
            if(self.showVideo):
                cv2.destroyAllWindows()
            return 
    
if __name__ == '__main__':
    headTracker = HeadTracker(0, MOSSE_IDX, True)
    headTracker.headTrackLoop()
    
    

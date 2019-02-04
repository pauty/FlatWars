#!/usr/bin/python

#Import the OpenCV library
import cv2
from pynput.mouse import Button, Controller
from pynput import keyboard
import tkinter as tk


#Initialize a face cascade using the frontal face haar cascade provided with
#the OpenCV library

   
trackingOk = False
controllingMouse = False

def on_press(key):
    global trackingOk, controllingMouse
    print("pressed")
    if(key == keyboard.KeyCode(char='r')):
        trackingOk = False
    elif(key == keyboard.KeyCode(char='m')):
        print("here")
        controllingMouse = not controllingMouse
        

def on_release(key):
    pass


def detectLargestFace():
    global trackingOk, controllingMousemm


    # Collect events until released
    listener = keyboard.Listener(on_press = on_press, on_release = on_release)
    listener.start()  
    
    faceCascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')
    #Open the first webcame device
    capture = cv2.VideoCapture(0)
    if(not capture.isOpened()):
        print("Cannot open webcam")
        exit(0)
            
    #Create two opencv named windows
    #cv2.namedWindow("base-image", cv2.WINDOW_AUTOSIZE)
    cv2.namedWindow("result-image", cv2.WINDOW_AUTOSIZE)

    #Position the windows next to eachother
    #cv2.moveWindow("base-image",0,100)
    #cv2.moveWindow("result-image",400,100)

    #Start the window thread for the two windows we are using
    cv2.startWindowThread()

    rectangleColor = (0,165,255)
    
    # Set up tracker.
    # Instead of MIL, you can also use
    tracker_types = ['BOOSTING', 'MIL','KCF', 'TLD', 'MEDIANFLOW', 'GOTURN', 'MOSSE', 'CSRT']
    tracker_type = tracker_types[6]
 
 
    if tracker_type == 'BOOSTING':
        tracker = cv2.TrackerBoosting_create()
    if tracker_type == 'MIL':
        tracker = cv2.TrackerMIL_create()
    if tracker_type == 'KCF':
        tracker = cv2.TrackerKCF_create()
    if tracker_type == 'TLD':
        tracker = cv2.TrackerTLD_create()
    if tracker_type == 'MEDIANFLOW':
        tracker = cv2.TrackerMedianFlow_create()
    if tracker_type == 'GOTURN':
        tracker = cv2.TrackerGOTURN_create()
    if tracker_type == 'MOSSE':
        tracker = cv2.TrackerMOSSE_create()
    if tracker_type == "CSRT":
        tracker = cv2.TrackerCSRT_create()
    
    mouse = Controller()
    
    root = tk.Tk()

    screen_width = root.winfo_screenwidth()
    screen_height = root.winfo_screenheight()
    
    rc, fullSizeFrame = capture.read()
    video_height, video_width, nchannels = fullSizeFrame.shape
    video_width = int(video_width/2)
    video_height = int(video_height/2)
    

    #while(True):
    #    # Read pointer position
    #    print('The current pointer position is {0}'.format(mouse.position))


    # Move pointer relative to current position
    #mouse.move(5, -5)
       

    try:
        while True:
            #Retrieve the latest image from the webcam
            rc, fullSizeFrame = capture.read()
            #Resize the image to 320x240
            frame = cv2.resize(fullSizeFrame, (video_width, video_height))
            
            maxArea = 0
            x = 0
            y = 0
            w = 0
            h = 0
        
            if(trackingOk):
                # Update tracker
                trackingOk, bbox = tracker.update(frame)
                x = int(bbox[0])
                y = int(bbox[1])
                w = int(bbox[2])
                h = int(bbox[3])
                maxArea = w*h
         
                # Draw bounding box
                if(trackingOk):
                    # Tracking success
                    p1 = (x, y)
                    p2 = (x+w, y+h)
                    cv2.rectangle(frame, p1, p2, (255,0,0), 2)
            
            if(not trackingOk):
                #For the face detection, we need to make use of a gray colored
                #image so we will convert the baseImage to a gray-based image
                gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
                #Now use the haar cascade detector to find all faces in the
                #image
                faces = faceCascade.detectMultiScale(gray, 1.3, 5)


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
                    tracker = cv2.TrackerMOSSE_create()
                    trackingOk = tracker.init(frame, (x,y,w,h))
                    cv2.rectangle(frame, (x, y), (x+w, y+h), rectangleColor, 2)

                    
                        
            if(controllingMouse):
                # Set pointer position
                xCenter = int(((x+w/2)/video_width)*(screen_width))
                yCenter = int(((y+h/2)/video_height)*(screen_height))
                mouse.position = (xCenter, yCenter)
            
            #Finally, we want to show the images on the screen
            #cv2.imshow("base-image", baseImage)
            cv2.imshow("result-image", frame)
            
            #Check if a key was pressed and if it was Q, then destroy all
            #opencv windows and exit the application
            #IMPORTANT: waitKey is necessary to display the image after calling imshow!!!!!
            pressedKey = cv2.waitKey(2)
            if(pressedKey == ord('q')):
                listener.stop()
                cv2.destroyAllWindows()
                capture.release()
                exit(0)
            #elif(pressedKey == ord('r')):
            #    trackingOk = False
            #elif(pressedKey == ord('m')):
            #    controllingMouse = not controllingMouse
            #    print("mouse control: ", controllingMouse)m

    #To ensure we can also deal with the user pressing Ctrl-C in the console
    #we have to check for the KeyboardInterrupt exception and destroy
    #all opencv windows and exit the application
    except KeyboardInterrupt as e:
        cv2.destroyAllWindows()
        capture.release()
        exit(0)


if __name__ == '__main__':
    trackingOk = False
    controllingMouse = False
    detectLargestFace()

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class ObliqueProjection: MonoBehaviour {

    public PrismaBuilder tunnel = null;
    public float maxW = 1F;
    public float maxH = 1F;
    Vector3 origin;
    Camera cam;
    Vector3 prevMousePosition;
    GameObject player = null;
    bool followingPlayer = false;
    
    void Start(){
        origin = transform.localPosition;
        cam = gameObject.GetComponent<Camera>();
        if(tunnel != null){
            maxW = (tunnel.widthSteps*tunnel.sectorWidth)/2;
            maxH = (tunnel.heightSteps*tunnel.sectorHeight)/2;
        }
        player = GameObject.FindWithTag("Player");
    }
    
    void Update(){
        if(Input.GetKeyDown("f")){
            followingPlayer = !followingPlayer;
        }
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = (mousePosition + prevMousePosition)/2;
        prevMousePosition = mousePosition;
        
        float xc, yc;
        if(player != null && followingPlayer){
            xc = -player.transform.localPosition.x/maxW;
            yc = player.transform.localPosition.y/maxH;
        }
        else{
            xc = (2*mousePosition.x-Screen.width)/(Screen.width);
            yc = (2*mousePosition.y-Screen.height)/(Screen.height);    
            xc = Mathf.Min(1F, Mathf.Max(-1F, xc));
            yc = Mathf.Min(1F, Mathf.Max(-1F, yc));
        }
        
        Vector3 cameraLocalPosition = cam.transform.localPosition;
        cameraLocalPosition.x = origin.x - xc*maxW;
        cameraLocalPosition.y = origin.y + yc*maxH;
        cam.transform.localPosition = cameraLocalPosition;
        SetObliqueness(xc, -yc);
    }
    
    void SetObliqueness(float horizObl, float vertObl) {
        Matrix4x4 mat  = cam.projectionMatrix;
        mat[0, 2] = horizObl;
        mat[1, 2] = vertObl;
        cam.projectionMatrix = mat;
    }
   
}


// Set an off-center projection, where perspective's vanishing
// point is not necessarily in the center of the screen.
//
// left/right/top/bottom define near plane size, i.e.
// how offset are corners of cam's near plane.
// Tweak the values and you can see cam's frustum change.

/*
//[ExecuteInEditMode]
public class ObliqueProjection : MonoBehaviour
{
    
    public float left = -0.2F;
    public float right = 0.2F;
    public float top = 0.2F;
    public float bottom = -0.2F;
    float near;
    float far;
    Vector3 mousePosition;
    float xhead;
    float yhead;
    float zhead;
    
    void Update()
    {   
        Camera cam = Camera.main;
        mousePosition = Input.mousePosition;
        xhead = (2*mousePosition.x-Screen.width)/(Screen.width)/2;
        yhead = (2*mousePosition.y-Screen.height)/(Screen.height)/2;
        zhead = -1;
        Debug.Log(xhead);
        near = cam.nearClipPlane;
        far = cam.farClipPlane;
        left = (-0.5F*(16/9)+xhead)*near/-zhead;
        right = (0.5F*(16/9)+xhead)*near/-zhead;
        top = (0.5F*+yhead)*near/-zhead;
        bottom = (-0.5F*+yhead)*near/-zhead;
        Matrix4x4 m = PerspectiveOffCenter(left, right, bottom, top, near, far);
        cam.projectionMatrix = m;
    }

    static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
    {
        float x = 2.0F * near / (right - left);
        float y = 2.0F * near / (top - bottom);
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x;
        m[0, 1] = 0;
        m[0, 2] = a;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = y;
        m[1, 2] = b;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = c;
        m[2, 3] = d;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = e;
        m[3, 3] = 0;
        return m;
    }
}
*/

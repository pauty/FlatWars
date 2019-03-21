using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hide");
       //Set Cursor to not be visible
        Cursor.visible = false; 
    }

}

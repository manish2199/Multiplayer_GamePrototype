using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookHandler1 : MonoBehaviour , IMouseLook
{
    [SerializeField] Transform PlayerRoot;
    
    [SerializeField] float MouseSensitivity;

    private Vector2 CurrentMouseLook;

    private Vector2 MouseLookAngles;

    [SerializeField] Vector2 MouseLookLimits;


    public void HandleMouseLookMotion()
    { 
       CurrentMouseLook = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));

       MouseLookAngles.x += CurrentMouseLook.x * MouseSensitivity ;
       MouseLookAngles.y += CurrentMouseLook.y * MouseSensitivity * -1f ;
     
       MouseLookAngles.y = Mathf.Clamp(MouseLookAngles.y ,MouseLookLimits.x,MouseLookLimits.y);

       PlayerRoot.localRotation = Quaternion.Euler(MouseLookAngles.y,MouseLookAngles.x,0);
    
    }
}

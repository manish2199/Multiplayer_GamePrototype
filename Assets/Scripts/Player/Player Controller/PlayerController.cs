using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{ 
    private IMovement MovementHandler;
    
    private IJump JumpHandler;

    private IMouseLook MouseLookHandler;
    
    PhotonView photonView;

    void Awake()
    {
        MovementHandler = GetComponent<IMovement>();
        JumpHandler = GetComponent<IJump>();
        MouseLookHandler = GetComponent<IMouseLook>();
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        LockCursor();
    }


    void Update()
    {
        if(photonView.IsMine)
        {
          // handle movement 
          MovementHandler.HandleMovement();

          // handle jump 
          JumpHandler.HandleJump();

          // handle mouse rotation
          MouseLookHandler.HandleMouseLookMotion();    
        }
    }
  
    void LockCursor()
    {
        if(Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}




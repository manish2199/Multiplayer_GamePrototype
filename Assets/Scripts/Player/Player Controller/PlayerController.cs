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

    private bool CanJummp;

    void Awake()
    {
        CanJummp = false;
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
          CanJummp = JumpHandler.HandleJumpInput();

          // handle mouse rotation
          MouseLookHandler.HandleMouseLookMotion();    
        }
    }

    void FixedUpdate()
    {
         // jump 
        if(CanJummp)
        {
          JumpHandler.Jump();
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




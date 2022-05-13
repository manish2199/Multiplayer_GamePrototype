using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump1 : MonoBehaviour , IJump 
{
    
    [SerializeField] Rigidbody PlayerRigidBody;

    [SerializeField] float JumpForce;

    [SerializeField] LayerMask PlatformLayer;
    
    
    public void HandleJump()
    {
       // handle Jump 
       RaycastHit hit;
       bool isGrounded = Physics.Raycast(transform.position,Vector3.down,1f,PlatformLayer);
       
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
       {
           PlayerRigidBody.AddForce(0 , JumpForce  , 0 );
       }
    }
   
}

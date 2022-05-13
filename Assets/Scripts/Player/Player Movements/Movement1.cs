using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour , IMovement
{
    [SerializeField] private float Speed;

    public void HandleMovement()
    {
        float XInputValue = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float YInputValue = Input.GetAxis("Vertical")* Speed * Time.deltaTime;
        
        transform.position += transform.forward * YInputValue;
        transform.position += transform.right * XInputValue;
    }
}

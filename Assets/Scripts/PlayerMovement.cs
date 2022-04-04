using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    
    void Update()
    {
     
        if (InputController.Instance.IsMovingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        if (InputController.Instance.IsMovingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        if (InputController.Instance.IsMovingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        
        if (InputController.Instance.IsMovingDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
    }

    public void SetMovement(Vector3 vector3)
    {
        transform.position = vector3;
    }

    public Vector3 GetMovement()
    {
        return transform.position;
    }
}

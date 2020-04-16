using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviourPun
{

    [SerializeField]
    private Camera cam;
    
    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 Vertrotation;

    private void Start()
    {
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    
    public void RotateVert(Vector3 _Vertrotation)
    {
        Vertrotation = _Vertrotation;
    }

    private void FixedUpdate()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        
        PerformMovement(rb);
        PerformRotation(rb);
    }

    private void PerformMovement(Rigidbody rb)
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation(Rigidbody rb)
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-Vertrotation);
    }
    

}


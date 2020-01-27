using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
        public float sensitivity = 15;
        public float highjump = 2;
    
        private PlayerMotor motor;
    
        private void Start()
        {
            motor = GetComponent<PlayerMotor>();
        }
    
        private void Update()
        {
            // Mouvement du joueur 
            
            float xMov = Input.GetAxisRaw("Horizontal");
            float zMov = Input.GetAxisRaw("Vertical");
    
            Vector3 moveHorizontal = transform.right * xMov;
            Vector3 moveVertical = transform.forward * zMov;
    
            Vector3 _velocity = (moveHorizontal + moveVertical).normalized * speed;
    
            motor.Move(_velocity);
            
            //Caméra du joueur : Droite gauche
    
            float yRot = Input.GetAxisRaw("Mouse X");
    
            Vector3 _rotation = new Vector3(0, yRot, 0) * sensitivity;
    
            motor.Rotate(_rotation);
            
            //Caméra du joueur : Haut - Bas
    
            float xRot = Input.GetAxisRaw("Mouse Y");
    
            Vector3 _Vertrotation = new Vector3(xRot, 0, 0) * sensitivity;
    
            motor.RotateVert(_Vertrotation);
            
            //Saut du joueur 
    
            Vector3 _jumped = new Vector3(0, 1, 0) * highjump;
    
            motor.Gohigh(_jumped);
            
        }
}

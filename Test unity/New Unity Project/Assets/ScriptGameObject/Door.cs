using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    private bool beingCarried = false;
    private bool touched = false;
    private Text Txtmessage;
    private Animator Anim;
    private bool hasPlayer;

    private void Start()
    {
        Txtmessage = GameObject.Find("NewText").GetComponent<Text>();
        Anim = GameObject.Find("Door").GetComponent<Animator>();
        hasPlayer = false;
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 4f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer)
        {
            Txtmessage.text = "This is a cube";
        }
        else
        {
            Txtmessage.text = "";
        }
    
        // si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            Anim.SetBool("Open",true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    public List<GameObject> GameObjects = new List<GameObject>();
    public List<Camera> Cameras = new List<Camera>();
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
            CreatePlayer();
        else
        {
            CreatePlayerMaster();
        }
    }

    private void CreatePlayerMaster()
    {
        Vector3 vector3 = new Vector3(-1, 0, -1);
        Debug.Log("Creating Player Master");
        var test = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "EPITA"), vector3, Quaternion.identity);

        GameObjects.Add(test);
        Camera cam = test.GetComponentInChildren<Camera>();
        Cameras.Add(cam);
        cam.name = "CameraMaster";
    }

    private void CreatePlayer()
    {
        Vector3 vector3 = new Vector3(-1, 0, -6);
        Debug.Log("Creating Player");
        var test = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "EPITA"), vector3, Quaternion.identity);
        GameObjects.Add(test);
        Camera cam = test.GetComponentInChildren<Camera>();
        Cameras.Add(cam);
        cam.name = "CameraOther";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

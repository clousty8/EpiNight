using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetupController : MonoBehaviour
{
    private DateTime time;
    private DateTime start = DateTime.Now;
    private string minutes;
    private string seconds;
    public List<GameObject> GameObjects = new List<GameObject>();
    public List<Camera> Cameras = new List<Camera>();

    [SerializeField] Text Text;
    [SerializeField] Text Loose;
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
        /*Vector3 vector3 = new Vector3(0, 0, 0);
        Debug.Log("Creating Player Master");
        var test = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Truc bidule"), vector3, Quaternion.identity);

        GameObjects.Add(test);
        Camera cam = test.GetComponentInChildren<Camera>();
        Cameras.Add(cam);
        cam.name = "CameraMaster";*/
        Vector3 vector3 = new Vector3(-1828, 1, -386);
        Debug.Log("Creating Player Master");
        var test = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "EPITA 1"), vector3, Quaternion.identity);

        GameObjects.Add(test);
        Camera cam = test.GetComponentInChildren<Camera>();
        Cameras.Add(cam);
        cam.name = "CameraMaster";
    }

    private void CreatePlayer()
    {
        Vector3 vector3 = new Vector3(-1828, 1, -392);
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
        time = DateTime.Now;
        minutes = "" + ((start - time).Minutes + 59);
        seconds = "" + (59 - (time - start).Seconds);
        if (minutes == "0" && seconds == "0")
        {
            Loose.text = "YOU LOOSE...";
            Text.enabled = false;
            return;
        }

        if (Loose.text == "YOU LOOSE..." && seconds == "55")
            SceneManager.LoadSceneAsync(0);
        if (minutes.Length == 1)
            minutes = "0" + minutes;
        if (seconds.Length == 1)
            seconds = "0" + seconds;
        Text.text = minutes + " : " + seconds;
    }
}

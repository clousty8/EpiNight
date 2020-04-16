using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
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
        Vector3 vector3 = new Vector3(-1829, 140, -186);
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "EPITAMaster"), vector3, Quaternion.identity);
    }

    private void CreatePlayer()
    {
        Vector3 vector3 = new Vector3(-1829, 140, -96);
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "EPITA"), vector3, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

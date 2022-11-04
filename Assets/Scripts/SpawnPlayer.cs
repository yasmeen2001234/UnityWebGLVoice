using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{

    public static string playerName;

    public GameObject playerPrefabFemale;



    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;


    private void Start()
    {


        Vector3 randomPosition = new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1));


        PhotonNetwork.Instantiate(playerPrefabFemale.name, randomPosition, Quaternion.Euler(new Vector3(0, 0, 0)));




    }

}






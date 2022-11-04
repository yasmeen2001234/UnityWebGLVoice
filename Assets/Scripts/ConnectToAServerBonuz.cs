using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using System.Linq;

public class ConnectToAServerBonuz : MonoBehaviourPunCallbacks
{

    public GameObject Spawn;
    public GameObject loadingScreen;


    // call back function , is a fucntion that is called automatcially when an event is happened
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
       
    }

    // when we succesfully connected to the server 
    public override void OnConnectedToMaster() // when we succesfully connected to the server 
    {
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        CreateOrJoinRoom();

     
    }
    public override void OnJoinedRoom()
    {
        print("I joined");
        Spawn.SetActive(true);
        loadingScreen.SetActive(false);
    }

        public void CreateOrJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom("Game", roomOptions, TypedLobby.Default);
    }
}

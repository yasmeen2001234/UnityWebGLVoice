using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    [Header("Input Fields")]
    public TMP_InputField joinInputField;
    public TMP_InputField createInputField;
    public TMP_InputField nameInputField;

    [Header("Panels")]
    public GameObject intro;
    public GameObject join;
    public GameObject game;

    [Header("Components")]
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Use a Button to Call this Function
    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
    }

    //Use a Button to Call this Function
    public void CreateRoom()
    {
        string roomName = createInputField.text;
        if (string.IsNullOrEmpty(roomName))
        {
            roomName = Random.Range(0, 9999999999999999999).ToString();
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    //Use a Button to Call this Function
    public void JoinRandomly()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    //Use a Button to Call this Function
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void Join()
    {
        string roomName = joinInputField.text;
        if (string.IsNullOrEmpty(roomName))
        {
            JoinRandomly();
        }
        else
        {
            PhotonNetwork.JoinRoom(roomName);
        }

    }

    public override void OnConnectedToMaster()
    {
        string playerNickname = nameInputField.text;
        if (string.IsNullOrEmpty(playerNickname))
        {
            playerNickname = Random.Range(0, 9999999999999999999).ToString();
        }
        PhotonNetwork.LocalPlayer.NickName = playerNickname;
        PhotonNetwork.JoinLobby();

        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        intro.SetActive(false);
        join.SetActive(true);

        base.OnJoinedLobby();
    }

    public override void OnJoinedRoom()
    {
        join.SetActive(false);
        game.SetActive(true);

        mainCamera.enabled = false;

        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);

        base.OnJoinedRoom();
    }

    public override void OnLeftRoom()
    {
        mainCamera.enabled = true;

        join.SetActive(true);
        game.SetActive(false);

        base.OnLeftRoom();
    }
}
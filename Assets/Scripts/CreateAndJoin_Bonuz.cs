using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Chat;
public class CreateAndJoin_Bonuz : MonoBehaviourPunCallbacks  
{
    public InputField createInput;
    public InputField joinInput;
 



    public void CreateRoom()
    {

        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {

        PhotonNetwork.JoinRoom(joinInput.text);
       
    }


    public override void OnJoinedRoom()
    {
      
        PhotonNetwork.LoadLevel("Scene_net");
      //  VoiceChatManager.rtcEngine.JoinChannel(PhotonNetwork.CurrentRoom.Name);
        //roomName.text = PhotonNetwork.CurrentRoom.Name;

    }

}

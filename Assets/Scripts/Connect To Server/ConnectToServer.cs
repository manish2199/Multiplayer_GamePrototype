﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField userNameInput;
    public Text buttonText;

    public void OnClickConnect()
    {
        if(userNameInput.text.Length >= 1)
       {
           PhotonNetwork.NickName = userNameInput.text;
           buttonText.text = "Connecting...";
           PhotonNetwork.AutomaticallySyncScene = true;
           PhotonNetwork.ConnectUsingSettings();
       }
    }

    public override void OnConnectedToMaster()
    {
      SceneManager.LoadScene("Lobby");
    }
 
}

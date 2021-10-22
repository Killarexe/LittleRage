using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManger : MonoBehaviourPunCallbacks
{

    public int playerCount;
    void Start()
    {
        Debug.Log("Connecting To The Server...");
        PhotonNetwork.GameVersion = "0.1.7a";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Sever");
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected To Server\nCause: " + cause.ToString());
    }

    public void OnJoinedLevel()
    {
        PhotonNetwork.Instantiate("Player", new Vector2(Random.Range(-10f, 10f), 0f), Quaternion.identity);
        //PhotonNetwork.Instantiate("Main Camera", new Vector2(0f, 0f), Quaternion.identity);
        playerCount++;
        new WaitForSeconds(5.0f);
    }
}

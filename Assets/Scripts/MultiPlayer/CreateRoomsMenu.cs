using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text roomName;
    [SerializeField] private Text playerName;

    private RoomsCanvases _roomsCanvases;

    public void firstInit(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;

    }

    public void onClickCreateRoom() 
    {
        if(!(roomName.text == null || roomName.text == "")) 
        {
            if (!PhotonNetwork.IsConnected) {
                return;
            }
            PhotonNetwork.JoinOrCreateRoom(roomName.text, new RoomOptions { MaxPlayers = 5 }, TypedLobby.Default);
        }
    }

    public void onClickQuit()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Title Screen");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room: " + roomName.text);
        _roomsCanvases.currentRoom.show();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        newPlayer.NickName = playerName.text;
        PhotonNetwork.NickName = playerName.text;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed To Create Room " + roomName.text + "\n" + message);
    }
}

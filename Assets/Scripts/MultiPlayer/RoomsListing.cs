using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomsListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text text;
    [SerializeField] private Text playerName;
    [SerializeField] private PlayerListingMenu menu;

    public RoomInfo roomInfo { get; private set; }

    public void setRoomInfo(RoomInfo info) {
        roomInfo = info;
        text.text = info.MaxPlayers + ", " + info.Name;
    }

    public void onClickButton()
    {
        playerName = GameObject.Find("Canvases/OverlayCanvases/CreateOrJoinRoomCanvas/Name/NameInput/Text").GetComponent<Text>();
        PhotonNetwork.NickName = playerName.text;
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        newPlayer.NickName = playerName.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvases roomsCanvases;

    public void onClickLeave()
    {
        PhotonNetwork.LeaveRoom(true);
        roomsCanvases.currentRoom.hide();
    }

    public void firstInit(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
    }
}

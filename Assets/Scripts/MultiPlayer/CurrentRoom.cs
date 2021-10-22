using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu playerMenu;
    [SerializeField]
    private LeaveRoomMenu leaveMenu;

    private RoomsCanvases _roomsCanvases;

    public void firstInit(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        leaveMenu.firstInit(canvases);
        playerMenu.firstInit(canvases);
    }
    public void show()
    {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}

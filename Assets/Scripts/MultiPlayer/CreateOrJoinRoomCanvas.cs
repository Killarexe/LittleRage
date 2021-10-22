using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomsMenu _createRoomsMenu;
    [SerializeField]
    private RoomsListingMenu _roomsListingMenu;
    [SerializeField] private Text text;

    private RoomsCanvases _roomsCanvases;

    public void firstInit(RoomsCanvases canvases)
    {
        text = GameObject.Find("Name/NameInput/Text").GetComponent<Text>();
        _roomsCanvases = canvases;
        _createRoomsMenu.firstInit(canvases);
        _roomsListingMenu.firstInit(canvases);
        DiscordPresence.PresenceManager.UpdatePresence("Little Rage v0.1.7a", "In Server Rooms", 0, 0, "basicicon", "Playing Little Rage in Multiplayer", null, null, null, 0, 0, null, null, null);

    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    public void setNickname(string value)
    {
        PlayerPrefs.SetString("Nickname", text.text);
    }

    public void onClickEnter()
    {
        PlayerPrefs.SetString("Nickname", text.text);
    }
}

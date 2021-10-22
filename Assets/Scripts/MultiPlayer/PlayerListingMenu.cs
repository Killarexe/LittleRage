using System.Collections.Generic;
using UnityEngine;
    
using Photon.Realtime;
using Photon.Pun;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing playerListingPrefab;

    private RoomsCanvases roomsCanvases;
    private List<PlayerListing> listings = new List<PlayerListing>();
    private bool _ready = false;

    public override void OnEnable()
    {
        base.OnEnable();
        setReadyUp(false);
        getCurrentRoomPlayers();
        DiscordPresence.PresenceManager.UpdatePresence("Little Rage v0.1.7a", "On a server lobby", 0, 0, "basicicon", "Playing Little Rage in Multiplayer", null, null, null, 0, 0, null, null, null);

    }

    public override void OnDisable()
    {
        base.OnDisable();
        for(int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }
        listings.Clear();
    }

    public void firstInit(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
    }

    private void setReadyUp(bool state)
    {
        _ready = state;
        if (_ready)
        {
            
        }
        else
        {

        }
    }

    private void getCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;
        foreach(KeyValuePair<int, Photon.Realtime.Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            addPlayerListing(playerInfo.Value);
        }
    }

    private void addPlayerListing(Photon.Realtime.Player player)
    {
        int i = listings.FindIndex(x => x.playerInfo == player);
        if (i != -1)
        {
            listings[i].setPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(playerListingPrefab, content);
            if (listing != null)
            {
                listing.setPlayerInfo(player);
                listings.Add(listing);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        addPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        int i = listings.FindIndex(x => x.playerInfo == otherPlayer);
        if (i != -1)
        {
            Destroy(listings[i].gameObject);
            listings.RemoveAt(i);
        }
    }

    public void onClickStart()
    {
        PhotonNetwork.LoadLevel(2);
    }
}

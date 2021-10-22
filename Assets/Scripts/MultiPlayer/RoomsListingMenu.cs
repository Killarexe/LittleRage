using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomsListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomsListing roomListingPrefab;

    private List<RoomsListing> listings = new List<RoomsListing>();
    private RoomsCanvases roomsCanvases;

    public void firstInit(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        roomsCanvases.currentRoom.show();
        content.destroyChildren();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList) {
            if(info.RemovedFromList)
            {
                int i = listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (i != -1) 
                {
                    Destroy(listings[i].gameObject);
                    listings.RemoveAt(i);
                }
            }
            else
            {
                int i = listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (i == -1)
                {
                    RoomsListing listing = Instantiate(roomListingPrefab, content);
                    if (listing != null)
                    {
                        listing.setRoomInfo(info);
                        listings.Add(listing);
                    }
                }
                else
                {

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas;
    public CreateOrJoinRoomCanvas createOrJoinRoomCanvas { get { return _createOrJoinRoomCanvas; } }

    [SerializeField]
    private CurrentRoom _currentRoom;
    public CurrentRoom currentRoom { get { return _currentRoom; } }

    private void Awake()
    {
        firstInit();
    }

    private void firstInit() {
        createOrJoinRoomCanvas.firstInit(this);
        currentRoom.firstInit(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField]
    private PhotonManger manger;

    void Start()
    {
        manger.OnJoinedLevel();
    }
}

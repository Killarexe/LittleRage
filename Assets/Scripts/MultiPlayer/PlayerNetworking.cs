using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworking : MonoBehaviour
{
    public MonoBehaviour[] scriptsToIgnore;
    public Camera[] cameraToIgnore;
    private PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine) 
        {
            foreach (var script in scriptsToIgnore) 
            {
                script.enabled = false;
            }

            foreach (var cam in cameraToIgnore)
            {
                cam.enabled = false;
            }
        }
        else if(view.IsMine)
        {
            foreach (var script in scriptsToIgnore)
            {
                script.enabled = true;
            }

            foreach (var cam in cameraToIgnore)
            {
                cam.enabled = true;
            }
        }
    }

    void Update()
    {
        if (!view.IsMine)
        {
            foreach (var script in scriptsToIgnore)
            {
                script.enabled = false;
            }

            foreach (var cam in cameraToIgnore)
            {
                cam.enabled = false;
            }
        }
        else if (view.IsMine)
        {
            foreach (var script in scriptsToIgnore)
            {
                script.enabled = true;
            }

            foreach (var cam in cameraToIgnore)
            {
                cam.enabled = true;
            }
        }
    }
}

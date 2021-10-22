using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public float timeOffset;
    public Vector3 posOffset;
    public Vector3 velocity;
    private int num;

    private void Start()
    {
        player = GameObject.Find("Player(Clone)");
        player.name = "Player " + Random.Range(0, 2007);
        player2 = GameObject.Find("Player(Clone)");
        player2.name = "Player " + Random.Range(0, 2007);
    }

    void Update()
    {
        if (player2.gameObject != null || player.gameObject != null)
        {
            FixedCameraFollowSmooth(gameObject.GetComponent<Camera>(), player.transform, player2.transform);
        }
        else
        {
            if (player.gameObject != null && player2.gameObject != null)
            {
                player = GameObject.Find("Player(Clone)");
                player.name = "Player " + Random.Range(0, 2007);
                player2 = GameObject.Find("Player(Clone)");
                player2.name = "Player " + Random.Range(0, 2007);
                Update();
            }
            else if (player2.gameObject != null)
            {
                normalCameraMouvement(player2);
            }
            else if (player.gameObject != null)
            {
                normalCameraMouvement(player);
            }
        }
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }

    void normalCameraMouvement(GameObject _player)
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position + posOffset, ref velocity, timeOffset);
    }
}

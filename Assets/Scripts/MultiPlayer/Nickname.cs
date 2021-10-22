using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Nickname : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private PhotonView view;

    private void Awake()
    {
        Debug.Log(PhotonNetwork.NickName);

        if (PhotonNetwork.NickName != null || PhotonNetwork.NickName != "" || PhotonNetwork.NickName != " ")
        {
            text.text = PhotonNetwork.NickName;
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, int.MaxValue);
            text.text = PhotonNetwork.NickName;
            Debug.LogWarning("No Nickname detected!");
        }

        Debug.Log(PhotonNetwork.NickName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseUIManagement : MonoBehaviourPunCallbacks
{
    public void OnClickDisconnect()
    {
        SceneManager.LoadScene("Title Screen");
        PhotonNetwork.Disconnect();
    }
}

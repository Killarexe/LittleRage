using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public Photon.Realtime.Player playerInfo { get; private set; }

    private void Start()
    {
        //text = GameObject.Find("Canvases/OverlayCanvases/CreateOrJoinRoomCanvas/Name/NameInput/Text").GetComponent<Text>();
    }

    public void setPlayerInfo(Photon.Realtime.Player info)
    {
        playerInfo = info;
        PlayerVariables.playerInfo = playerInfo;
        Debug.Log(PlayerPrefs.GetString("Nickname"));
        text.text = PlayerPrefs.GetString("Nickname");
        if (PlayerPrefs.GetString("Nickname").Equals(" ") || PlayerPrefs.GetString("Nickname").Equals("") || PlayerPrefs.GetString("Nickname").Equals(null))
        {
            string name = "Player" + Random.Range(0, int.MaxValue);
            PlayerPrefs.SetString("Nickname", name);
            PhotonNetwork.NickName = PlayerPrefs.GetString("Nickname");
        }
    }
}
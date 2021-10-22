using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using TMPro;

public class ChatManager: MonoBehaviour
{
    [SerializeField] private PhotonView view;
    [SerializeField] private GameObject bubbleSpeechObject;
    [SerializeField] private TMP_Text updatedText;
    [SerializeField] private TMP_InputField field;
    [SerializeField] private GameObject fieldObject;
    [SerializeField] private Player player;
    private bool disableSend;

    private void Awake()
    {
        fieldObject = GameObject.Find("Canvas/ChatField");
        field = fieldObject.GetComponent<TMP_InputField>();
        player = gameObject.GetComponent<Player>();
    }

    private void Update()
    {
        if (view.IsMine)
        {

            fieldObject.SetActive(player.getShowHud);
            disableSend = !player.getShowHud;

            if (!disableSend && field.isFocused)
            {
                if(field.text != "" && field.text.Length != 0 && Input.GetKeyDown(KeyCode.End))
                {
                    view.RPC("SendMessage", RpcTarget.AllViaServer, field.text);
                    bubbleSpeechObject.SetActive(true);
                    field.text = "";
                    disableSend = true;
                }
            }
        }
    }

    [PunRPC]
    private void SendMessage(string msg)
    {
        updatedText.text = msg;
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(4f);
        bubbleSpeechObject.SetActive(false);
        disableSend = false;
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(bubbleSpeechObject.active);
        }
        else if (stream.IsReading)
        {
            bubbleSpeechObject.SetActive((bool)stream.ReceiveNext());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUIManagement : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Start()
    {
        text.text = "Player 1 Win";
        new WaitForSecondsRealtime(2);
        gameObject.SetActive(false);
    }
}

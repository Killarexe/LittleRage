using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public TextMesh text;
    public Player player;
    public GameObject objects;

    private void Awake()
    {
        text.text = "You Finish The Level!\n You Died " + player.getDieCount + " Times To Complete The Level!";
        PlayerPrefs.SetInt("winCoins", PlayerPrefs.GetInt("winCoins") + 1);
    }

    public void ContinueOnClick() {
        objects.SetActive(false);
        player.getDieCount = 0;
        Player.inPause = false;
        Player.isFinish = false;
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}

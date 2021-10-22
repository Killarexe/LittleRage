using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectionScreen : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject multiplayerScreen;

    public void Awake()
    {
    }

    public void solo() {
        SceneManager.LoadScene("Level1");
    }

    public void multiplayer() {
        SceneManager.LoadScene("Rooms");
    }

    public void returnButton(){
        startScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}

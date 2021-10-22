using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject optionsScreen;
    [SerializeField] private GameObject gameModeScreen;
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private Image splashImage;
    [SerializeField] private Sprite[] backgroundImages;
    [SerializeField] private TMP_Text title;

    private void Start()
    {
        splashImage = GameObject.Find("Canvas/SplashImage").GetComponent<Image>();
        title = GameObject.Find("Canvas/Title").GetComponent<TMP_Text>();

        int i = Random.Range(0, backgroundImages.Length);
        splashImage.sprite = backgroundImages[i];

        int j = Random.Range(0, 10000);
        if(j == 50707)
        {
            title.text = "Delta Rage";
        }
        else
        {
            title.text = "Little Rage";
        }
    }

    public void PlayOnClick()
    {
        gameModeScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OptionsOnClick()
    {
        optionsScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CreditsOnClick()
    {
        creditsScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SkinOnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitOnClick()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController: MonoBehaviour
{
    [SerializeField] private Image selectedSkin;
    [SerializeField] private TMP_Text winCoinsText;
    [SerializeField] private SkinManager manager;

    private void Update()
    {
        winCoinsText.text = "Win Coins: " + PlayerPrefs.GetInt("winCoins");
        selectedSkin.sprite = manager.getSelectedSkin().sprite;
    }

    public void loadMenu() => SceneManager.LoadScene(0);
}
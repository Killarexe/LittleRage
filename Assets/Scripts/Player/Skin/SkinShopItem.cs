using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinShopItem: MonoBehaviour
{
    [SerializeField] private SkinManager manager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text costText;
    private Skin skin;

    private void Start()
    {
        skin = manager.skins[skinIndex];
        GetComponent<Image>().sprite = skin.sprite;

        if (manager.isUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = "Cost: " + skin.cost.ToString();
        }
    }

    public void onSkinPressed()
    {
        if (manager.isUnlocked(skinIndex))
        {
            manager.SelectSkin(skinIndex);
        }
    }

    public void onBuyButtonPressed()
    {
        int winCoins = PlayerPrefs.GetInt("winCoins", 0);

        if(winCoins >= skin.cost && !manager.isUnlocked(skinIndex))
        {
            PlayerPrefs.SetInt("winCoins", winCoins - skin.cost);
            manager.unlock(skinIndex);
            buyButton.gameObject.SetActive(false);
            manager.SelectSkin(skinIndex);
        }
        else
        {
            Debug.Log("Not Enough WinCoins");
        }
    }
}
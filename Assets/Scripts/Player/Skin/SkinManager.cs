using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "LittleRage/Skin Manager")]
public class SkinManager: ScriptableObject
{
    [SerializeField] public Skin[] skins;

    private const string prefix = "Skin_";
    private const string selectedSkin = "Selected Skin";

    public void SelectSkin(int skinIndex) => PlayerPrefs.SetInt(selectedSkin, skinIndex);

    public Skin getSelectedSkin()
    {
        int skinIndex = PlayerPrefs.GetInt(selectedSkin, 0);

        if(skinIndex >= 0 && skinIndex < skins.Length)
        {
            return skins[skinIndex];
        }
        else
        {
            return skins[0];
        }
    }

    public void unlock(int skinIndex) => PlayerPrefs.SetInt(prefix + skinIndex, 1);
    public bool isUnlocked(int skinIndex) => PlayerPrefs.GetInt(prefix + skinIndex, 0) == 1;
}

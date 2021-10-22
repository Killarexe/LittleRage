using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCount : MonoBehaviour
{
    public TextMesh text;
    public Player player;

    void Update()
    {
        if (player.getShowHud)
        {
            text.text = "Die Count: " + player.getDieCount;
        }else if (!player.getShowHud)
        {
            text.text = "";
        }
    }
}

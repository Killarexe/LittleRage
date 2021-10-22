using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashText : MonoBehaviour
{
    public TextMesh text;
    public Animator animator;
    public string[] texts;
    private int textType;

    void Start()
    {
        textType = Random.Range(0, texts.Length);
        text.text = texts[textType];
        DiscordPresence.PresenceManager.UpdatePresence("Little Rage v0.1.7a", "In the Main Menu", 0, 0, "basicicon", "Playing Little Rage", null, null, null, 0, 0, null, null, null);
    }

    private void Awake()
    {
        textType = Random.Range(0, texts.Length);
        text.text = texts[textType];
    }

    private void Update()
    {
        animator.SetBool("run", true);
    }
}

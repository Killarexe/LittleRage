using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{
    [Header("Comp")]
    public GameObject startScreen;

    [Header("Variables")]
    [SerializeField] private Vector2Int screenSize;
    [SerializeField] private int maxFps = 60;
    [SerializeField] private bool isFullscreen = false;

    private void Start()
    {
        screenSize = new Vector2Int((int)Screen.safeArea.width, (int)Screen.safeArea.height);
    }

    public void quitOnClick() {
        startScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void resizeOnSet(int i)
    {
        switch (i)
        {
            case 0:
                screenSize = new Vector2Int((int)Screen.safeArea.width, (int)Screen.safeArea.height);
                break;

            case 1:
                if(isScreenSuperior(2560, 1440)){
                    screenSize = new Vector2Int(2560, 1440);
                }
                break;

            case 2:
                if (isScreenSuperior(1920, 1080))
                {
                    screenSize = new Vector2Int(1920, 1080);
                }
                break;

            case 3:
                screenSize = new Vector2Int(1280, 720);
                break;

            case 4:
                screenSize = new Vector2Int(640, 480);
                break;

            default:
                screenSize = new Vector2Int((int)Screen.safeArea.width, (int)Screen.safeArea.height);
                break;
        }
    }

    public void setFullscreen(bool i)
    {
        i = isFullscreen;
    }

    public void fpsOnSet(int i)
    {
        switch (i)
        {
            case 0:
                maxFps = 240;
                break;
            case 1:
                maxFps = 144;
                break;
            case 2:
                maxFps = 120;
                break;
            case 3:
                maxFps = 60;
                break;
            case 4:
                maxFps = 30;
                break;
        }
    }

    private void Update()
    {
        
        Screen.SetResolution(screenSize.x, screenSize.y, screenMode(isFullscreen), maxFps);
    }

    private bool isScreenSuperior(int width , int height)
    {
        if (Screen.safeArea.width <= width || Screen.safeArea.height <= height)
        {
            return true;
        }

        return false;
    }

    private FullScreenMode screenMode(bool i)
    {
        if (i)
        {
            return FullScreenMode.FullScreenWindow;
        }
        return FullScreenMode.Windowed;
    }
}

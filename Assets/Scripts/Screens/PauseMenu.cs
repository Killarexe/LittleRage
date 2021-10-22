using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ContinueOnClick() {
        gameObject.SetActive(false);
        Player.inPause = false;
    }

    public void QuitOnClick()
    {
        Player.inPause = false;
        SceneManager.LoadScene("Title Screen");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueOnClick();
        }
    }
}

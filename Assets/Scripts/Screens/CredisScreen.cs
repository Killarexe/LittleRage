using UnityEngine;

public class CredisScreen : MonoBehaviour
{

    [SerializeField] private GameObject startScreen;

    public void OnClickReturn()
    {
        startScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}

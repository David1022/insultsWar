using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInitScreen : MonoBehaviour
{

    private string SCREEN_TO_OPEN = "InitialScreen";

    public void LaunchInitScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}

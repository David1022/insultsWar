using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenFinalScreen : MonoBehaviour
{

    private static string SCREEN_TO_OPEN = "FinalScreen";

    public static void LaunchPlayScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}

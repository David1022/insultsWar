using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenFinalScreen : MonoBehaviour
{

    static string SCREEN_TO_OPEN = "FinalScreen";

    public static void LaunchPlayScreen()
    {
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }

}

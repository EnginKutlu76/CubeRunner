using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void EndButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Oyun stand-alone olarak çalýþtýrýlýyorsa, uygulamadan çýk
        Application.Quit();
#endif
    }
}

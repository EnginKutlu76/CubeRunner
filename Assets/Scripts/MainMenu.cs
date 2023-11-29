using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    //public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    //public void OptionsButton()
    //{
    //    gameObject.SetActive(false);
    //    panel.SetActive(true);
    //}
    public void EndButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Oyunun Unity Editor içinde çalýþtýrýlýyorsa, oyunu durdur
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Oyun stand-alone olarak çalýþtýrýlýyorsa, uygulamadan çýk
        Application.Quit();
#endif
    }
}

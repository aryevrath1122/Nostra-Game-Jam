using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class MainUiController : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject QuitButton;
    public GameObject AboutButton;
    public GameObject MainMenu;
    public GameObject AboutPanel;
    
    public string sceneToLoad = "LVL 1";
    // Start is called before the first frame update
    public void Start()
    {
        AboutPanel.SetActive(false);
    }

   
    public void QuitBut()
    {
        Application.Quit();
    }
    public void PlayBut()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene(sceneToLoad);
    }
    public void AboutBut()
    {
       AboutPanel?.SetActive(true);
       MainMenu?.SetActive(false);
        PlayButton?.SetActive(false);
        QuitButton?.SetActive(false);
        AboutButton.SetActive(false);
    }
    
}

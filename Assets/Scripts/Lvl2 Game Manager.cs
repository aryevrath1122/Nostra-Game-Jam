using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2GameManager : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject PlayerPrefab;
    public GameObject PauseMenu;
    public GameObject TutorialText;
    public GameObject Joystick1;
    public GameObject Joystick2;
    public GameObject Joystick1Text;
    public GameObject Joystick2Text;
    public float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisappearAfterDelay());
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       for(int i = 5;i>0;i--)
        {

            if(i==0)
            {
                TutorialText.SetActive(false);
            }
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        PlayerPrefab.SetActive(true);
        Joystick1?.SetActive(true);
        Joystick2?.SetActive(true);
        Joystick1Text?.SetActive(true);
        Joystick2Text?.SetActive(true);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu?.SetActive(true);
        PauseButton?.SetActive(false);
        PlayerPrefab?.SetActive(false);
        Joystick1?.SetActive(false);
        Joystick2?.SetActive(false);
        Joystick1Text?.SetActive(false);
        Joystick2Text?.SetActive(false);
    }
    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        TutorialText.SetActive(false); // Deactivate the GameObject
    }
}

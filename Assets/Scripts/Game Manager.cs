using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerManager pm;
    public GameObject PauseButton;
    public GameObject PauseMenu;
    public GameObject PlayerPrefab;
    public GameObject TutorialText;
    public TextMeshProUGUI BoltCountText;
    public float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisappearAfterDelay());
        pm = FindObjectOfType<PlayerManager>();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay();
        for (int i = 5; i > 0; i--)
        {
            if (i == 0)
            {
                TutorialText.SetActive(false);
            }
        }
    }
    private void UpdateScoreDisplay()
    {
        BoltCountText.text = "Bolts: "+pm.CurrentCoinsCollected;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        PlayerPrefab.SetActive(true);
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
    }
    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
       TutorialText.SetActive(false); // Deactivate the GameObject
    }
}

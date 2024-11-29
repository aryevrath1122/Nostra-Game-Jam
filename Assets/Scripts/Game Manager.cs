using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerManager pm;
    public GameObject PauseMenu;
    public TextMeshProUGUI BoltCountText; 
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay();
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu?.SetActive(true);
        }
    }
    private void UpdateScoreDisplay()
    {
        BoltCountText.text = "Bolts: "+pm.CurrentCoinsCollected;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
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
}

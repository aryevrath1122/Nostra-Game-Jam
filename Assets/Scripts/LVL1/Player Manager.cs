using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Max and Current Values")]
    public int MaxPlayerLives = 3;
    public int CurrentPlayerLives = 3;
    public int MaxCoinsToCollect = 10;
    public int CurrentCoinsCollected = 0;

    [Header("References")]
    
    public GameObject PortalPrefab;
    public Transform LvlSpawnPos;
    private CoinCollector coinCollector;
    // Start is called before the first frame update
    void Start()
    {
        PortalPrefab.SetActive(false);
        coinCollector = FindObjectOfType<CoinCollector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PortalSpawn();
        LivesDetect();
    }
    void LivesDetect()
    {
        if (CurrentPlayerLives == 0)
        {
            Debug.Log("Game Over");
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
    public void LevelReset()
    {
        this.gameObject.transform.position = LvlSpawnPos.transform.position;
        this.gameObject.SetActive(true);
        CurrentPlayerLives--;
    }
    void Respawn()
    {
        this.gameObject.transform.position = LvlSpawnPos.transform.position;
        this.gameObject.SetActive(true);
    }
    void PortalSpawn()
    {
        if (CurrentCoinsCollected == 10)
        {
            PortalPrefab.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Portal"))
        {
            Debug.Log("Collided");
            // Load the scene
            SceneManager.LoadScene("Flying Test");
        }
        if(collision.collider.CompareTag("Obstacles"))
        {
            this.gameObject.SetActive(false);
            CurrentPlayerLives--;
            Respawn();
        }
    }
 
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerManager pm;
    public TextMeshProUGUI BoltCountText; 
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay();
    }
    private void UpdateScoreDisplay()
    {
        BoltCountText.text = "Bolts: "+pm.CurrentCoinsCollected;
    }
}

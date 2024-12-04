using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverWin;
    public TextMeshProUGUI gameOverlose;
    public bool gameIsActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool playerwins)
    {
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;

        if (playerwins)
        {
            gameOverWin.gameObject.SetActive(true);
        }
        else if (!playerwins)
        {
            gameOverlose.gameObject.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    private Text bestScoreText;
    void Awake() 
    {
        bestScoreText = GetComponent<Text>();
    }
    void Start()
    {
        DataHolder.Instance.LoadScore();
        if (DataHolder.Instance != null)
        {
          if (DataHolder.Instance.hiScore != 0)
            {
                DisplayHighScore();
            }else{
                DisplayName();
            }  
        }else{
            bestScoreText.text = "Hello, set a high score!";
        }
        
    }
    void DisplayHighScore()
    {
        bestScoreText.text = $"Best Score : {DataHolder.Instance.highScoreName} : {DataHolder.Instance.hiScore}";        
    }
    void DisplayName()
    {
        bestScoreText.text = DataHolder.Instance.playerName;
    }
}

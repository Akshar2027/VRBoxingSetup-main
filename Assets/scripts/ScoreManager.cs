using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;

    public void IncrementScore(int amount)
    {
        score = score + amount;
        scoreText.text = score.ToString();
    }
    
}

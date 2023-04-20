using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Technicalities : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Friends fed: " + score;
    }

    public int Score(int point)
    {
        score += point;
        return score;
    }
}

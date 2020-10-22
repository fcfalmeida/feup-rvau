using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scoreGoal;
    public Text scoreText;
    private int playerScore;

    void Start()
    {
        scoreText.text = "Books found: 0/" + scoreGoal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int newScore)
    {
        playerScore = newScore;
        scoreText.text = "Books found: " + newScore + "/" + scoreGoal;
    }
}

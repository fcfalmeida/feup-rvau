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
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayScore()
    {
        scoreText.text = "Books found: " + playerScore + "/" + scoreGoal;
        scoreText.gameObject.SetActive(true);
        StartCoroutine("HideScore");
    }

    private IEnumerator HideScore()
    {
        yield return new WaitForSeconds(4f);
        scoreText.gameObject.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        playerScore = newScore;
        DisplayScore();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Slenderman slenderman;
    public PlayerController player;
    public Canvas menuCanvas;

    [Header("Difficulty Parameters")]
    public int scoreGoal;
    public float slendermanSpeed;

    private int playerScore;
    private bool inGame;

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

    public void StartGame() 
    {
        inGame = true;
        slenderman.enabled = true;
        player.enabled = true;
        menuCanvas.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        Debug.Log("Game Over!");
        inGame = false;
    }

    public bool IsInGame()
    {
        return inGame;
    }

    public void ChangeDifficulty(string difficulty)
    {
        switch (difficulty) 
        {
            case "Easy":
                scoreGoal = 4;
                slendermanSpeed = 1.0f;
                break;
            case "Medium":
                scoreGoal = 6;
                slendermanSpeed = 1.2f;
                break;
            case "Hard":
                scoreGoal = 8;
                slendermanSpeed = 1.4f;
                break;
            default:
                break;
        }
    }
}

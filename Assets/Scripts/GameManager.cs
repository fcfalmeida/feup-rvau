﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Slenderman slenderman;
    public PlayerController player;
    public Canvas menuCanvas;
    public Canvas winCanvas;

    [Header("Difficulty Parameters", order = 0)]
    [Space]
    [Header("Easy", order = 1)]
    public int scoreGoalEasy;
    public float slendermanHitByThrowableForceEasy;
    public float slendermanSpeedEasy;
    [Header("Medium")]
    public int scoreGoalMedium;
    public float slendermanHitByThrowableForceMedium;
    public float slendermanSpeedMedium;
    [Header("Hard")]
    public int scoreGoalHard;
    public float slendermanHitByThrowableForceHard;
    public float slendermanSpeedHard;

    private int playerScore;
    private bool inGame;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = player.transform.position;

        // initialize difficulty variables if they haven't been set yet
        if (Settings.scoreGoal == 0) Settings.scoreGoal = scoreGoalEasy;
        if (Settings.slendermanHitByThrowableForce == 0) Settings.slendermanHitByThrowableForce = slendermanHitByThrowableForceEasy;
        if (Settings.slendermanSpeed == 0) Settings.slendermanSpeed = slendermanSpeedEasy;
    }
    private void DisplayScore()
    {
        scoreText.text = "Books found: " + playerScore + "/" + Settings.scoreGoal;
        scoreText.gameObject.SetActive(true);
        StartCoroutine(FadeText(3f, scoreText, Color.white));
        StartCoroutine("HideScore");
    }

    private IEnumerator HideScore()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeText(3f, scoreText, Color.clear));
        yield return new WaitForSeconds(3f);
        scoreText.gameObject.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        playerScore = newScore;

        if (playerScore == Settings.scoreGoal)
        {
            WinGame();
        }
        else
        {
            DisplayScore();
        }
    }

    public void StartGame()
    {
        inGame = true;
        slenderman.enabled = true;
        player.enabled = true;
        menuCanvas.gameObject.SetActive(false);

        GetComponent<PickupSpawner>().enabled = true;

        DisplayScore();
    }

    public void EndGame()
    {
        Debug.Log("Game Over!");
        Camera.main.GetComponent<Animator>().SetBool("gameOver", true);
        player.enabled = false;
        Physics.IgnoreCollision(slenderman.GetComponent<Collider>(), player.GetComponent<Collider>());
        player.GetComponentInChildren<Kino.AnalogGlitch>().horizontalShake = 0.4f;
        Invoke("ShowSlenderManInFront", 1);
    }

    public void WinGame()
    {
        Debug.Log("You Won!");
        player.enabled = false;
        slenderman.enabled = false;

        float xDirection = Camera.main.transform.forward.x;
        float yDirection = 0;
        float zDirection = Camera.main.transform.forward.z;

        Vector3 lookingDirection = new Vector3(xDirection, yDirection, zDirection);

        winCanvas.transform.LookAt(winCanvas.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        winCanvas.transform.rotation = Quaternion.Euler(0, winCanvas.transform.rotation.eulerAngles.y, 0);

        winCanvas.transform.position = player.transform.position + lookingDirection * 0.6f;

        winCanvas.gameObject.SetActive(true);
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void ShowSlenderManInFront()
    {
        float xDirection = Camera.main.transform.forward.x;
        float yDirection = Camera.main.transform.forward.y;
        float zDirection = Camera.main.transform.forward.z;

        Vector3 lookingDirection = new Vector3(xDirection, yDirection, zDirection);

        player.GetComponentInChildren<LockCamera>().offset = new Vector3(0, 0.43f, 0);

        Camera.main.GetComponentInChildren<Light>().enabled = true;

        slenderman.transform.position = player.transform.position + lookingDirection * 0.3f;

        Invoke("Reset", 1);
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
                Settings.scoreGoal = scoreGoalEasy;
                Settings.slendermanHitByThrowableForce = slendermanHitByThrowableForceEasy;
                Settings.slendermanSpeed = slendermanSpeedEasy;
                break;
            case "Medium":
                Settings.scoreGoal = scoreGoalMedium;
                Settings.slendermanHitByThrowableForce = slendermanHitByThrowableForceMedium;
                Settings.slendermanSpeed = slendermanSpeedMedium;
                break;
            case "Hard":
                Settings.scoreGoal = scoreGoalHard;
                Settings.slendermanHitByThrowableForce = slendermanHitByThrowableForceHard;
                Settings.slendermanSpeed = slendermanSpeedHard;
                break;
            default:
                break;
        }
    }

    private IEnumerator FadeText(float fadeOutTime, Text text, Color targetColor)
    {
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, targetColor, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
}

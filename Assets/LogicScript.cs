using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public float BGincrease;
    private static LogicScript instance;
    Material material;
    Vector2 offset;
    public float Xvelocity, Yvelocity;
    public AudioSource scoreSound;
    public AudioSource gameOverSound;
    public AudioSource restartSound;


    private void Awake()
    {
        material = GameObject.Find("Quad").GetComponent<Renderer>().material;
        instance = this;
    }

    void Start()
    {
        startspeed();
    }

    private void Update()
    {
        offset = new Vector2(Xvelocity, Yvelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }

    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (scoreSound != null)
        {
            scoreSound.Play(); // Play score sound when adding score
        }

        // Increase game speed every 10 points
        if (playerScore % 10 == 0)
        {
            increaseGameSpeed();
        }
    }


    public void restartGame()
    {
        if (restartSound != null && !restartSound.isPlaying) // Check if sound is not already playing
        {
            restartSound.Play(); // Play restart sound
        }

        // You can optionally add a delay here to allow the sound to play fully before restarting
        StartCoroutine(RestartAfterSound());
    }

    IEnumerator RestartAfterSound()
    {
        yield return new WaitForSeconds(restartSound.clip.length); // Wait for the duration of the restart sound
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
    }


    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void gameOver()
    {
        // Only activate the game over screen if it's not already active
        if (!gameOverScreen.activeSelf)
        {
            gameOverScreen.SetActive(true);
        }

        // Stop the background scrolling
        stopspeed();

        // Play the game over sound, but only once when the game is over
        if (gameOverSound != null && !gameOverSound.isPlaying)
        {
            gameOverSound.Play();
        }
    }



    IEnumerator increaseSpeed()
    {
       while (true)
        {
            increaseGameSpeed();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void increaseGameSpeed()
    {
        Xvelocity += BGincrease;
    }

    public void startspeed()
    {
        StartCoroutine("increaseSpeed");
    } 

    public void stopspeed()
    {
        StopCoroutine("increaseSpeed");
    }
}

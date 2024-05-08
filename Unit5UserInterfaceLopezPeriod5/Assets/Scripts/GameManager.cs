using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI livesText;
    public bool isGamePaused = false;
    public GameObject pausedScreen;


    private float spawnRate = 1.0f;
    private int score;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive == true)
        {
            pauseGame();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        lives = 3;
        livesText.text = "Lives:" + lives;
        isGamePaused = false;
    }

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;

        if(lives <=0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives:" + lives;
    }

    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                pausedScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else
            {
                pausedScreen.gameObject.SetActive(false);
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
        }
    }
}

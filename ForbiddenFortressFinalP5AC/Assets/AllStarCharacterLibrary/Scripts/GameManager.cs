using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditorInternal;
using Unity.PlasticSCM.Editor.WebApi;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    public TextMeshProUGUI timerUI;

    private int score;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);

        gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator UpdateTimer()
    {
        while(timer > 0 && isGameActive)
        {
            yield return new WaitForSeconds(1);
            timer -= 1;
            timerUI.text = "Timer: " + timer;
        }
        GameOver();
    }
}

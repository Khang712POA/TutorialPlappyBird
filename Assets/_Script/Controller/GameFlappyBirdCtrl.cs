using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlappyBirdCtrl : MonoBehaviour
{
    public static GameFlappyBirdCtrl Instance;
    [SerializeField]
    private Button instructionButton;
    [SerializeField] private Text scoreText, endScoreText, bestScoreText;
    [SerializeField] private GameObject gameOverPanel, pausePanel;
    private void Awake()
    {
        _MakeInstance();
        Time.timeScale = 0f;
    }
    private void _MakeInstance()
    {
        if(Instance == null)
        {
            Instance = this;    
        }
    }
    public void _InstructionButton()
    {
        Time.timeScale = 1f;
        instructionButton.gameObject.SetActive(false);
    }
    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void BirdDieShowPanelOver(int score)
    {
        gameOverPanel.SetActive(true);

        endScoreText.text = "" + score;
        if(score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighScore();
    }

    public void _MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }
    public void _RestartAndResumeButton()
    {
        Application.LoadLevel("GamePlappyBird");
        //Application.LoadLevel(Application.loadedLevel);
    }
    public void _PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void _ResumeButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}

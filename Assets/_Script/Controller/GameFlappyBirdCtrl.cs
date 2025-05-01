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
    [SerializeField] private GameObject gameOverPanel;
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
    public void BirdDieShowPanelOver()
    {
        gameOverPanel.SetActive(true); 
    }
}

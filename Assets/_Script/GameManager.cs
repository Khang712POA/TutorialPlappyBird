using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const string HIGH_SCORE = "HighScore";
    private void Awake()
    {
        this._MakeSingleInstance();
    }
    void IsGameStartedForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    void _MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, highScore);
    }    
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}

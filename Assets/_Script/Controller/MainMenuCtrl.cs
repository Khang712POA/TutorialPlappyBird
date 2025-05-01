using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour
{
    public void _PlayButton()
    {
        //Application.LoadLevel("GamePlappyBird");
        SceneManager.LoadScene("GamePlappyBird");
    }
}

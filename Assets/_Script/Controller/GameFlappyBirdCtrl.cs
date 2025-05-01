using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlappyBirdCtrl : MonoBehaviour
{
    [SerializeField]
    private Button instructionButton;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void _InstructionButton()
    {
        Time.timeScale = 1f;
        instructionButton.gameObject.SetActive(false);
    }
}

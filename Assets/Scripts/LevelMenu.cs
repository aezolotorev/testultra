using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject LooseMenu;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject ButtonMenu;
    [SerializeField] GameObject ScorePanel;
    [SerializeField] GameObject BestResultPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI TextComplete;
    private void Start()
    {
        LooseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Menu.SetActive(false);
        ButtonMenu.SetActive(true);
        ScorePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void GameMenu()
    {
        Menu.SetActive(true);
        ButtonMenu.SetActive(false);
        Time.timeScale = 0;
    }
    public void Back()
    {
        Menu.SetActive(false);
        ButtonMenu.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void BestResults()
    {
        BestResultPanel.SetActive(true);
    }

    public void GameOver()
    {
        ButtonMenu.SetActive(false);
        LooseMenu.SetActive(true);
        TextComplete.text = "Game Over";
        ScorePanel.SetActive(true);
        Time.timeScale = 0;

    }
    public void LevelComplete()
    {
        ButtonMenu.SetActive(false);
        WinMenu.SetActive(true);
        TextComplete.text = "Level Complete";
        ScorePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetScoreText(int scoreingame)
    {
        scoreText.text = scoreingame.ToString();
    }
   
}

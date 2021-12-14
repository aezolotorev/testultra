using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public  bool isGameNotOver;
    [SerializeField] Score score;
    [SerializeField] Results results;
    [SerializeField] LevelMenu levelMenu;
    [SerializeField] EndPlatform endPlatform;
    private void Awake()
    {
        score = GetComponent<Score>();
        results = GetComponent<Results>();
        levelMenu = GetComponent<LevelMenu>();
        endPlatform = GameObject.FindGameObjectWithTag("EndPlatform").GetComponent<EndPlatform>();
    }
    private void Start()
    {
        isGameNotOver = true;
        endPlatform.gameisover += GameOver;
    }
    private void OnDisable()
    {
        endPlatform.gameisover -= GameOver;
    }

    public void GameOver()
    {
        if (isGameNotOver)
        {
            levelMenu.GameOver();
            IsOver();
            isGameNotOver = false;
        }
       
    }
    public void LevelComplete()
    {
        if (isGameNotOver)
        {
            levelMenu.LevelComplete();
            IsOver();
            isGameNotOver = false;
        }
    }

    public void IsOver()
    {
        var r = score.GetCurrentScore();
        levelMenu.SetScoreText(r);
        results.ChangeResult(r);
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{    
    [SerializeField] int scoreSurvive;
    [SerializeField] int scoreDistance;
    [SerializeField] TextMeshProUGUI scoreSurviveText;
    [SerializeField] GameObject scoreSurviveObj;
    [SerializeField] TextMeshProUGUI scoreDistanceText;
    [SerializeField] GameObject scoreDistanceObj;
    [SerializeField] GameObject player;
    //не знал как лучше считать баллы, сделал по времени нахождения в игре и по высоте на которую поднялся игрок
    public enum Type
    {
        Survive, Distance,
    }
    public Type type;

    private void Start()
    {
        scoreSurvive = 0;
        scoreDistance = 0;
        if (type == Type.Survive)
        {
            StartCoroutine(ScoreSurvival());
            scoreDistanceObj.SetActive(false);
            scoreSurviveObj.SetActive(true);
        }
        else
        {
            scoreDistanceObj.SetActive(true);
            scoreSurviveObj.SetActive(false);
        }
    }

    private void Update()
    {
        if(type==Type.Distance)
        ScoreDistance();
    }
    IEnumerator  ScoreSurvival()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            scoreSurvive++;
            scoreSurviveText.text = "ScoreSurvive: " + scoreSurvive.ToString();
        }
    }

    public void ScoreDistance()
    {
        int scoreDistanceCur = (int)player.transform.position.y;
        if (scoreDistance < scoreDistanceCur)
        {
            scoreDistance = scoreDistanceCur;
        }
        scoreDistanceText.text = "ScoreDistance: " + scoreDistance.ToString();
    }

    public int GetCurrentScore()
    {
        if(type==Type.Survive)
           return scoreSurvive;
        else
           return scoreDistance;
    }

}

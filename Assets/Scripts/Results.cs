using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Results : MonoBehaviour
{

    [SerializeField] List<TextMeshProUGUI> res;
    [SerializeField] private List<int> bestres=new List<int>(3);
    private void Start()
    {        
        ReadPrefs();  
    }

    void ReadPrefs()
    {
        for (int i = 0; i < bestres.Count; i++)
        {
            if (PlayerPrefs.HasKey("res" + i.ToString()))
            {
                bestres[i] = PlayerPrefs.GetInt("res" + i.ToString());
            }
            else
            {
                bestres[i] = 0;
                PlayerPrefs.GetInt("res" + i.ToString(), bestres[i]);
            }            
        }
        ShowScore();

    }
    void ShowScore()
    {
        for (int i = 0; i < bestres.Count; i++)
        {
            res[i].text = bestres[i].ToString();
        }
    }

    void WritePrefs()
    {
        for (int i = 0; i < bestres.Count; i++)
        {
            PlayerPrefs.SetInt("res" + i.ToString(), bestres[i]);            
        }
    }


    public void ChangeResult(int newres)
    {
        bestres.Add(newres);
        bestres.Sort();       
        bestres.RemoveAt(0);
        WritePrefs();
        ShowScore();
    }
    
    

    public void Delete() //для проверки
    {
        PlayerPrefs.DeleteAll();
        ReadPrefs();
        
    }
}



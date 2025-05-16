using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreboardDisplay : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(GetScoreboard());
    }

    private IEnumerator GetScoreboard()
    {
        WWW request = new WWW("http://localhost/sqlconnect/printScoreBoard.php");
        yield return request;
        GenerateTable(request.text);
    }

    void GenerateTable(string input)
    {
        string[] rows = input.Split('\n');
        
        for (int i = 0; i < 7; i++)
        {
            string[] cell = rows[i].Split("\t");
            for (int j = 0; j < 3; j++)
            {
                transform.GetChild(i+1).GetChild(j).GetComponent<TMP_Text>().text = cell[j];
            }
        }
    }
}

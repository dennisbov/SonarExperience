using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestWebRequest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", "Andrew");
        form.AddField("survivalTime", "122");
        form.AddField("collectedBatteries", "5");
        WWW www = new WWW("http://localhost/sqlconnect/scoreboard.php", form);
        yield return www;
        Debug.Log(www.text);
    }
}
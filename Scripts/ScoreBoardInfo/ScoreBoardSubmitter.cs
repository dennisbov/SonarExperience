using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreBoardSubmitter : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;

    [SerializeField] private TMP_InputField lastMessageField;

    [SerializeField] private Button submitButton;

    [SerializeField] private int minNameCharacters;

    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;
    public void CallSubmitter()
    {
        StartCoroutine(SubmitScore());
        StartCoroutine(AddBoatDebris());
        StartCoroutine(AddMessageEmmiters());
        StartCoroutine(AddStorages());
    }

    IEnumerator SubmitScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nameField.text);
        form.AddField("survivalTime", Mathf.RoundToInt(currentPlayerScoreInfo.elapsedTime).ToString());
        form.AddField("collectedBatteries", currentPlayerScoreInfo.collectedBattaries.ToString());
        WWW www = new WWW("http://localhost/sqlconnect/scoreboard.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("user created succesfully");
        }
        else 
        {
            Debug.Log("User creation failed with error: " + www.error + www.text);
        }
    }

    IEnumerator AddBoatDebris()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nameField.text);
        form.AddField("collectedBatteries", (currentPlayerScoreInfo.collectedBattaries/2).ToString());
        form.AddField("lastMessage", lastMessageField.text);
        form.AddField("X", Mathf.RoundToInt(currentPlayerScoreInfo.deathPosition.x).ToString());
        form.AddField("Y", Mathf.RoundToInt(currentPlayerScoreInfo.deathPosition.y).ToString());
        WWW www = new WWW("http://localhost/sqlconnect/addDebris.php", form);
        yield return www;
    }

    IEnumerator AddMessageEmmiters()
    {
        foreach (MessageEmmiterStr emmiter in currentPlayerScoreInfo.messageEmmiters)
        {
            WWWForm form = new WWWForm();
            form.AddField("nickname", nameField.text);
            form.AddField("message", emmiter.message);
            form.AddField("X", Mathf.RoundToInt(emmiter.position.x).ToString());
            form.AddField("Y", Mathf.RoundToInt(emmiter.position.x).ToString());
            WWW www = new WWW("http://localhost/sqlconnect/addMessageEmmiter.php", form);
            yield return www;
        }
    }

    IEnumerator AddStorages()
    {
        foreach (StorageStr storage in currentPlayerScoreInfo.storages)
        {
            WWWForm form = new WWWForm();
            form.AddField("nickname", nameField.text);
            form.AddField("batteriesAmount", storage.batteries_amount);
            form.AddField("X", Mathf.RoundToInt(storage.position.x).ToString());
            form.AddField("Y", Mathf.RoundToInt(storage.position.y).ToString());
            WWW www = new WWW("http://localhost/sqlconnect/addStorage.php", form);
            yield return www;
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= minNameCharacters);
    }
}

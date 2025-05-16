using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageResiever : MonoBehaviour
{
    [SerializeField] private TMP_Text messageDisplay;
    [SerializeField] private TMP_InputField messageInputField;
    [SerializeField] private GameObject messagePref;
    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;

    private void Start()
    {
        currentPlayerScoreInfo.messageEmmiters = new List<MessageEmmiterStr>();
    }

    public void SetMessage(string message)
    {
        messageDisplay.text = message;
    }
    public void ClearMessage()
    {
        messageDisplay.text = "";
    }

    public void StartCreatingMessage()
    {
        messageInputField.gameObject.SetActive(true);
    }

    public void CreateMessage(string message)
    {
        GameObject messageObj = Instantiate(messagePref, transform.position, Quaternion.identity);
        MessageEmmiter messageEmmiter = messageObj.GetComponent<MessageEmmiter>();
        messageEmmiter.Message = messageInputField.text;
        currentPlayerScoreInfo.messageEmmiters.Add(new MessageEmmiterStr(messageEmmiter.transform.position, messageEmmiter.Message));
        messageInputField.gameObject.SetActive(false);
    }
}

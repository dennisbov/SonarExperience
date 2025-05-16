using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "current player score", menuName ="create player score")]
public class CurrentPlayerScoreInfo : ScriptableObject
{
    public float elapsedTime;
    public int collectedBattaries;
    public Vector2 deathPosition;
    public List<MessageEmmiterStr> messageEmmiters;
    public List<StorageStr> storages;
}

[Serializable]
public struct MessageEmmiterStr
{
    public Vector2 position;
    public string message;

    public MessageEmmiterStr(Vector2 position, string message)
    {
        this.position = position;
        this.message = message;
    }
}

[Serializable]
public struct StorageStr
{
    public Vector2 position;
    public int batteries_amount;

    public StorageStr(Vector2 position, int batteries_amount)
    {
        this.position = position;
        this.batteries_amount = batteries_amount;
    }
}

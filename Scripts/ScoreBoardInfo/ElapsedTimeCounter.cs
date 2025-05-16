using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElapsedTimeCounter : MonoBehaviour
{
    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;
    [SerializeField] private TMP_Text _elapsedTimeCounter;

    private float _elapsedTime;

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        currentPlayerScoreInfo.elapsedTime = _elapsedTime;
        _elapsedTimeCounter.text = _elapsedTime.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatteriesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text BatteryCounter;
    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;

    [SerializeField] private EnergyCounter energyCounter;

    public int CollectedBatteries;
    private void OnEnable()
    {
        energyCounter.OnBatteryCollected += CollectBattery;
    }

    private void OnDisable()
    {
        energyCounter.OnBatteryCollected -= CollectBattery;
    }

    void CollectBattery()
    {
        CollectedBatteries++;
        
        currentPlayerScoreInfo.collectedBattaries = CollectedBatteries;
        BatteryCounter.text = CollectedBatteries.ToString();
    }

    public void ChangeBattariesAmount(int delta) 
    { 
        CollectedBatteries += delta;

        currentPlayerScoreInfo.collectedBattaries = CollectedBatteries;
        BatteryCounter.text = CollectedBatteries.ToString();
    }
}

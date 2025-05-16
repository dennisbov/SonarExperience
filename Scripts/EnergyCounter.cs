using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void Message();

public class EnergyCounter : MonoBehaviour
{
    [SerializeField] private int _maxEnergy;
    [SerializeField] private BoatMoving _moveComponent;
    [SerializeField] private float _decreaceSpeed;
    [SerializeField] private Text UICounter;

    public Message OnBatteryCollected;
    
    private int _energy;
    private float expiredTime;

    private void Start()
    {
        _energy = _maxEnergy;
    }

    private void Update()
    {
        if(expiredTime > _decreaceSpeed)
        {
            ChangeValue(-1);
            expiredTime = 0;
        }
        expiredTime += Time.deltaTime;
    }

    public void ChangeValue(int value)
    {
        _energy += value;
        _energy = Mathf.Clamp(_energy, 0, _maxEnergy);
        if(_energy == 0)
        {
            _energy = 0;
            _moveComponent.enabled = false;
        }
        UICounter.text = _energy.ToString();
    }


}

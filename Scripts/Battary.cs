using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battary : MonoBehaviour
{
    [SerializeField] private int _power;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<EnergyCounter>(out EnergyCounter counter))
        {
            counter.ChangeValue(_power);
            counter.OnBatteryCollected();
            Destroy(gameObject);
        }
    }
}

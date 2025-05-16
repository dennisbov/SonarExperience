using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSonar : MonoBehaviour
{
    [SerializeField] private EmmitingSoundInfo PassiveSonarEmmition;
    [SerializeField] private float passiveSonarEmmitionPeriod;
    [SerializeField] private EmmitingSoundAction OnAction;
    [SerializeField] private GameObject helpfulMark;

    private float expiredTime = 0;
    private void Update()
    {
        if (expiredTime > passiveSonarEmmitionPeriod)
        {
            OnAction.Invoke(PassiveSonarEmmition);
            SpawnMark();
            expiredTime = 0;
        }
        expiredTime += Time.deltaTime;
    }
    
    private void SpawnMark()
    {
        Instantiate(helpfulMark, transform.position, Quaternion.identity);
    }
}

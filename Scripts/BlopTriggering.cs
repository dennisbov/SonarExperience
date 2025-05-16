using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlopTriggering : MonoBehaviour
{
    [SerializeField] private float _triggerRadius;
    [SerializeField] private LayerMask HazardLayer;

    public void Trigger()
    {
        Collider2D blop = Physics2D.OverlapCircle(transform.position, _triggerRadius, HazardLayer);
        if (blop != null)
        {
            blop.TryGetComponent<TargetFollowing>(out TargetFollowing enemy);
            enemy.StartChasing();
        }
    }
}

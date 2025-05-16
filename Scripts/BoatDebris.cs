using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDebris : MonoBehaviour
{
    public string LastMessage = "";
    public float Radius = 4f;

    private MessageResiever _resiever;
    private bool _isInside;

    public int BatteriesAmmount;
    public bool IsActive;

    private void Start()
    {
        _resiever = FindFirstObjectByType<MessageResiever>();
        _isInside = false;
    }

    private void Update()
    {
        float distance = Vector2.Distance(_resiever.transform.position, transform.position);
        if (distance <= Radius && _isInside == false)
        {
            _resiever.SetMessage(LastMessage);
            _isInside = true;
        }
        if (distance > Radius && _isInside)
        {
            _resiever.ClearMessage();
            _isInside = false;
        }
    }


}

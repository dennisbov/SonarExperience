using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageEmmiter : MonoBehaviour
{
    public string Message = "";
    public float Radius = 4f;

    private MessageResiever _resiever;
    private bool _isInside;

    private void Start()
    {
        _resiever = FindFirstObjectByType<MessageResiever>();
        _isInside = false;
    }

    private void Update()
    {
        float distance = Vector2.Distance(_resiever.transform.position, transform.position);
        if(distance <= Radius && _isInside == false)
        {
            _resiever.SetMessage(Message);
            _isInside = true;
        }
        if(distance > Radius && _isInside)
        {
            _resiever.ClearMessage();
            _isInside = false;
        }
    }
}

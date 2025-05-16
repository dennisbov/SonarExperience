using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SwingingDrill : MonoBehaviour
{
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private AnimationCurve _AngularCurve;
    [SerializeField] private float _period;
    [SerializeField] private float _extentionSpeed;
    [SerializeField] private float _startRadius;
    [SerializeField] private LayerMask _hardenedStoneMask;
    [SerializeField] private float _throwBackForce;

    private Collider2D _collider;
    private bool _isSwingRight = true;
    private float _currentAngle;
    private float _currentRadius;
    private int _currentDirection;

    private void Start()
    {
        _currentAngle = _minAngle;
        _currentRadius = _startRadius;
    }

    private float _expiredTime;
    private float _swingPercentage;

    private void Update()
    {
        _swingPercentage = _isSwingRight ? _expiredTime / _period : 1 - _expiredTime / _period;
        _currentAngle = (_AngularCurve.Evaluate(_swingPercentage)) * Mathf.Abs(_minAngle - _maxAngle) + _minAngle;

        if (_expiredTime > _period)
        {
            _isSwingRight = !_isSwingRight;
            _expiredTime = 0;
        }

        transform.localPosition = new Vector2(Mathf.Cos(_currentAngle * Mathf.Deg2Rad), Mathf.Sin(_currentAngle * Mathf.Deg2Rad)) * _currentRadius;

        if (Input.GetKey(KeyCode.E))
        {
            _currentRadius += _extentionSpeed * Time.deltaTime;
        }

        _expiredTime += Time.deltaTime;
    }

    public IEnumerator ReturnDrill()
    {
        _collider.enabled = false;
        while (_currentRadius > _startRadius)
        {
            _currentRadius -= _extentionSpeed;
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }

    public IEnumerator ThrowBack(float lenght)
    {
        _collider.enabled = false;
        while (_currentRadius > Mathf.Clamp(_currentRadius - lenght, _startRadius, Mathf.Infinity))
        {
            _currentRadius -= _extentionSpeed;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _hardenedStoneMask)
        {
            StartCoroutine(ThrowBack(_throwBackForce));
        }
    }
}

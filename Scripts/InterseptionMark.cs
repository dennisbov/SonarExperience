using System.Collections;
using UnityEngine;

public class InterseptionMark : MonoBehaviour
{
    private SpriteRenderer _sprite;
    [System.NonSerialized] public float Power = 1;
    [SerializeField] private float _pulseTime;
    [SerializeField] private float _fadingTime;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        SetSpriteAlphaChanel(0);
        StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        float expiredTime = 0;

        while (expiredTime < _pulseTime)
        {
            SetSpriteAlphaChanel(expiredTime/_pulseTime * Power);
            expiredTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        expiredTime = 0;
        while (expiredTime < _fadingTime)
        {
            SetSpriteAlphaChanel((1 - expiredTime / _fadingTime) * Power);
            expiredTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

    private void SetSpriteAlphaChanel(float alpha)
    {
        _sprite.color = new Color(
            _sprite.color.r,
            _sprite.color.g,
            _sprite.color.b,
            alpha);
    }
}

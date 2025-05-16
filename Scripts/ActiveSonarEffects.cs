using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSonarEffects : MonoBehaviour
{
    [SerializeField] private Transform _circle1;
    [SerializeField] private Transform _circle2;
    [SerializeField] private float _sonarThin;
    [SerializeField] private AudioClip _radarPipSound;
    [SerializeField] private AudioSource _audioSource;

    public void ScanEffect(EmmitingSoundInfo soundInfo)
    {
        _audioSource.PlayOneShot(_radarPipSound);
        StartCoroutine(InflateCircles(soundInfo));
    }

    private IEnumerator InflateCircles(EmmitingSoundInfo soundInfo)
    {
        float expiredTime = 0;
        while (expiredTime < soundInfo.ShowcaseDuration)
        {
            _circle1.localScale = Vector2.one * expiredTime / soundInfo.ShowcaseDuration * soundInfo.RaysLenth*2;
            _circle2.localScale = Vector2.one * (_circle1.localScale.x - _sonarThin);
            expiredTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _circle1.localScale = Vector2.zero;
        _circle2.localScale = Vector2.zero;
    }
}

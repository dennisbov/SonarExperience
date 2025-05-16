using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lurkingSpeed;
    [SerializeField] private float _chasingSpeed;
    [SerializeField] private float _lurkingRoarPeriod;
    [SerializeField] private float _chasingRoarPeriod;
    [SerializeField] private float _chasingTime;
    [SerializeField] private AudioClip[] _humNoises;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SoundEmmiter _emmiter;
    [SerializeField] private EmmitingSoundInfo _monsterSoundInfo;

    private bool _isChasing;
    private NavMeshAgent _agent;
    private float _currentRoarPeriod;
   
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _lurkingSpeed;
        _currentRoarPeriod = _lurkingRoarPeriod;
    }

    private float expiredTime;
    private float calmTimer;
    private void Update()
    {
        if (_isChasing)
        {
            calmTimer += Time.deltaTime;
            if(calmTimer > _chasingTime)
            {
                StopChasing();
            }
        }
        _agent.SetDestination(_target.position);
        if(expiredTime > _currentRoarPeriod)
        {
            PlaySound();
            expiredTime = 0;
        }
        Quaternion rotation = Quaternion.LookRotation(_target.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        expiredTime += Time.deltaTime;
    }

    public void StartChasing()
    {
        _agent.speed = _chasingSpeed;
        _currentRoarPeriod = _chasingRoarPeriod;
        calmTimer = 0;
        _isChasing = true;
    }

    public void StopChasing()
    {
        _agent.speed = _lurkingSpeed;
        _currentRoarPeriod = _lurkingRoarPeriod;
        _isChasing = false;
    }

    private void PlaySound()
    {
        int randomNumber = Random.Range(0, _humNoises.Length);
        _audioSource.PlayOneShot(_humNoises[randomNumber]);
        _emmiter.EmmitSound(_monsterSoundInfo);
    }
}

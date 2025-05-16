using UnityEngine.Events;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private EmmitingSoundAction OnAction;
    [SerializeField] private EmmitingSoundInfo ActiveSonarEmmition;
    [SerializeField] private float _scanCooldown;
    [SerializeField] private UnityEvent OnDrillLaunched;
    [SerializeField] private UnityEvent OnDrillReturned;

    private float _expiredTime;
    private void Start()
    {
        _expiredTime = _scanCooldown;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && _expiredTime > _scanCooldown)
        {
            OnAction.Invoke(ActiveSonarEmmition);
            _expiredTime = 0;
        }
        _expiredTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnDrillLaunched.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnDrillReturned.Invoke();
        }
    }
}



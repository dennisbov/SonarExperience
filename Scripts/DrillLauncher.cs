using UnityEngine;

[RequireComponent(typeof(BoatMoving))]
public class DrillLauncher : MonoBehaviour
{
    [SerializeField] private SwingingDrill _drill;
    [SerializeField] private LayerMask _miningLayer;
    [SerializeField] private float _miningCheckRadius = 2f;

    private BoatMoving _boatMovement;

    private void Start()
    {
        _boatMovement = GetComponent<BoatMoving>();
    }

    public void LaunchDrill()
    {
        Collider2D miningPosition = Physics2D.OverlapCircle(_boatMovement.transform.position, _miningCheckRadius, _miningLayer);
        if (miningPosition)
        {
            _drill.gameObject.SetActive(true);
            _boatMovement.Teleport(miningPosition.transform.position);
            _boatMovement.enabled = false;
        }
    }

    public void ReturnDrill()
    {
        _drill.StartCoroutine(_drill.ReturnDrill());
        _boatMovement.enabled = true;
    }
}

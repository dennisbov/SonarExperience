using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoatMoving : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private float Hdir;
    private float Vdir;
    private Vector2 direction;

    private void Update()
    {
        Hdir = Input.GetAxis("Horizontal");
        Vdir = Input.GetAxis("Vertical");
        direction = new Vector2(Hdir, Vdir) * _speed;
        rb.velocity = (Vector3)direction;
    }

    public void Teleport(Vector2 position)
    {
        rb.velocity = Vector2.zero;
        transform.position = position;
    }
}

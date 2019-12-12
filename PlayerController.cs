using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 targetPosition = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidbody2D.velocity = (targetPosition * movementSpeed) * Time.deltaTime;
    }
}

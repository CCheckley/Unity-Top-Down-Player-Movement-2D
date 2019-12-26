using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(targetVelocity);
    }

    void Move(Vector2 targetVelocity)
    {        
        rigidbody2D.velocity = (targetVelocity * movementSpeed) * Time.deltaTime;
    }
}

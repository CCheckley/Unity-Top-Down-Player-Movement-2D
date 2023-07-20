using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
// Uncomment this if you want to enforce the object to require the RB2D component to be already attached
// [RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f); // 2D Movement speed to have independant axis speed
    private new Rigidbody2D rigidbody2D; // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        // If RequireComponent is used uncomment the GetComponent and comment the AddComponent out
        // rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        // Rigidbody2D affects physics so any ops on it should happen in FixedUpdate
        // See why here: https://learn.unity.com/tutorial/update-and-fixedupdate#
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }
}

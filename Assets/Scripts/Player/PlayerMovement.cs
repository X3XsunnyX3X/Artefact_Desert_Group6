using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    private Rigidbody2D rb;        // reference to physics component
    private Vector2 moveInput;     // stores which direction keys are pressed


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
                
        moveInput.x = Input.GetAxisRaw("Horizontal");


        moveInput.y = Input.GetAxisRaw("Vertical");


        moveInput = moveInput.normalized;

   
        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}

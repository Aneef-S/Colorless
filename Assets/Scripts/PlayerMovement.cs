
using System;

using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float velocity  = 10f;
    Vector2 movement;
    [SerializeField] float jumpHeight = 10f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundlayer;
    public bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        Collider2D[] ground = Physics2D.OverlapCircleAll(groundCheck.transform.position, groundDistance, groundlayer);
        float horizontal = Input.GetAxisRaw("Horizontal");
       
        movement = new Vector2(horizontal * velocity, rb.velocity.y);
        if(ground.Length > 0) isGrounded = true;
        else isGrounded = false;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           
            movement.y = GetJumpVelocity();
            
           
        }
        Debug.Log(isGrounded);
        rb.velocity = movement;
    }


    private void FixedUpdate()
    {
       
    }

    float GetJumpVelocity()
    {
        return MathF.Sqrt((-2 * rb.gravityScale * Physics2D.gravity.y * jumpHeight));
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public SpriteRenderer sprite;
    public Animator anim;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundLayer;

    private enum MovementState { idle, move, jump }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdateAnimationState();

        // lets uninty know that the player is pressing A or D 
        horizontal = Input.GetAxisRaw("Horizontal");

        //when presssing jump and is on the ground player jumps
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //the longer the player holds down jump button the higher they jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if ((horizontal > 0f) || (horizontal < 0f))
        {
           state = MovementState.move;        
        }
        else
        {
            state = MovementState.idle;
        }

        if (!IsGrounded())
        {
            state = MovementState.jump;
        }
   

        anim.SetInteger("state", (int)state);

    }

    //moves the player when they press A or D on a fixed update time
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    //checks if the player is on the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.3f, groundLayer);
    }

    //responcibal to flip the player in the direction that they are moving
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }
}

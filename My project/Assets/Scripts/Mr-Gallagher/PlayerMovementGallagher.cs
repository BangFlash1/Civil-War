using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGallagher : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public global::System.Single JumpForce { get => JumpForce1; set => JumpForce1 = value; }
    public global::System.Single JumpForce1 { get => jumpForce; set => jumpForce = value; }

    private enum MovementState { idle, running, jumping }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        UpdateAnimationState();        
    }

    private void UpdateAnimationState()
    {
        var scale = transform.localScale;
        scale.x = Mathf.Sign(dirX);

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.localScale = scale;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.localScale = scale;
        }
        else
        {
            state = MovementState.idle;
        }

        if ((rb.velocity.y > .1f) || (rb.velocity.y < -.1f))
        {
            state = MovementState.jumping;

        }
        
        anim.SetInteger("state", (int)state);
    }
}

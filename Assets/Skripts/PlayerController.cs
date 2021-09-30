using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private float moveInput;
    public int maxHP = 100;
    public int currentHP;
    public HealthBar hp;
    private BoxCollider2D _boxCollider2D;

    [SerializeField] private LayerMask platformLayerMask;
    // jumping
    public Vector2 jumpForce = new Vector2(10, 10);
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        hp.MaxHp(maxHP);

    }

    // void jumpController()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
    //     }
    // }

    void Update()
    {

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;

        }
        else
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        // jumpController();

        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(jumpForce, ForceMode2D.Impulse);
        // }

        //for HP example
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
        //     // TakeDamage(20);
        // }

    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        hp.CurrentHp(currentHP);
    }

    // private bool IsGrounded()
    // {
    //     RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,
    //         Vector2.down, .1f, platformLayerMask);
    //
    //     Debug.Log(raycastHit2D.collider);
    //     return raycastHit2D.collider != null;
    // }
}


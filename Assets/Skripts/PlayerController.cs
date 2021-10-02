using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minBoundY = -3.1f, maxBoundY = 0f, minBoundX = -11.6f, maxBoundX = 110f;
    private Vector3 tempPos;
    private float xAxis, yAxis;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
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

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        HandleMovement(xAxis, yAxis);

        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if ( xAxis == 0)
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

        //for HP example
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
    //Movement !!!!!!!!!!!!
    void HandleMovement(float xAxis, float yAxis)
    {
        

        tempPos = transform.position;
        tempPos.x += xAxis * speed * Time.deltaTime;
        tempPos.y += yAxis * speed * Time.deltaTime;
        

        if (tempPos.x < minBoundX)
            tempPos.x = minBoundX;
        if (tempPos.x > maxBoundX)
            tempPos.x = maxBoundX;

        if (tempPos.y < minBoundY)
            tempPos.y = minBoundY;
        if (tempPos.y > maxBoundY)
            tempPos.y = maxBoundY;
        transform.position = tempPos;

    }

    void TakeDamage(int damage) {

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


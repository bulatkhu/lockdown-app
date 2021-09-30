using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        hp.MaxHp(maxHP);
        
    }

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

        //for HP example
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        hp.CurrentHp(currentHP);
    }
}


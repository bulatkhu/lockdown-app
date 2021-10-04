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
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int maxHP = 100;
    public int currentHP;
    public HealthBar hp;
    AudioSource audioSource;
    

  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        hp.MaxHp(maxHP);
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        HandleMovement(xAxis, yAxis);

        if (xAxis == 0)
        {
            
            animator.SetBool("isRunning", false);
            audioSource.Stop();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            

            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
            StepSound();
        }
        else 
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
            StepSound();
        }

        
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

    public void TakeDamage(int damage)
    {

        currentHP -= damage;
        hp.CurrentHp(currentHP);
    }
    
  void StepSound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
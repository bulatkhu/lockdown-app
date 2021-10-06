using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minBoundY = -3.1f, maxBoundY = 0f, minBoundX = -11.6f, maxBoundX = 110f;
    private float xAxis, yAxis;
    private Vector3 tempPos;
    private Vector3 tempScale;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int maxHP = 100;
    public int currentHP;
    public HealthBar hp;
    AudioSource audioSource;
    [SerializeField]
    private float shootWaitTime = 0.5f;
    private float waitBeforeShooting;
    [SerializeField]
    private float moveWaitTime = 0.3f;
    private float waitBeforeMoving;
    private bool canMove = true;
    private Shooting shooting;
    //public bool shoot;
    //public CoinPicker bulletscore;

    //private Animation anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        hp.MaxHp(maxHP);
        audioSource = GetComponent<AudioSource>();
        //anim = GetComponent<Animation>();
        shooting = GetComponent<Shooting>();
        //bulletscore = GetComponent<CoinPicker>().MinusBullet();



    }
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        HandleMovement();
       
        Shooting();
        CheckIfCanMove();
        // FaceDirection(true);

    
 
        if (!canMove)
            return;

        if (xAxis > 0)
        {
            animator.SetBool("isRunning", true);
            FaceDirection(true);
            StepSound();
        }

        if (xAxis < 0)
        {
            animator.SetBool("isRunning", true);
            FaceDirection(false);
            StepSound();

        }
        if (xAxis == 0)
        {
            animator.SetBool("isRunning", false);
            audioSource.Stop();
        }
        /*if (xAxis == 0)
        { 
            animator.SetBool("isRunning", false);
            audioSource.Stop();

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRunning", true);
            //spriteRenderer.flipX = true;
            //tempScale.x = -1f;
           FaceDirection(false);
            StepSound();
        }
        else
        {
            animator.SetBool("isRunning", true);
            //spriteRenderer.flipX = false;
            //tempScale.x = 1f;
            //FaceDirection(true);
            StepSound();
        }
        */
    }

    public void FaceDirection(bool faceRight)
    {
        tempScale = transform.localScale;
        if (faceRight)
            tempScale.x = 1f;
        else
            tempScale.x = -1f;

        transform.localScale = tempScale;
    }

    void StopMovement()
    {
        canMove = false;
        waitBeforeMoving = Time.time + moveWaitTime;
    }

    public void Shoot()
    {
        //shoot = true;
        waitBeforeShooting = Time.time + shootWaitTime;
        StopMovement();
        animator.Play("Shooting");
        shooting.Shoot(transform.localScale.x);
        

    }

    void CheckIfCanMove()
    {
        if (Time.time > waitBeforeMoving)
            canMove = true;
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > waitBeforeShooting)
                Shoot();
            GetComponent<CoinPicker>().MinusBullet();

           //bulletscore = bulletscore - 1;
        }

    }
    //Movement !!!!!!!!!!!!
    void HandleMovement()
    {
       float xAxis = Input.GetAxis("Horizontal");
       float yAxis = Input.GetAxis("Vertical");

        tempPos = transform.position;
        tempPos.x += xAxis * speed * Time.deltaTime;
        tempPos.y += yAxis * speed * Time.deltaTime;

        if (!canMove)
            return;

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
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Death()
    {
        animator.Play("Death");

    }
}

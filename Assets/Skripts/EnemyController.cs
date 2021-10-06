using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed = 2f;
    private Vector3 tempPos;
    [SerializeField]
    private float stopDistance = 1.5f;

    //for atack
    [SerializeField]
    private float attackWait = 2.5f;
    private float attackTimer;

    [SerializeField]
    private float attackFinishedWaitTime = 0.5f;
    private float attackFinishedTimer;

    SpriteRenderer m_SpriteRenderer;
    GameObject player;
    //public int maxHP = 100;
    //public int currentHP;
   // public EnemyHealth hp;
    GameObject enemy;

    public bool ifAttackCalled = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player");
        //enemy = GameObject.FindWithTag("Enemy");
        //currentHP = maxHP;
        //enemy.GetComponent<EnemyHealth>().MaxHp(maxHP);
    }

    private void Update()
    {

        SearchPlayer();
    }

    void SearchPlayer()
    {
        if (!target)
            return;

        if (Vector3.Distance(transform.position, target.position) > stopDistance)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            CheckIfAttackFinished();
            Attack();
        }
    }


    void CheckIfAttackFinished()
    {
        if (Time.time > attackFinishedTimer)
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.blue;
            ifAttackCalled = false;
        }
    }

    public void Attack()
    {

        if (Time.time > attackTimer)
        {
            ifAttackCalled = true;
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.red;
            player.GetComponent<PlayerController>().TakeDamage(10);

   
            attackFinishedTimer = Time.time + attackFinishedWaitTime;
            attackTimer = Time.time + attackWait;
            
        }
        
        
    }


}

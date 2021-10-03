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
  

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {

        SearchPlayer();
    }

    void SearchPlayer()
    {
        //if (!target)
            //return;

        if (Vector3.Distance(transform.position, target.position) > stopDistance)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


}

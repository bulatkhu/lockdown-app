using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCoin : MonoBehaviour
{

  
    private Vector3 posA;

    
    private Vector3 posB;

    [SerializeField]
    private float speed;

    private Vector3 nextPos;
    [SerializeField]
    private Transform childtransform;
    [SerializeField]
    private Transform transformB;

    private void Start()
    {
        posA = childtransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        childtransform.localPosition = Vector3.MoveTowards(childtransform.localPosition, nextPos, speed * Time.deltaTime);
        if (Vector3.Distance(childtransform.localPosition, nextPos) <= 0.1)
        {
            ChangePosition();
        }
    }
     void ChangePosition()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}

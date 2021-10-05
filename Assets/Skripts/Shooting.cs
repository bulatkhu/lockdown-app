using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnposition;

    public void Shoot(float facingDirection)
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnposition.position, Quaternion.identity);
        if (facingDirection < 0)
            newBullet.GetComponent<Bullet>().SetNegativeSpeed();
        
    }

}

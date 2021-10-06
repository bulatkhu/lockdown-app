using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField]
    private Slider slider;
 
    private bool enemyDied;

    private void Update()
    {
        if (enemyDied)
            return;
        //if (slider.value == 0)
       // { 
       //     Death();
       // }
    }
    /*public void MaxHp(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void CurrentHp(float health)
    {
        slider.value = health;

    }*/
    void Death()
    {
        enemyDied = true;
        Invoke("DestroyAfterDead", 2f);
        DestroyAfterDead();
    }
    void DestroyAfterDead()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damageAmmount)
    {
        if (health <= 0)
            return;
        health -= damageAmmount;
        if(health <= 0f)
        {
            health = 0;
            //kill enemy
            Death();
        }

        slider.value = health; 
    }
}
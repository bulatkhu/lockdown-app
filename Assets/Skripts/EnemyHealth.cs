using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    //public EnemyHealth hp;
    public Slider slider;
    //GameObject enemy;
    private void Start()
    {
        //enemy = GameObject.FindWithTag("Enemy");
        currentHP = maxHP;
        MaxHp(maxHP);
    }
    private void Update()
    {
        if (slider.value == 0)
        {

            Death();

        }
    }
    public void MaxHp(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void CurrentHp(int health)
    {
        slider.value = health;

    }
    void Death()
    {

        Invoke("DestroyAfterDead", 2f);
        DestroyAfterDead();
    }

    void DestroyAfterDead()
    {
        Destroy(gameObject);
    }
}
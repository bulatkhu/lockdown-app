using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    
    public Slider slider;
    GameObject player;
    public IEnumerator coroutine;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }
    private void Update()
    {
        if (slider.value == 0)
        {
            player.GetComponent<PlayerController>().Death();
            coroutine = ChangeSceneToGameOver();
            StartCoroutine(coroutine);

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

    public IEnumerator ChangeSceneToGameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");

    }
    
}

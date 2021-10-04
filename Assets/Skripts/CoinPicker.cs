using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPicker : MonoBehaviour
{
    public Text MyScoreText;
    private int scoreNumber;


    private void Start()
    {
        scoreNumber = 0;
        MyScoreText.text = "Coins: " + scoreNumber;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            scoreNumber++;
            Destroy(collision.gameObject);
            MyScoreText.text = "Coins: " + scoreNumber;
        }
    }



}

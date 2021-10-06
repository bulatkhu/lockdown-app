using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    public TextMeshProUGUI MyScoreText;
    public int scoreNumber;

 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            scoreNumber++;
            Destroy(collision.gameObject);
            MyScoreText.text =  scoreNumber.ToString();
        }
       /* if (GetComponent<PlayerController>().shoot)
        {
            scoreNumber = scoreNumber - 1;
            MyScoreText.text = "Coins: " + scoreNumber.ToString();
        }*/
    }

    public void MinusBullet()
    {
        scoreNumber = scoreNumber - 1;
        MyScoreText.text =  scoreNumber.ToString();
    }

    
}

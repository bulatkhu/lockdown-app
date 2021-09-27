using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text coinsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();

            Debug.Log("Got more point = " + coins);

            Destroy(collision.gameObject);
        }
    }

}

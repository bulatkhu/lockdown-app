using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private Text myOutPutText;
    private Button myButton;
        

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController started!");
        myOutPutText = GameObject.Find("output text").GetComponent<Text>();
        myOutPutText.text = "ладно, я потерплю";
        // myOutPutText.color = Color.red;
        myButton = GameObject.Find("MyButton").GetComponent<Button>();
        myButton.onClick.AddListener(() => ButtonClicked(myButton));

    }

    void ButtonClicked(Button button)
    {
        Debug.Log("my button was clicked" + button);
        myOutPutText.text = "епть!";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

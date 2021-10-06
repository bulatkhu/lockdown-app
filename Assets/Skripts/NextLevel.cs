using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{


    void Update()
    {
        Debug.Log(transform.position.x);
        Debug.Log("transform x, {0}");
        if (transform.position.x > 109)
        {
            SceneManager.LoadScene(2);
        }
    }
    
}

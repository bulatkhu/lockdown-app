using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{


    void Update()
    {
        if (transform.position.x > 169)
        {
            SceneManager.LoadScene("Map");
        }
    }
    
}

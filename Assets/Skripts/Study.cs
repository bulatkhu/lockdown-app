using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Study : MonoBehaviour
{
     Canvas study;
    public IEnumerator coroutine;

    void Start()
    {
        study = GameObject.Find("Study Canvas").GetComponent<Canvas>();
        coroutine = DestroyText();
        StartCoroutine(coroutine);
    }

    public IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(6);
        study.enabled = false;

    }
}

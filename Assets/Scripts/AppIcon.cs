using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DraggableObject))]
public class AppIcon : MonoBehaviour
{
    public Window windowApp;
    private int clicCount;
    void Start()
    {
        GetComponent<DraggableObject>().isCellMove = true;
        clicCount = 0;
    }

    public void OnClic()
    {
        if (clicCount == 0)
        {
            ++clicCount;
            StartCoroutine(TimeToDoubleClic());
        }
        else
        {
            clicCount = 0;
            
            string appName   = transform.GetChild(0).GetComponent<TMP_Text>().text;
            Sprite appSprite = transform.GetChild(1).GetComponent<Image>().sprite;

           windowApp.Open(appName, appSprite);
        }
    }

    IEnumerator TimeToDoubleClic()
    {
        yield return new WaitForSeconds(0.4f);
        clicCount = 0;
    }
}

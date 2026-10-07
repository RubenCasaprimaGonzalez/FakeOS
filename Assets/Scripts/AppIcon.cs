using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DraggableObject))]
public class AppIcon : MonoBehaviour
{
    public GameObject windowApp;
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
            WindowController.Ins.Open(windowApp);
            clicCount = 0;
        }
    }

    IEnumerator TimeToDoubleClic()
    {
        yield return new WaitForSeconds(0.4f);
        clicCount = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public static WindowController Ins;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }
    }

    public void Close(GameObject windowsObject)
    {
        windowsObject.SetActive(false);
    }
    
    public void Open(GameObject windowsObject)
    {
        windowsObject.SetActive(true);
    }
}

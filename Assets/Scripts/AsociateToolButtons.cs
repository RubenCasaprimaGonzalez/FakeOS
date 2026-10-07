using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsociateToolButtons : AsocitedButton
{
    private Window asociateWindow;

    private void Start()
    {
        asociateWindow = asociateGameObject.GetComponent<Window>();
    }

    public void Close()
    {
        asociateWindow.Close();
    }

    public void Focus()
    {
        asociateWindow.TryToGainFocus();
    }
}

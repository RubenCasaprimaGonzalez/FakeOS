using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsocitedButton : MonoBehaviour
{
    public GameObject asociateGameObject;
    
    public void Remove()
    {
        Destroy(asociateGameObject);
        Destroy(gameObject);
    }

    virtual public void OnClic()
    {
        throw new System.NotImplementedException();
    }
}

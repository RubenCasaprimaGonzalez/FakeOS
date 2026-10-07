using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsocitedButton : MonoBehaviour
{
    public GameObject asociateGameObject;
    
    virtual public void Remove()
    {
        Destroy(asociateGameObject);
        Destroy(gameObject);
    }

    public void OnClic()
    {
        asociateGameObject.transform.SetAsLastSibling();
    }
}

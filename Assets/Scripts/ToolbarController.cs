using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] private GameObject buttonToolBarPrefab;
    public static ToolbarController Ins;

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
    public GameObject NewButton(GameObject windowAsociate,  string name, Sprite icon)
    {
        GameObject newToolButton = Instantiate(buttonToolBarPrefab, transform);
        newToolButton.transform.GetChild(1).GetComponent<TMP_Text>().text = name;
        newToolButton.transform.GetChild(2).GetComponent<Image>().sprite  = icon;
        newToolButton.GetComponent<AsocitedButton>().asociateGameObject = windowAsociate;
        return newToolButton;
    }
}

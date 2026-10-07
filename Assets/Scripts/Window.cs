using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Window : MonoBehaviour
{
   public GameObject toolButton;

   public void Open(string windowName, Sprite windowSprite)
   {
      gameObject.SetActive(true);
      transform.GetChild(0).GetComponent<TMP_Text>().text = windowName;
      transform.SetAsLastSibling();
      
      if (toolButton == null)
      {
         toolButton = ToolbarController.Ins.NewButton(gameObject, windowName, windowSprite);
      }
   }

   public void Close()
   {
      gameObject.SetActive(false);
      Destroy(toolButton);
   }
   
   public void OnClic()
   {
      Debug.Log("si");
      transform.SetAsLastSibling();
   }
}

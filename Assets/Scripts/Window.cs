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

   private void Focus()
   {
      if (!gameObject.activeSelf)
      {
         gameObject.SetActive(true);
      }
      transform.SetAsLastSibling();
   }
   
   public void OnClic()
   {
      Focus();
   }

   public void Minimize()
   {
      gameObject.SetActive(false);
   }

   public void TryToGainFocus()
   {
      if (transform.GetSiblingIndex() + 1 != transform.parent.childCount)
      {
         Focus();
      }
      else
      {
         Minimize();
      }
   }
}

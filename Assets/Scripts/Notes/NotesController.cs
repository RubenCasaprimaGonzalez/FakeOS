using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotesController : MonoBehaviour
{
   [SerializeField] private GameObject noteButtomPrefab;
   [SerializeField] private Transform  noteButtomParent;
   [SerializeField] private GameObject inputFieldPrefab;
   [SerializeField] private Transform  inputFieldParent;
   private int notesCount = 1;

   public void NewNote()
   {
      GameObject newNote = Instantiate(noteButtomPrefab, noteButtomParent);
      newNote.transform.SetSiblingIndex(notesCount);
      newNote.transform.GetChild(0).GetComponent<TMP_Text>().text = "Note" + ++notesCount;
      GameObject newInputField = Instantiate(inputFieldPrefab, inputFieldParent);
      newNote.GetComponent<ButtonNotesController>().asociateGameObject = newInputField;
   }
}

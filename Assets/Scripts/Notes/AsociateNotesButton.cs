using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsociateNotesButton : AsocitedButton
{
    public int noteCount;
    public override void Remove()
    {
        transform.parent.parent.GetComponent<NotesController>().RemoveNote(noteCount);
        base.Remove();
    }
}

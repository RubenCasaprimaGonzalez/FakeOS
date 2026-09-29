using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour
{
    private GameObject storedObject;
    private DraggableObject _draggable;
    public bool IsOccupied()
    {
        return storedObject != null;
    }

    public void StoreObject(GameObject obj)
    {
        storedObject = obj;

        if (obj != null)
        {
            RectTransform  objRect = obj.GetComponent<RectTransform>();
            RectTransform slotRect =     GetComponent<RectTransform>();

            objRect.anchoredPosition = slotRect.anchoredPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _draggable = GridManager.ins.dragObject;

        if (_draggable != null)
        {
            _draggable.SetHoveredSlot(this);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        _draggable = GridManager.ins.dragObject;

        if (_draggable != null)
        {
            if (_draggable.hoveredSlot != null)
            {
                _draggable.currentSlot = _draggable.hoveredSlot;
            }
            _draggable.SetHoveredSlot(null);
        }
    }
}
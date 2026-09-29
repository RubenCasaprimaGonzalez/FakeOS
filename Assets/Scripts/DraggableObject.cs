using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public GridSlot currentSlot;
    public GridSlot hoveredSlot;

    private Vector2 startPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GridManager.ins.dragObject = this;
        startPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (hoveredSlot != null && !hoveredSlot.IsOccupied())
        {
            hoveredSlot.StoreObject(gameObject);
            if(currentSlot != null) currentSlot.StoreObject(null);  // Libera el slot inicial
            currentSlot = hoveredSlot;
        }
        else
        {
            currentSlot.StoreObject(gameObject);
        }

        hoveredSlot = null;
        GridManager.ins.dragObject = null;
    }

    public void SetHoveredSlot(GridSlot slot)
    {
        hoveredSlot = slot;
    }
}
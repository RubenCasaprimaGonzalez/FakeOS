using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private GridSlot previousSlot;
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
            if(previousSlot != null) previousSlot.StoreObject(null);  // Libera el slot inicial
            currentSlot = hoveredSlot;
        }
        else
        {
            currentSlot.StoreObject(gameObject);
        }

        hoveredSlot = null;
        previousSlot = currentSlot;
        GridManager.ins.dragObject = null;
    }

    public void SetHoveredSlot(GridSlot slot)
    {
        hoveredSlot = slot;
    }
}
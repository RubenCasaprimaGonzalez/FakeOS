using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private GridSlot previousSlot;
    [HideInInspector] public GridSlot currentSlot;
    [HideInInspector] public GridSlot hoveredSlot;

    [HideInInspector] public bool isCellMove;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GridManager.ins.dragObject = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isCellMove) return;
        
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
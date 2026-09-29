using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager ins;
    
    [Header("Grid")]
    [SerializeField] private int columns = 8;
    [SerializeField] private int rows = 5;

    [Header("Cell Size")]
    [SerializeField] private float cellWidth = 150f;
    [SerializeField] private float cellHeight = 150f;

    [Header("Slot")]
    [SerializeField] private GameObject slotPrefab;
    
    private RectTransform gridRect;

    public DraggableObject dragObject;

    private void Awake()
    {
        if (ins == null) ins = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gridRect = GetComponent<RectTransform>();
        
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject slot = Instantiate(slotPrefab, gridRect);
                
                RectTransform slotRect = slot.GetComponent<RectTransform>();

                slotRect.anchoredPosition = new Vector2(
                    x * cellWidth,
                    y * cellHeight
                );

                slotRect.sizeDelta = new Vector2(
                    cellWidth,
                    cellHeight
                );

                slot.name = $"Slot_{x}_{y}";
            }
        }
    }
}
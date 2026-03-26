using UnityEngine;
using UnityEngine.EventSystems;

public class TileInputHandler : MonoBehaviour, IPointerClickHandler
{
    public Tile tile;
    public GridManager gridManager;

    private Tile firstSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gridManager == null || tile == null) return;

        if (firstSelected == null)
        {
            firstSelected = tile;
            // Visual feedback for selection could be added here
        }
        else if (firstSelected == tile)
        {
            // Deselect
            firstSelected = null;
        }
        else
        {
            // Try to swap
            if (gridManager.IsAdjacent(firstSelected, tile))
            {
                gridManager.StartSwap(firstSelected, tile);
            }
            firstSelected = null;
        }
    }
}

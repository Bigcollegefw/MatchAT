using UnityEngine;
using UnityEngine.EventSystems;

public class TileInputHandler : MonoBehaviour, IPointerClickHandler
{
    public Tile tile;

    private Tile firstSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        var gridManager = GridManager.Instance;
        if (gridManager == null || tile == null) return;

        if (firstSelected == null)
        {
            firstSelected = tile;
        }
        else if (firstSelected == tile)
        {
            firstSelected = null;
        }
        else
        {
            if (gridManager.IsAdjacent(firstSelected, tile))
            {
                gridManager.StartSwap(firstSelected, tile);
            }
            firstSelected = null;
        }
    }
}

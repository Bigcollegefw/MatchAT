using UnityEngine;
using UnityEngine.EventSystems;

public class TileInputHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Tile tile;

    // Shared selection state across all tile instances.
    private static Tile s_firstSelected;

    private Vector2 m_dragStartPosition;
    private bool m_dragging;

    private const float DragThreshold = 20f;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Ignore click events that originated from a drag.
        if (m_dragging) return;

        HandleSelection();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_dragStartPosition = eventData.pressPosition;
        m_dragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mark as dragging once the pointer moves beyond the threshold.
        if (!m_dragging && (eventData.position - m_dragStartPosition).magnitude >= DragThreshold)
        {
            m_dragging = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!m_dragging) return;

        Vector2 delta = eventData.position - m_dragStartPosition;
        Tile neighbor = GetNeighborInDirection(delta);

        if (neighbor != null)
        {
            var gridManager = GridManager.Instance;
            if (gridManager != null && gridManager.IsAdjacent(tile, neighbor))
            {
                s_firstSelected = null;
                gridManager.StartSwap(tile, neighbor);
            }
        }

        m_dragging = false;
    }

    /// <summary>Determines the neighboring tile in the dominant drag direction.</summary>
    private Tile GetNeighborInDirection(Vector2 delta)
    {
        var gridManager = GridManager.Instance;
        if (gridManager == null || tile == null) return null;

        int dx = 0;
        int dy = 0;

        if (Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
            dx = delta.x > 0 ? 1 : -1;
        else
            dy = delta.y > 0 ? 1 : -1;

        return gridManager.GetTile(tile.x + dx, tile.y + dy);
    }

    /// <summary>Handles click-based two-tap selection and swap.</summary>
    private void HandleSelection()
    {
        var gridManager = GridManager.Instance;
        if (gridManager == null || tile == null) return;

        if (s_firstSelected == null)
        {
            s_firstSelected = tile;
        }
        else if (s_firstSelected == tile)
        {
            s_firstSelected = null;
        }
        else
        {
            if (gridManager.IsAdjacent(s_firstSelected, tile))
            {
                gridManager.StartSwap(s_firstSelected, tile);
            }
            s_firstSelected = null;
        }
    }
}

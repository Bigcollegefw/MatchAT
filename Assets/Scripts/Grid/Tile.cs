using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public int tileTypeIndex;
    public Image image;
    public ScriptableTileConfig tileConfig;

    private void Start()
    {
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (tileConfig != null && image != null)
        {
            var tileType = tileConfig.GetTileType(tileTypeIndex);
            image.color = tileType.color;
        }
    }

    public void SetType(int typeIndex, ScriptableTileConfig config)
    {
        tileTypeIndex = typeIndex;
        tileConfig = config;
        UpdateVisual();
    }
}

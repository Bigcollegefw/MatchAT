using UnityEngine;

[CreateAssetMenu(fileName = "GridConfig", menuName = "MatchThree/GridConfig")]
public class GridConfig : ScriptableObject
{
    public int gridWidth = 8;
    public int gridHeight = 8;
    public float tileSize = 100f;
    public float tileSpacing = 10f;
    public Vector2 gridOffset = Vector2.zero;
}

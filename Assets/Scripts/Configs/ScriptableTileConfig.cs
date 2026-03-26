using UnityEngine;

[CreateAssetMenu(fileName = "TileConfig", menuName = "MatchThree/TileConfig")]
public class ScriptableTileConfig : ScriptableObject
{
    [System.Serializable]
    public class TileType
    {
        public string id;
        public Color color;
        public Sprite sprite;
    }

    public TileType[] tileTypes = new TileType[6];

    private void Reset()
    {
        tileTypes = new TileType[6];
        string[] names = { "Red", "Blue", "Green", "Yellow", "Purple", "Orange" };
        Color[] colors = {
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            new Color(0.6f, 0.2f, 0.8f),
            new Color(1f, 0.5f, 0f)
        };
        for (int i = 0; i < 6; i++)
        {
            tileTypes[i] = new TileType { id = names[i], color = colors[i] };
        }
    }

    public TileType GetRandomTileType()
    {
        return tileTypes[Random.Range(0, tileTypes.Length)];
    }

    public TileType GetTileType(int index)
    {
        if (index < 0 || index >= tileTypes.Length) return tileTypes[0];
        return tileTypes[index];
    }
}

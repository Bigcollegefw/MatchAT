using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public ScriptableTileConfig tileConfig;
    public GridConfig gridConfig;
    public GameConfig gameConfig;

    public GameObject tilePrefab;
    public Transform gridContainer;

    private Tile[,] tiles;
    private bool isProcessing = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        tiles = new Tile[gridConfig.gridWidth, gridConfig.gridHeight];

        for (int x = 0; x < gridConfig.gridWidth; x++)
        {
            for (int y = 0; y < gridConfig.gridHeight; y++)
            {
                CreateTile(x, y);
            }
        }

        RemoveInitialMatches();
    }

    void CreateTile(int x, int y)
    {
        var go = Instantiate(tilePrefab, gridContainer);
        go.transform.localPosition = GetTilePosition(x, y);

        var tile = go.GetComponent<Tile>();
        tile.x = x;
        tile.y = y;
        tile.tileConfig = tileConfig;
        tile.SetType(Random.Range(0, tileConfig.tileTypes.Length), tileConfig);

        var inputHandler = go.GetComponent<TileInputHandler>();
        if (inputHandler != null)
            inputHandler.tile = tile;

        tiles[x, y] = tile;
    }

    public Vector3 GetTilePosition(int x, int y)
    {
        float offsetX = -(gridConfig.gridWidth - 1) * (gridConfig.tileSize + gridConfig.tileSpacing) / 2f;
        float offsetY = -(gridConfig.gridHeight - 1) * (gridConfig.tileSize + gridConfig.tileSpacing) / 2f;
        return new Vector3(
            x * (gridConfig.tileSize + gridConfig.tileSpacing) + offsetX + gridConfig.gridOffset.x,
            y * (gridConfig.tileSize + gridConfig.tileSpacing) + offsetY + gridConfig.gridOffset.y,
            0
        );
    }

    void RemoveInitialMatches()
    {
        bool hasMatches;
        int iterations = 0;
        const int maxIterations = 100;

        do
        {
            hasMatches = false;
            for (int x = 0; x < gridConfig.gridWidth; x++)
            {
                for (int y = 0; y < gridConfig.gridHeight; y++)
                {
                    if (x >= 2 &&
                        tiles[x, y].tileTypeIndex == tiles[x - 1, y].tileTypeIndex &&
                        tiles[x, y].tileTypeIndex == tiles[x - 2, y].tileTypeIndex)
                    {
                        tiles[x, y].SetType(Random.Range(0, tileConfig.tileTypes.Length), tileConfig);
                        hasMatches = true;
                    }
                    if (y >= 2 &&
                        tiles[x, y].tileTypeIndex == tiles[x, y - 1].tileTypeIndex &&
                        tiles[x, y].tileTypeIndex == tiles[x, y - 2].tileTypeIndex)
                    {
                        tiles[x, y].SetType(Random.Range(0, tileConfig.tileTypes.Length), tileConfig);
                        hasMatches = true;
                    }
                }
            }
            iterations++;
        } while (hasMatches && iterations < maxIterations);
    }

    public Tile GetTile(int x, int y)
    {
        if (x < 0 || x >= gridConfig.gridWidth || y < 0 || y >= gridConfig.gridHeight)
            return null;
        return tiles[x, y];
    }

    public bool IsAdjacent(Tile a, Tile b)
    {
        int dx = Mathf.Abs(a.x - b.x);
        int dy = Mathf.Abs(a.y - b.y);
        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
    }

    public void StartSwap(Tile a, Tile b)
    {
        if (isProcessing) return;
        StartCoroutine(SwapTiles(a, b));
    }

    System.Collections.IEnumerator SwapTiles(Tile a, Tile b)
    {
        isProcessing = true;

        Vector3 posA = a.transform.localPosition;
        Vector3 posB = b.transform.localPosition;

        float duration = 0.2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            a.transform.localPosition = Vector3.Lerp(posA, posB, t);
            b.transform.localPosition = Vector3.Lerp(posB, posA, t);
            yield return null;
        }

        (tiles[a.x, a.y], tiles[b.x, b.y]) = (tiles[b.x, b.y], tiles[a.x, a.y]);
        (a.x, a.y, b.x, b.y) = (b.x, b.y, a.x, a.y);

        var matches = MatchDetector.FindMatches(tiles, gridConfig.gridWidth, gridConfig.gridHeight);

        if (matches.Count > 0)
        {
            yield return StartCoroutine(CascadeManager.ProcessCascade(
                tiles, gridConfig, tileConfig, gameConfig, this, ScoreManager.Instance));
        }
        else
        {
            elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                a.transform.localPosition = Vector3.Lerp(posB, posA, t);
                b.transform.localPosition = Vector3.Lerp(posA, posB, t);
                yield return null;
            }

            (tiles[a.x, a.y], tiles[b.x, b.y]) = (tiles[b.x, b.y], tiles[a.x, a.y]);
            (a.x, a.y, b.x, b.y) = (b.x, b.y, a.x, a.y);
        }

        isProcessing = false;
    }

    public void ResetGrid()
    {
        foreach (Transform child in gridContainer)
        {
            Destroy(child.gameObject);
        }
        CreateGrid();
    }
}

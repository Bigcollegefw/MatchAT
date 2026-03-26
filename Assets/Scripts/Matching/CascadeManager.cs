using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CascadeManager
{
    public static IEnumerator ProcessCascade(
        Tile[,] tiles,
        GridConfig gridConfig,
        ScriptableTileConfig tileConfig,
        GameConfig gameConfig,
        GridManager gridManager,
        ScoreManager scoreManager)
    {
        int chainLevel = 0;
        var matches = MatchDetector.FindMatches(tiles, gridConfig.gridWidth, gridConfig.gridHeight);

        while (matches.Count > 0)
        {
            int roundScore = 0;
            foreach (var match in matches)
            {
                roundScore += MatchClearer.CalculateMatchScore(
                    match.matchLength,
                    gameConfig,
                    chainLevel);
            }
            scoreManager.AddScore(roundScore);

            MatchClearer.ClearMatches(matches);

            yield return new WaitForSeconds(0.2f);

            DropTiles(tiles, gridConfig.gridWidth, gridConfig.gridHeight, gridManager);

            yield return new WaitForSeconds(0.2f);

            FillEmptySpaces(tiles, gridConfig, tileConfig, gridManager, gridManager);

            yield return new WaitForSeconds(0.2f);

            chainLevel++;
            matches = MatchDetector.FindMatches(tiles, gridConfig.gridWidth, gridConfig.gridHeight);
        }
    }

    static void DropTiles(Tile[,] tiles, int width, int height, GridManager gridManager)
    {
        for (int x = 0; x < width; x++)
        {
            int writeY = 0;
            for (int readY = 0; readY < height; readY++)
            {
                if (tiles[x, readY] != null)
                {
                    if (writeY != readY)
                    {
                        tiles[x, writeY] = tiles[x, readY];
                        tiles[x, readY] = null;
                        tiles[x, writeY].y = writeY;

                        Vector3 targetPos = gridManager.GetTilePosition(x, writeY);
                        tiles[x, writeY].transform.localPosition = targetPos;
                    }
                    writeY++;
                }
            }
        }
    }

    static void FillEmptySpaces(Tile[,] tiles, GridConfig gridConfig, ScriptableTileConfig tileConfig, GridManager gridManager, MonoBehaviour caller)
    {
        for (int x = 0; x < gridConfig.gridWidth; x++)
        {
            for (int y = 0; y < gridConfig.gridHeight; y++)
            {
                if (tiles[x, y] == null)
                {
                    var go = UnityEngine.Object.Instantiate(gridManager.tilePrefab, gridManager.gridContainer);
                    go.transform.localPosition = gridManager.GetTilePosition(x, gridConfig.gridHeight + 1);

                    var tile = go.GetComponent<Tile>();
                    tile.x = x;
                    tile.y = y;
                    tile.tileConfig = tileConfig;
                    tile.SetType(Random.Range(0, tileConfig.tileTypes.Length), tileConfig);

                    var inputHandler = go.GetComponent<TileInputHandler>();
                    if (inputHandler != null)
                        inputHandler.tile = tile;

                    tiles[x, y] = tile;

                    Vector3 targetPos = gridManager.GetTilePosition(x, y);
                    caller.StartCoroutine(AnimateFall(go, targetPos));
                }
            }
        }
    }

    static IEnumerator AnimateFall(GameObject go, Vector3 targetPos)
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Vector3 startPos = go.transform.localPosition;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            go.transform.localPosition = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }
    }
}

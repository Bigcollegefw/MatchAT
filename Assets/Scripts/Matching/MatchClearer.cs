using System.Collections.Generic;
using UnityEngine;

public static class MatchClearer
{
    public static void ClearMatches(List<MatchDetector.Match> matches)
    {
        var tilesToClear = new HashSet<Tile>();
        foreach (var match in matches)
        {
            foreach (var tile in match.tiles)
            {
                tilesToClear.Add(tile);
            }
        }

        foreach (var tile in tilesToClear)
        {
            if (tile != null)
            {
                UnityEngine.Object.Destroy(tile.gameObject);
            }
        }
    }

    public static int CalculateMatchScore(int matchLength, float cascadeMultiplier, int chainLevel)
    {
        int baseScore = matchLength switch
        {
            3 => 100,
            4 => 200,
            _ => 500
        };

        if (chainLevel > 0)
        {
            baseScore = Mathf.RoundToInt(baseScore * Mathf.Pow(cascadeMultiplier, chainLevel));
        }

        return baseScore;
    }
}

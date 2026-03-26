using System.Collections.Generic;
using UnityEngine;

public static class MatchDetector
{
    public struct Match
    {
        public List<Tile> tiles;
        public int matchLength;
    }

    public static List<Match> FindMatches(Tile[,] grid, int width, int height)
    {
        var matches = new List<Match>();

        for (int y = 0; y < height; y++)
        {
            int x = 0;
            while (x < width)
            {
                var match = new Match { tiles = new List<Tile>(), matchLength = 1 };
                match.tiles.Add(grid[x, y]);
                int nextX = x + 1;

                while (nextX < width &&
                       grid[nextX, y] != null &&
                       grid[nextX, y].tileTypeIndex == grid[x, y].tileTypeIndex)
                {
                    match.tiles.Add(grid[nextX, y]);
                    match.matchLength++;
                    nextX++;
                }

                if (match.matchLength >= 3)
                    matches.Add(match);

                x = nextX;
            }
        }

        for (int x = 0; x < width; x++)
        {
            int y = 0;
            while (y < height)
            {
                var match = new Match { tiles = new List<Tile>(), matchLength = 1 };
                match.tiles.Add(grid[x, y]);
                int nextY = y + 1;

                while (nextY < height &&
                       grid[x, nextY] != null &&
                       grid[x, nextY].tileTypeIndex == grid[x, y].tileTypeIndex)
                {
                    match.tiles.Add(grid[x, nextY]);
                    match.matchLength++;
                    nextY++;
                }

                if (match.matchLength >= 3)
                    matches.Add(match);

                y = nextY;
            }
        }

        return matches;
    }
}

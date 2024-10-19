namespace Runtime
{
    using System;
    using UnityEngine;

    public class Board : MonoBehaviour
    {
        public Transform         TilesParent;
        public         GameObject TilePrefab;
        private static int        Rows    = 8;
        private static int        Columns = 8;

        private Tile[,] runtimeTiles = new Tile[Board.Rows, Board.Columns];

        private void Awake() { this.SpawnTiles(); }

        private void SpawnTiles()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    var tile = Instantiate(this.TilePrefab, this.TilesParent).GetComponent<Tile>();
                    tile.Row    = row;
                    tile.Column = column;
                    this.runtimeTiles[row, column]   = tile.GetComponent<Tile>();
                    this.runtimeTiles[row, column].OnTileClicked += this.OnTileClicked;
                }
            }
        }

        private void OnTileClicked(int row, int column)
        {
            this.ShowDistanceNeighbours(row, column);
        }

        private void ShowDistanceNeighbours(int row, int column)
        {
            for (var r = row - 1; r <= row + 1; r++)
            {
                for (var c = column - 1; c <= column + 1; c++)
                {
                    if (r < 0 || r >= Rows || c < 0 || c >= Columns || (r == row && c == column)) continue;
                    this.runtimeTiles[r, c].TxtIndex.text = $"{Math.Sqrt(Math.Pow(Math.Abs(r - row), 2) + Math.Pow(Math.Abs(c - column), 2)) * 10:F0}";
                }
            }
        }
    }
}
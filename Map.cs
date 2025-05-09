using System.Text;

namespace AntFarm {
    /// <summary>
    /// The map stores all the worlds tiles, it's not meant to store the locations of actors and entities
    /// </summary>
    class Map {
        Tile[,] tileMatrix;
        public int Width => tileMatrix.GetLength(1);
        public int Height => tileMatrix.GetLength(0);
        public Map(int width, int height, Tile emptySpace) {
            tileMatrix = new Tile[height, width];
            for (int i = 0; i < tileMatrix.GetLength(0); i++)
                for (int j = 0; j < tileMatrix.GetLength(1); j++)
                    tileMatrix[i, j] = emptySpace;
        }
        public Tile this[int x, int y] {
            get => tileMatrix[x, y];
            set => tileMatrix[x, y] = value;
        }
        public Tile this[Vector2 vec] {
            get => this[vec.y, vec.x];
            set => this[vec.y, vec.x] = value;
        }
    }
}

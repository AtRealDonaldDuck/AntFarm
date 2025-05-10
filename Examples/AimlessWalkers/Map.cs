using AntFarm.Interfaces;
using AntFarm.Util;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Map : IMap {
        Tile[,] tileMatrix;
        public int Width => tileMatrix.GetLength(0);
        public int Height => tileMatrix.GetLength(1);


        public Map(int width, int height, Tile emptySpace) {
            tileMatrix = new Tile[width, height];
            for (int i = 0; i < tileMatrix.GetLength(0); i++)
                for (int j = 0; j < tileMatrix.GetLength(1); j++)
                    tileMatrix[i, j] = emptySpace;
        }

        public Tile this[int x, int y] {
            get => tileMatrix[x, y];
            set => tileMatrix[x, y] = value;
        }


        public IMapObject GetObjectAt(int x, int y) => this[x, y];

        public bool LocationExists(Vector2 position)
            => (position.x >= 0 && position.y >= 0)
            && (position.x < Width && position.y < Height);//if position is negative or larger than the worlds boundaries then the position doesnt exist

    }
}

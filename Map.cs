using System.Text;

namespace AntFarm {
    class Map {
        IMapEntity[,] entityMatrix;
        public int Width => entityMatrix.GetLength(1);
        public int Height => entityMatrix.GetLength(0);
        public Map(int width, int height, IMapEntity emptySpace) {
            entityMatrix = new IMapEntity[height, width];
            for (int i = 0; i < entityMatrix.GetLength(0); i++)
                for (int j = 0; j < entityMatrix.GetLength(1); j++)
                    entityMatrix[i, j] = emptySpace;
        }
        public IMapEntity this[int x, int y] {
            get => entityMatrix[x, y];
            set => entityMatrix[x, y] = value;
        }
        public IMapEntity this[Vector2 vec] {
            get => this[vec.x, vec.y];
            set => this[vec.x, vec.y] = value;
        }

        public bool HasLocation(int x, int y) => (x >= 0 && x < entityMatrix.GetLength(0)) && (y >= 0 && y < entityMatrix.GetLength(0));
        public bool HasLocation(Vector2 vec) => HasLocation(vec.x, vec.y);
    }
}

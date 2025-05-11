using AntFarm.Interfaces;
using AntFarm.Util;
using System.ComponentModel;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Map : IMap {
        readonly Dictionary<Vector2, Tile> tiles;
        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height) {
            Width = width;
            Height = height;
            tiles = new Dictionary<Vector2, Tile>();

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++) {
                    var position = new Vector2(x, y);
                    var tile = new Tile(Tile.Types.Dirt);
                    tile.Position = position;
                    tiles.Add(position, tile);
                }
        }

        public Tile this[int x, int y] {
            get => tiles[new Vector2(x, y)];
            set => tiles[new Vector2(x, y)] = value;
        }

        public IEnumerable<Tile> GetAllTiles() => tiles.Values;
        public bool LocationExists(Vector2 position) => tiles.ContainsKey(position);

    }
}

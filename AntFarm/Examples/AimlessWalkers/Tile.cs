using AntFarm.Interfaces;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Tile : IMapObject {
        public char Icon { get; private set; }

        private Tile(char icon) {
            Icon = icon;
        }

        public static Tile Empty => new(' ');
        public static Tile Dirt => new('█');
    }
}

using AntFarm.Interfaces;
using AntFarm.Util;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Tile : IObject {
        public char Icon { get; private set; }
        public Vector2 Position { get; set; }

        public Tile(Types type) {
            Icon = GetTypeIcon(type);
            Position = new Vector2(0, 0);
        }

        public void ChangeType(Types newType) {
            Icon = GetTypeIcon(newType);
        }

        private static char GetTypeIcon(Types type) => type switch {
            Types.Empty => ' ',
            Types.Dirt => '█',
            _ => throw new NotImplementedException(),
        };

        public enum Types {
            Empty,
            Dirt
        }
    }
}

using AntFarm.Interfaces;
using AntFarm.Util;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Tile : IObject {
        public Types Type { get; private set; }
        public Vector2 Position { get; set; }

        public char Icon => Type switch {
            Types.Empty => ' ',
            Types.Dirt => '█',
            _ => throw new NotImplementedException(),
        };

        public Tile(Types type) {
            Type = type;
            Position = new Vector2(0, 0);
        }

        public void ChangeType(Types newType) {
            Type = newType;
        }

        public enum Types {
            Empty,
            Dirt
        }
    }
}

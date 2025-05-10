using Vector2 = AntFarm.Util.Vector2;

namespace AntFarm.Examples.AimlessWalkers {
    internal static class Actions {
        public static void Move(this Ant ant, Vector2 direction, Farm farm) {
            if (!farm.ValidatePosition(ant.Position + direction))
                throw new Exception($"{ant} Can't move to position {ant.Position + direction}");
            ant.Position += direction;
        }
        public static void Dig(this Ant ant, Vector2 direction, Farm farm) {
            var targetLoc = ant.Position + direction;
            farm.map[targetLoc.x, targetLoc.y] = Tile.Empty;
        }
    }
}

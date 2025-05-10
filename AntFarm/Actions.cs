using AntFarm;
using System;

namespace AntFarm {
    internal static class Actions {
        public static (bool success, Vector2? previousLocation) Move(this IActor actor, Vector2 direction, Map map) {
            actor.Position += direction;
            return (true, actor.Position - direction);
        }
        public static bool Dig(this IActor actor, Vector2 direction, Map map) {
            var targetLoc = actor.Position + direction;
            map[targetLoc] = Tile.Empty;
            return (true);
        }
    }
}

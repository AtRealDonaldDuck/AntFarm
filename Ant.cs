namespace AntFarm {
    class Ant : IMapObject {
        public char Icon { get; }
        public Vector2 Position { get; private set; }
        public Ant(char icon) {
            Icon = icon;
        }

        public void Act(Map map) {
            var moveDirections = GetValidRandomMoveDirection(map);
            Position += moveDirections[new Random().Next(moveDirections.Length)];
            map[Position] = Tile.Empty;
        }

        Vector2[] GetValidRandomMoveDirection(Map map) => Program.GetValidMoveDirections(map, Position);
    }
}

namespace AntFarm {
    class Ant : IMapObject, IActor {
        public char Icon { get; }
        public Vector2 Position { get; set; }

        public Ant(Vector2 position) {
            Icon = 'A';
            Position = position;
        }

        public void Act(Map map) {
            var moveDirections = GetValidRandomMoveDirection(map);
            var selectedDirection = moveDirections[new Random().Next(moveDirections.Length)];
            this.Dig(selectedDirection, map);
            this.Move(selectedDirection, map);
        }

        Vector2[] GetValidRandomMoveDirection(Map map) => Program.GetValidMoveDirections(map, Position);
    }
}

namespace AntFarm {
    class Ant : IActor {
        public char Icon { get; }
        public Vector2 Position { get; set; }

        public Ant(Vector2 position) {
            Icon = 'A';
            Position = position;
        }

        public void Act(Map map) {
            //get valid movement options
            var moveDirections = Program.GetValidMoveDirections(map, Position);
            moveDirections = moveDirections.Where(direction => Program.ants.Any(ant => ant.Position != direction + Position)).ToArray();//remove directions that would end in stepping on another ant

            if (moveDirections.Length == 0)
                throw new Exception($"unhandled error: {nameof(moveDirections)} has 0 elements meaning {this} could not find a single valid place to move to");

            //select next action
            var selectedDirection = moveDirections[Program.rng.Next(moveDirections.Length)];

            //act
            this.Dig(selectedDirection, map);
            this.Move(selectedDirection, map);
        }
    }
}

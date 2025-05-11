using AntFarm.Interfaces;
using Vector2 = AntFarm.Util.Vector2;

namespace AntFarm.Examples.AimlessWalkers {
    internal class Ant : IActor {
        public char Icon { get; }
        public Vector2 Position { get; set; }

        public Ant(Vector2 position) {
            Icon = 'A';
            Position = position;
        }

        public void Act(Farm farm) {
            //get valid movement options
            var moveDirections = farm.GetValidMoveDirections(Position);

            if (moveDirections.Length == 0)
                throw new Exception($"unhandled error: {nameof(moveDirections)} has 0 elements meaning {this} could not find a single valid place to move to");

            //select next action
            Vector2 selectedDirection = moveDirections[farm.rng.Next(moveDirections.Length)];

            //act
            this.Dig(selectedDirection, farm);
            this.Move(selectedDirection, farm);
        }
    }
}

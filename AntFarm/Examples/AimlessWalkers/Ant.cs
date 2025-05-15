using AntFarm.Interfaces;
using AntFarm.Util;
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
            var validDirections = farm.GetValidMoveDirections(Position);

            if (validDirections.Length == 0)
                throw new Exception($"unhandled error: {nameof(validDirections)} has 0 elements meaning {this} could not find a single valid place to move to");

            //select next direction
            //select random direction while prioritizing the direction of dirt tiles
            var randomIndexGenerator = new WeightedRandomNumberGenerator();
            for (int i = 0; i < validDirections.Length; i++) {
                Vector2 targetLocation = validDirections[i] + Position;
                Tile tile = farm.map[targetLocation.x, targetLocation.y];
                int interestLevel = tile.Type == Tile.Types.Dirt ? 100 : 1;
                randomIndexGenerator.AddNumber(i, interestLevel);
            }
            Vector2 selectedDirection = validDirections[randomIndexGenerator.Generate()];

            //act
            this.Dig(selectedDirection, farm);
            this.Move(selectedDirection, farm);
        }
    }
}

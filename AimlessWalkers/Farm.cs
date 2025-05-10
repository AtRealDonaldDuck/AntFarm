using AntFarm.Interfaces;
using AntFarm.Util;
using System.Text;

namespace AntFarm.Examples.AimlessWalkers {
    public class Farm : IFarm {
        internal readonly Map map;
        internal readonly Ant[] ants;
        internal readonly Random rng;

        public Farm(int antCount = 4, int width = 70, int height = 25, int? rngSeed = null) {
            map = new Map(width, height, Tile.Dirt);
            rng = rngSeed == null ? new Random() : new Random(rngSeed.Value);
            ants = CreateAnts(antCount);
        }

        public void Update() {
            //update ants
            foreach (var ant in ants)
                ant.Act(this);
        }

        public string GetWorldString() {
            var sb = new StringBuilder();
            for (int i = 0; i < map.Height; i++) {
                for (int j = 0; j < map.Width; j++)
                    sb.Append(map[j, i].Icon);
                sb.AppendLine();
            }
            foreach (var ant in ants) {
                var stringIndex = ant.Position.x + ((map.Width * ant.Position.y) + (2 * ant.Position.y));
                sb[stringIndex] = ant.Icon;
            }
            return sb.ToString();
        }

        Ant[] CreateAnts(int count) {
            var antList = new List<Ant>();
            //selects random locations where there arent already any ants and places an ant there
            //if a dirt tile exists on an ants spawn point, that dirt tile is removed
            for (int i = 0; i < count; i++) {
                Vector2 antSpawnPosition;

                int spawnAttempts = 0;
                do {
                    antSpawnPosition = new Vector2(rng.Next(map.Width), rng.Next(map.Height));
                    //catch potential infinite loop
                    if (spawnAttempts < 1000) spawnAttempts += 1;
                    else throw new Exception($"Could not find siutable locations to spawn {count} ants");
                } while (antList.Any(ant => ant.Position == antSpawnPosition));//ensure no ants are spawned over eachother

                map[antSpawnPosition.x, antSpawnPosition.y] = Tile.Empty;
                antList.Add(new Ant(antSpawnPosition));
            }
            return antList.ToArray();
        }

        internal Vector2[] GetValidMoveDirections(Vector2 origin) {
            var directions = new Vector2[] { new(1, 0), new(-1, 0), new(0, 1), new(0, -1) }.AsQueryable();//start with every possible move direction
            directions = directions.Where(direction => map.LocationExists(origin + direction));//remove directions that would take the ant out of bounds
            directions = directions.Where(direction => !ants.Any(ant => ant.Position == direction + origin));//remove directions that would put the ant ontop of another ant
            return directions.ToArray();
        }

        internal bool ValidatePosition(Vector2 position) => map.LocationExists(position);
    }
}

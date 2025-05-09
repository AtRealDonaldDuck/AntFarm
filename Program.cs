using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AntFarm {
    internal class Program {
        public static Map map;
        public static readonly Random rng = new Random();
        public static readonly List<IActor> ants = new();

        static void Main(string[] args) {
            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //Create map
            map = new Map(70, 25, Tile.Dirt);

            //Spawn ants
            SpawnAnts(4);

            while (true) {
                //update ant farm state
                foreach (var ant in ants)
                    ant.Act(map);

                //display ant farm
                Console.SetCursorPosition(cursorOriginLeft, cursorOriginTop);
                Console.WriteLine(GetWorldString());

                Thread.Sleep(500);
            }
        }

        static void SpawnAnts(int count) {
            //selects random locations where there arent already any ants and places an ant there
            //if a dirt tile exists on an ants spawn point, that dirt tile is removed
            for (int i = 0; i < count; i++) {
                Vector2 antSpawnPosition;

                int spawnAttempts = 0;
                do {
                    antSpawnPosition = new Vector2(rng.Next(map.Width), rng.Next(map.Height));
                    //catch potential infinite loop
                    if (spawnAttempts < 1000) spawnAttempts += 1;
                    else throw new Exception($"Could not find a siutable location to spawn {ants[i]}");
                } while (ants.Any(ant => ant.Position == antSpawnPosition));//ensure no ants are spawned over eachother

                map[antSpawnPosition] = Tile.Empty;
                ants.Add(new Ant(antSpawnPosition));
            }
        }
        static string GetWorldString() {
            var sb = new StringBuilder();
            for (int i = 0; i < map.Height; i++) {
                for (int j = 0; j < map.Width; j++)
                    sb.Append(map[i, j].Icon);
                sb.AppendLine();
            }
            foreach (Ant ant in ants) {
                var stringIndex = ant.Position.x + ((map.Width * ant.Position.y) + (2 * ant.Position.y));
                sb[stringIndex] = ant.Icon;
            }
            return sb.ToString();
        }
        public static Vector2[] GetValidMoveDirections(Map map, Vector2 origin) {
            var directions = new Vector2[] { new(1, 0), new(-1, 0), new(0, 1), new(0, -1) }.AsQueryable();//start with every possible move direction
            directions = directions.Where(dir
                => (origin.x + dir.x >= 0 && origin.y + dir.y >= 0)
                && (origin.x + dir.x < map.Width && origin.y + dir.y < map.Height));//remove tiles that are out of bounds
            return directions.ToArray();
        }
    }
}

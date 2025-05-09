using System.Text;

namespace AntFarm {
    internal class Program {
        static Map map = new Map(70, 25, Tile.Dirt);//the map only stores tiles that ants walk on
        static Ant ant = new Ant('A');

        static void Main(string[] args) {

            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            while (true) {
                //update ant farm state
                ant.Act(map);

                //display ant farm
                Console.SetCursorPosition(cursorOriginLeft, cursorOriginTop);
                Console.WriteLine(GetWorldString(map, ant));
                
                Thread.Sleep(500);
            }
        }
        static string GetWorldString(Map map, Ant ant) {
            var sb = new StringBuilder();
            for (int i = 0; i < map.Height; i++) {
                for (int j = 0; j < map.Width; j++)
                    sb.Append(map[i,j].Icon);
                sb.AppendLine();
            }
            var stringIndex = ant.Position.x + ((map.Width * ant.Position.y) + (2 * ant.Position.y));
            sb[stringIndex] = ant.Icon;
            return sb.ToString();
        }
        public static Vector2[] GetValidMoveDirections(Map map, Vector2 origin) {
            var allDirections = new Vector2[] { new(1, 0), new(-1, 0), new(0, 1), new(0, -1) };
            var filteredDirections = allDirections.Where(dir 
                => (origin.x + dir.x >= 0 && origin.y + dir.y >= 0) 
                && (origin.x + dir.x < map.Width && origin.y + dir.y < map.Height)).ToArray();//remove any tiles that are out of map bounds
            return filteredDirections;
        }
    }
}

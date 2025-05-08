using System.Text;

namespace AntFarm {
    internal class Program {
        static Map map = new Map(70, 25, new Entity('*'));
        static (Entity entity, Vector2 location) ant = (new Entity('@'), new Vector2(0, 0));

        static void Main(string[] args) {
            map[ant.location] = ant.entity;

            var (startCursorLeft, startCursorTop) = Console.GetCursorPosition();

            while (true) {
                MoveAnt(GetValidRandomMoveDirection(ant.location));
                Console.SetCursorPosition(startCursorLeft, startCursorTop);
                Console.WriteLine(StringifyMap());
                Thread.Sleep(1000);
            }
        }

        static void MoveAnt(Vector2 direction) {
            var fromLoc = ant.location;
            var toLoc = ant.location + direction;

            map[fromLoc] = new Entity(' ');
            map[toLoc] = ant.entity;

            ant.location = toLoc;
        }
        static Vector2 GetValidRandomMoveDirection(Vector2 origin) {
            //keep getting a random move direction till a valid one is recieved or 500 attempts were made
            int attempts = 0;
            const int maxAttempts = 500;
            do {
                attempts++;
                var randDir = Vector2.GetRandomMoveDirection();
                if (map.HasLocation(origin + randDir))
                    return randDir;
            } while (attempts < maxAttempts);
            throw new Exception($"{nameof(GetValidRandomMoveDirection)} could not find a valid move direction after {attempts}");
        }

        static string StringifyMap(char border = '#') {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join("", Enumerable.Repeat(border, map.Width + 2)));//add border top
            for (int i = 0; i < map.Height; i++) {
                sb.Append(border);//add border left
                for (int j = 0; j < map.Width; j++)
                    sb.Append(map[i, j].Icon);
                sb.AppendLine(border.ToString());//add border right
            }
            sb.AppendLine(string.Join("", Enumerable.Repeat(border, map.Width + 2)));//add border top
            return sb.ToString();
        }
    }
}

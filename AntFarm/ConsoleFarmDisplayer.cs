using System.Text;

namespace AntFarm {
    internal class ConsoleFarmDisplayer {
        readonly int consoleCursorAnchorTop;
        readonly int consoleCursorAnchorLeft;
        public ConsoleFarmDisplayer(int consoleCursorAnchorTop, int consoleCursorAnchorLeft) {
            this.consoleCursorAnchorTop = consoleCursorAnchorTop;
            this.consoleCursorAnchorLeft = consoleCursorAnchorLeft;
        }
        public void Display(IEnumerable<DefaultConsoleDisplayCommand> commands) {
            //sort commands by layer
            var orderedCommands = commands.OrderBy(x => x.Layer);

            //parse commands into output with stringbuilder
            var rows = new List<StringBuilder>();
            foreach (var command in orderedCommands) {
                //handle inserting blank spaces
                if (rows.Count < command.Placement.y+1) {
                    rows.AddRange(Enumerable.Repeat(new StringBuilder(), command.Placement.y+1 - rows.Count));//add all missing rows
                }
                if (rows[command.Placement.y].Length < command.Placement.x+1) {
                    foreach (var blank in Enumerable.Repeat(' ', command.Placement.x + 1 - rows[command.Placement.y].Length)) {
                        rows[command.Placement.y].Append(blank);//add all missing chars
                    }
                }

                //put char in desired position
                rows[command.Placement.y][command.Placement.x] = command.Output;
            }

            StringBuilder finalStringBuilder = new();
            foreach (var sb in rows)
                finalStringBuilder.AppendLine(sb.ToString());
            string displayString = finalStringBuilder.ToString();

            //output parsed commands
            Console.Clear();
            Console.SetCursorPosition(consoleCursorAnchorLeft, consoleCursorAnchorTop);
            Console.WriteLine(displayString);
        }
    }
}

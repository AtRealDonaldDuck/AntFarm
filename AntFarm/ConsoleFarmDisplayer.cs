namespace AntFarm {
    internal class ConsoleFarmDisplayer {
        readonly int consoleCursorAnchorTop;
        readonly int consoleCursorAnchorLeft;
        public ConsoleFarmDisplayer(int consoleCursorAnchorTop, int consoleCursorAnchorLeft) {
            this.consoleCursorAnchorTop = consoleCursorAnchorTop;
            this.consoleCursorAnchorLeft = consoleCursorAnchorLeft;
        }
        public void Display(IEnumerable<DefaultConsoleDisplayCommand> commands) {
            Console.SetCursorPosition(consoleCursorAnchorLeft, consoleCursorAnchorTop);
            Console.Clear();

            //sort commands by layer
            var orderedCommands = commands.OrderBy(x => x.Layer);

            foreach (var command in orderedCommands) {
                Console.SetCursorPosition(command.Placement.x, command.Placement.y);
                Console.Out.Write(command.Output);
            }
        }
    }
}

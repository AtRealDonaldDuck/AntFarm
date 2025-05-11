using AntFarm.Interfaces;

namespace AntFarm {
    internal class ConsoleFarmDisplayer : IFarmDisplayer {
        readonly int consoleCursorAnchorTop;
        readonly int consoleCursorAnchorLeft;
        public ConsoleFarmDisplayer(int consoleCursorAnchorTop, int consoleCursorAnchorLeft) {
            this.consoleCursorAnchorTop = consoleCursorAnchorTop;
            this.consoleCursorAnchorLeft = consoleCursorAnchorLeft;
        }
        public void Display(IFarm farm) {
            Console.SetCursorPosition(consoleCursorAnchorLeft, consoleCursorAnchorTop);
            Console.WriteLine(farm.GetWorldString());
        }
    }
}

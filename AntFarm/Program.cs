using AntFarm.Interfaces;

namespace AntFarm {
    internal class Program {

        static void Main(string[] args) {
            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //initialize farm
            IFarm farm = new AntFarm.Examples.AimlessWalkers.Farm(1, 70, 18);
            var displayer = new ConsoleFarmDisplayer(cursorOriginLeft, cursorOriginTop);

            //start logic loop
            while (true) {
                farm.Update();
                var displayCommands = ConsoleDisplayerCommandListFactory.Create(farm);
                displayer.Display(displayCommands);
                Thread.Sleep(500);
            }
        }
    }
}

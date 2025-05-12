using AntFarm.Interfaces;

namespace AntFarm {
    internal class Program {

        static void Main(string[] args) {
            //todo
            //use builder pattern to create console displayer commands
            //use strategy pattern to handle ant actions

            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //initialize farm
            IFarm farm = new AntFarm.Examples.AimlessWalkers.Farm(10, 230, 60);
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

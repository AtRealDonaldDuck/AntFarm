using AntFarm.Interfaces;

namespace AntFarm {
    internal class Program {

        static void Main(string[] args) {
            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //initialize farm
            IFarm farm = new AntFarm.Examples.AimlessWalkers.Farm(5, 180, 60);
            IFarmDisplayer displayer = new ConsoleFarmDisplayer(cursorOriginLeft, cursorOriginTop);

            //start logic loop
            while (true) {
                farm.Update();
                displayer.Display(farm);
                Thread.Sleep(500);
            }
        }
    }
}

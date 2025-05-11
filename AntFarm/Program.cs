using AntFarm.Interfaces;

namespace AntFarm {
    internal class Program {
        static IFarm farm;

        static void Main(string[] args) {
            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //initialize farm
            farm = new AntFarm.Examples.AimlessWalkers.Farm(5, 180, 60);

            //start logic loop
            while (true) {
                farm.Update();

                //display ant farm
                Console.SetCursorPosition(cursorOriginLeft, cursorOriginTop);
                 Console.WriteLine(farm.GetWorldString());

                Thread.Sleep(500);
            }
        }
    }
}

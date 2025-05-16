using AntFarm.Interfaces;
using System.Diagnostics;

namespace AntFarm {
    internal class Program {
        static void Main(string[] args) {
            //todo
            //use builder pattern to create console displayer commands
            //use strategy pattern to handle ant actions
            //write unit test to test the weighted rng

            var (cursorOriginLeft, cursorOriginTop) = Console.GetCursorPosition();

            //initialize farm
            IFarm farm = new AntFarm.Examples.AimlessWalkers.Farm(1, 237, 60);
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

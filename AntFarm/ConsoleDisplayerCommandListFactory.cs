using AntFarm.Interfaces;

namespace AntFarm {
    internal static class ConsoleDisplayerCommandListFactory {
        public static IEnumerable<DefaultConsoleDisplayCommand> Create(IFarm farm, Func<IObject, int> layerProcessor) {
            //iterate over every object in the farm
            var commands = new List<DefaultConsoleDisplayCommand>();

            foreach (IObject obj in farm.GetObjects()) {
                var command = new DefaultConsoleDisplayCommand() {
                    Output = obj.Icon,
                    Placement = obj.Position,
                    Layer = layerProcessor(obj)
                };
                commands.Add(command);
            }
            return commands;
        }
        public static IEnumerable<DefaultConsoleDisplayCommand> Create(IFarm farm) => Create(farm, _ => 0);
    }
}

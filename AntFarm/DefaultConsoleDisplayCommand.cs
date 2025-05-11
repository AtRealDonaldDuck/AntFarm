namespace AntFarm {
    public struct DefaultConsoleDisplayCommand {
        public required char Output { get; init; }
        public required Util.Vector2 Placement { get; init; }
        public required int Layer { get; init; }
    }
}

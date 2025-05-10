namespace AntFarm {
    internal interface IActor : IMapObject {
        public Vector2 Position { get; set; }
        public void Act(Map map);
    }
}

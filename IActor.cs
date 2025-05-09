namespace AntFarm {
    internal interface IActor {
        public Vector2 Position { get; set; }
        public void Act(Map map);
    }
}

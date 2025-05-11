namespace AntFarm.Interfaces {
    public interface IFarm {
        public void Update();
        public IEnumerable<IObject> GetObjects();
    }
}

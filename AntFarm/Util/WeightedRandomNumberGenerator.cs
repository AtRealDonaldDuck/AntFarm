namespace AntFarm.Util {
    public class WeightedRandomNumberGenerator {
        List<int> numbers = new();
        public WeightedRandomNumberGenerator AddNumber(int number, int weight) {
            if (weight <= 0)
                throw new InvalidOperationException("Cant give a number a weight less than 1");

            numbers.AddRange(Enumerable.Repeat(number, weight));
            return this;
        }
        public int Generate() {
            var number = numbers[new Random().Next(numbers.Count)];
            return number;
        }
        public void Reset() {
            numbers.Clear();
        }
    }
}

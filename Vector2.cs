namespace AntFarm {
    struct Vector2(int x, int y) {
        public int x = x;
        public int y = y;

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);

        public static Vector2 GetRandomMoveDirection() => (new Random().Next(4)) switch {
            0 => new Vector2(1, 0),//right
            1 => new Vector2(0, 1),//up
            2 => new Vector2(-1, 0),//left
            3 => new Vector2(0, -1),//down
            _ => throw new Exception("unexpected number generated")
        };
    }
}

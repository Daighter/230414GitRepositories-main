using System.Numerics;

namespace SlidePuzzle
{
    internal class Program
    {
        enum Command { None, Up, Down, Left, Right }

        public class Point
        {
            private int x;
            private int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
        }

        public class Map
        {
            public Point player;
            private int[,] map;
            public Map(int[,] map)
            {
                this.map = map;
            }
        }

        static void Main(string[] args)
        {
            // 게임 초기화
            Point player = new Point(4, 4);
            Map map = new Map(new int[5, 5]);

            while (true)
            {
                // Input
                Command input = GameInput();

                // GameUpdate
                GameUpdate(input, map);

                // Rendering
            }
        }

        // Input
        static Command GameInput()
        {
            Command command;
            ConsoleKeyInfo key = Console.ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    command = Command.Up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    command = Command.Down;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    command = Command.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    command = Command.Right;
                    break;
                default:
                    command = Command.None;
                    break;
            }
            return command;
        }

        // GameUpdate
        static void GameUpdate(Command input, Map map)
        {
            Point prevPoint = map.player;
            switch(input)
            {
                case Command.Up:
                    map.player.Y--;
                    break;
                case Command.Down:
                    map.player.Y++;
                    break;
                case Command.Left:
                    map.player.X--;
                    break;
                case Command.Right:
                    map.player.X++;
                    break;
                default:
                    map.player = prevPoint;
                    break;
            }
        }

        // Rendering
        static void Rendering(Map map)
        {
            for (int y=0; y<map.GetLength(0);)
        }
    }
}
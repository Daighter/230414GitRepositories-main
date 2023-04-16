using System.Numerics;

namespace SlidePuzzle
{
    internal class Program
    {
        enum Command { None, Up, Down, Left, Right }
        public enum Tile { None, Wall }

        public struct Point
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

        public class Stage
        {
            public Point player;
            public Tile[,] map5 = new Tile[13, 13]
            {
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall },
                { Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall }
            };
            public int[,] answer;
            public int[,] number;
            public Stage(Point player)
            {
                this.player = player;
            }


            public int LengthX
            {
                get { return (map5.GetLength(1)); }
            }
            public int LengthY
            {
                get { return (map5.GetLength(0)); }
            }
        }

        static void Main(string[] args)
        {
            // 게임 초기화
            Point player = new Point(10, 10);
            Stage stage = new Stage(player);
            stage.number = new int[stage.map5.GetLength(1), stage.map5.GetLength(0)];
            stage.answer = new int[stage.map5.GetLength(1), stage.map5.GetLength(0)];
            Console.CursorVisible = false;
            SetGame(stage);

            Rendering(stage);
            while (true)
            {
                // Input
                Command input = GameInput();

                // GameUpdate
                GameUpdate(input, stage);

                // Rendering
                Rendering(stage);

                // 클래이 확인
                bool clear = CheckClear(stage);
                if (clear) { break; }
            }
        }

        // SetGame
        static void SetGame(Stage stage)
        {
            Random random5 = new Random();
            int[] rand = new int[24];
            for (int i = 0; i < 24; i++)
            {
                rand[i] = i + 1;
                stage.answer[2 * ((i / 5) + 1), 2 * ((i % 5) + 1)] = rand[i];
            }/*
            for (int a=0; a<13; a++)
            {
                Console.Write("{");
                for (int b=0; b<13; b++)
                {

                    if (stage.answer[a, b] < 10)
                    {
                        
                        Console.Write("  {0}", stage.answer[a, b]);
                    }
                    else { Console.Write(" {0}", stage.answer[a,b]); }
                }
                Console.Write(" }");
                Console.WriteLine();
            }*/
            rand = rand.OrderBy(x => random5.Next()).ToArray();
            for (int j = 0; j < 24; j++)
            {
                stage.number[2 * ((j / 5) + 1), 2 * ((j % 5) + 1)] = rand[j];
            }
        }

        // Input
        static Command GameInput()
        {
            Command command;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
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
        static void GameUpdate(Command input, Stage stage)
        {
            Point prevPoint = stage.player;
            switch (input)
            {
                case Command.Up:
                    stage.player.Y -= 2;
                    break;
                case Command.Down:
                    stage.player.Y += 2;
                    break;
                case Command.Left:
                    stage.player.X -= 2;
                    break;
                case Command.Right:
                    stage.player.X += 2;
                    break;
                default:
                    stage.player = prevPoint;
                    break;
            }

            if (stage.map5[stage.player.Y, stage.player.X] == Tile.Wall)
            {
                stage.player = prevPoint;
            }
            else
            {
                switch (input)
                {
                    case Command.Up:
                        stage.number[(stage.player.Y + 2), stage.player.X] = stage.number[stage.player.Y, stage.player.X];
                        stage.number[stage.player.Y, stage.player.X] = 0;
                        break;
                    case Command.Down:
                        stage.number[(stage.player.Y - 2), stage.player.X] = stage.number[stage.player.Y, stage.player.X];
                        stage.number[stage.player.Y, stage.player.X] = 0;
                        break;
                    case Command.Left:
                        stage.number[stage.player.Y, (stage.player.X + 2)] = stage.number[stage.player.Y, stage.player.X];
                        stage.number[stage.player.Y, stage.player.X] = 0;
                        break;
                    case Command.Right:
                        stage.number[stage.player.Y, (stage.player.X - 2)] = stage.number[stage.player.Y, stage.player.X];
                        stage.number[stage.player.Y, stage.player.X] = 0;
                        break;
                }
            }
        }

        // Rendering
        static void Rendering(Stage stage)
        {
            Console.Clear();
            for (int y = 0; y < stage.LengthY; y++)
            {
                for (int x = 0; x < stage.LengthX; x++)
                {
                    switch (stage.map5[y, x])
                    {
                        case Tile.Wall:
                            Console.Write("▩");
                            break;
                        case Tile.None:
                            // 숫자 배치
                            if (stage.number[y, x] != 0)
                            {
                                if (stage.number[y, x] < 10) { Console.Write(" {0}", stage.number[y, x]); }
                                else { Console.Write(stage.number[y, x]); }
                            }
                            else { Console.Write("　"); }
                            break;
                    }

                }
                Console.WriteLine();
            }
            // 플레이어 좌표
            Console.SetCursorPosition(stage.player.X * 2, stage.player.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('★');
            Console.ResetColor();
        }

        // 클리어 확인
        static bool CheckClear(Stage stage)
        {
            bool clear = false;
            if (stage.number == stage.answer) { clear = true; }
            return clear;
        }
    }
}
namespace UpDownGame
{
    internal class Program
    {
        public class Computer
        {
            private int chances = 10;
            private int answer = 0;
            private bool isClear = false;

            public int Chances
            {
                get { return chances; }
                set { chances = value; }
            }
            public int Answer
            {
                get { return answer; }
                set { answer = value; }
            }
            public bool IsClear
            {
                get { return isClear; }
                set { isClear = value; }
            }
        }

        static void Main(string[] args)
        {
            Computer computer = new Computer();
            int player = 0;

            // 시작 세팅
            SetGame(computer);

            while (true)
            {
                // 플레이어 입력
                player = GameInput();

                // 계산
                GameUpdate(computer, player);

                // 클리어 하거나 남은 횟수가 0이면
                if (computer.IsClear == true || computer.Chances == 0)
                {
                    bool keepOrEnd = ContinueGame();
                    if (keepOrEnd == true)
                    {
                        SetGame(computer);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        static void SetGame(Computer computer)
        {
            Random random = new Random();
            computer.Answer = random.Next(0, 1000);
            computer.Chances = 10;
            computer.IsClear = false;
            Console.WriteLine("남은횟수 : {0}", computer.Chances);
            // 개발자용 확인 출력
            Console.WriteLine(computer.Answer);
        }

        // Input
        static int GameInput()
        {
            Console.WriteLine();
            Console.Write("1000 미만의 자연수 입력 : ");
            int player = int.Parse(Console.ReadLine());
            return player;
        }

        // Update
        static void GameUpdate(Computer computer, int player)
        {
            if (computer.Answer == player)
            {
                Console.WriteLine("정답입니다.");
                computer.IsClear = true;
                computer.Chances = 10;
            }
            else
            {
                computer.Chances--;
                if (computer.Answer > player)
                    Console.WriteLine("Up");
                else if (computer.Answer < player)
                    Console.WriteLine("Down");
                Console.WriteLine("남은횟수 : {0}", computer.Chances);
            }
        }

        static bool ContinueGame()
        {
            int conti = 0;
            bool yesOrNo = false;
            while (conti == 0)
            {
                Console.WriteLine("게임을 다시 하시겠습니까?");
                string YesOrNo = Console.ReadLine();
                switch (YesOrNo)
                {
                    case "yes":
                    case "y":
                    case "ㅛ":
                        conti = 1;
                        yesOrNo = true;
                        break;
                    case "no":
                    case "n":
                    case "ㅜ":
                        conti = -1;
                        yesOrNo = false;
                        break;
                    default:
                        Console.WriteLine("다시 입력해주세요.");
                        break;
                }
            }
            switch (yesOrNo)
            {
                case true:
                    Console.WriteLine("게임을 다시 시작합니다.");
                    break;
                default:
                    Console.WriteLine("게임을 종료합니다.");
                    break;
            }
            return yesOrNo;
        }
    }
}
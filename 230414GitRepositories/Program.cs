namespace _230414GitRepositories
{
    internal class Program
    {
        class MyClass
        {
            public int a;
            public int b;
        }

        static void Main(string[] args)
        {
            // 다음과 같은 코드가 있다고 가정할 때 출력결과와 그 이유를 서술하라.
            MyClass source = new MyClass();
            source.a = 10;
            source.b = 20;

            MyClass target = source;
            target.a = 100;

            Console.WriteLine("{0},{1}", source.a, source.b);
            Console.WriteLine("{0},{1}", target.a, target.b);


            // 다음 코드에서 a와 b는 각각 얼마인가?  4. 16, 2
            // int a 32 >> 1;
            // int b a  >> 3;

            // Console.WriteLine(a);
            // Console.WriteLine(b);


            // 다음 코드에서 a는 어떤 값을 가지는가?   1. 255
            // int a = 0xF0 | 0x0F;
            // Console.WriteLine(a);


            // 문자열 속의 문자열 찾기
            Console.Write("문장 : ");
            string sentence = Console.ReadLine();
            Console.Write("문장단어 : ");
            string word = Console.ReadLine();
            FindWord(sentence, word);

            // 문자열을 입력받으면 단어의 갯수를 출력하기
            DivideString(Console.ReadLine());


            // 주어진 숫자가 소수인지 판별하는 solution을 완성하라
            Console.Write("자연수 입력 : ");
            int a = int.Parse(Console.ReadLine());
            bool isPrime = IsPrime(a);
            Console.WriteLine(isPrime);


            // 사용자가 입력한 양의 정수의 각 자리수의 합을 구하는 Solution 을 완성하라
            Console.Write("자연수 입력 : ");
            string num = Console.ReadLine();
            SumAllNumbers(num);


            // k개의 정렬된 배열에서 공통항목을 찾는 Solution을 완성하라.단, 중복은 허용하지 않는다
            int[] arr1 = { 1, 5, 5, 10 };
            int[] arr2 = { 3, 4, 5, 5, 10 };
            int[] arr3 = { 5, 5, 10, 20 };

            int[] result = FindCommonItems(arr1, arr2, arr3);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }

        // 문자열 속의 문자열 찾기
        public static void FindWord(string sentence, string word)
        {
            int index;
            if (sentence.Contains(word))
            {
                index = sentence.IndexOf(word);
                Console.WriteLine(index);
            }
            else
            {
                index = -1;
                Console.WriteLine(index);
            }
        }

        // 문자열을 입력받으면 단어의 갯수를 출력하기
        public static void DivideString(string str)
        {
            Console.WriteLine("문장 입력 : ");
            int count = 0;
            string[] result = str.Split(new char[] { ' ' });
            for (int i = 0; i < result.Length; i++)
            {
                count++;
            }
            Console.WriteLine(count);
        }

        // 주어진 숫자가 소수인지 판별하는 solution을 완성하라
        static bool IsPrime(int n)
        {
            if (n <= 0)
                Console.WriteLine("자연수가 아님");
            bool isPrime = true;
            if (n == 1)
                isPrime = false;
            else if (n == 2)
                isPrime = true;
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                        isPrime = false;
                }
            }
            return isPrime;
        }

        // 사용자가 입력한 양의 정수의 각 자리수의 합을 구하는 Solution 을 완성하라
        public static void SumAllNumbers(string num)
        {
            int sum = 0;
            foreach (char c in num)
            {
                sum += (int)Char.GetNumericValue(c);
            }
            Console.WriteLine(sum);
        }

        // k개의 정렬된 배열에서 공통항목을 찾는 Solution을 완성하라.단, 중복은 허용하지 않는다
        static int[] FindCommonItems(int[] arr1, int[] arr2, int[] arr3)
        {
            int index = -1;
            int totalCom = 0;
            int[] comArray = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                if (Array.Exists(arr2, x => x == arr1[i]) && Array.Exists(arr3, x => x == arr1[i]))
                {
                    index++;
                    if (index == 0)
                    {
                        comArray[index] = arr1[i];
                        totalCom++;
                    }
                    else if (index > 0)
                    {
                        if (arr1[i] != comArray[index - 1])
                        {
                            comArray[index] = arr1[i];
                            totalCom++;
                        }
                        else index--;
                    }
                }
            }
            int[] resultArray = new int[totalCom];
            int num = 0;
            for (int i = 0; i < comArray.Length; i++)
            {

                if (comArray[i] != 0)
                {
                    resultArray[num] = comArray[i];
                    num++;
                }
            }
            return resultArray;
        }
    }
}
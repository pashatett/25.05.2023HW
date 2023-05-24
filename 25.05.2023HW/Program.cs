using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _25._05._2023HW
{
    //for task3
    class Cesar
    {
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        string CodeEncode(string text, int k)
        {
            string fullAlfabet = alfabet + alfabet.ToLower();
            int letterQty = fullAlfabet.Length;
            string retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                int index = fullAlfabet.IndexOf(c);
                if (index < 0)
                    retVal += c.ToString();
                else
                {
                    int codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
             => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }

    //for task4
    class four
    {
        void Show(int[,] arr)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j=0;j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void MultNum(int[,] arr)
        {
            Show(arr);
            Console.WriteLine("Введите число, на которое нужно умножить ");
            int num = int.Parse(Console.ReadLine());
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    arr[i, j] = arr[i, j] * num;
                }
            }
            Show(arr);
        }
        public void Sum(int[,] arr, int[,] arr1) 
        {
            Console.WriteLine("Первая матрица");
            Show(arr);
            Console.WriteLine("Вторая матрица");
            Show(arr1);
            int[,] newArr = new int[5, 10];
            for(int i = 0; i < 5; i++)
            {
                int k = 0;
                for( int j = 0;j < 10; j++)
                {
                    if (j < 5)
                    {
                        newArr[i, j] = arr[i, j];
                    }
                    else
                    {
                        newArr[i,j] = arr1[i, k];
                        k++;
                    }
                }
            }
            Show(newArr);
        }
        public void MultMat(int[,] arr, int[,] arr1)
        {
            Console.WriteLine("Первая матрица");
            Show(arr);
            Console.WriteLine("Вторая матрица");
            Show(arr1);
            int[,] newArr = new int[5, 5];
            for(int i = 0; i < 5; i++)
            {
                for( int j = 0;j<5; j++)
                {
                    newArr[i,j] = arr[i, j] * arr1[i,j];
                }
            }
            Show(newArr);
        }
    }

    internal class Program
    {
        static void task1()
        {
            Random random = new Random();
            int[] A = new int[5];
            int[,] B = new int[3, 4];
            int mult = 1;
            int sumChetA = 0;
            int sumNeChetB = 0;

            for (int i = 0; i < 5; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.Next(20);
                }
            }

            int[] b1 = new int[12];
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b1[k] = B[i, j];
                    k++;
                    mult *= B[i, j];
                    if (j % 2 != 0) sumNeChetB += B[i, j];
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
                mult *= A[i];
                if (i % 2 == 0) sumChetA += A[i];
            }

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine((string.Join(" ", A.Intersect(b1))).Max());//максимальный общий
            Console.WriteLine((string.Join(" ", A.Intersect(b1))).Min());//минимальный общий
            Console.WriteLine(b1.Sum() + A.Sum());//сумма всех
            Console.WriteLine(mult);//произведение
            Console.WriteLine(sumChetA);//сумма четный А
            Console.WriteLine(sumNeChetB);//сумма нечетных Б
        }
        static void task2()
        {
            int[,] arr = new int[5, 5];
            int min = arr[0, 0], max = arr[0, 0];
            int iMin = 0, jMin = 0, iMax = 0, jMax = 0;
            int sum = 0;
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (min > arr[i, j])
                    {
                        min = arr[i, j];
                        iMin = i;
                        jMin = j;
                    }
                    if (max < arr[i, j])
                    {
                        max = arr[i, j];
                        iMax = i;
                        jMax = j;
                    }
                }
            }

            for (int i = ((iMin < iMax) ? iMin : iMax); i < ((iMin > iMax) ? iMin : iMax); i++)
            {
                if (i == ((iMin > iMax) ? iMin : iMax) && i == ((iMin < iMax) ? iMin : iMax))
                    for (int j = ((jMin < jMax) ? jMin : jMax); j < ((jMin > jMax) ? jMin : jMax); j++)
                        sum += arr[i, j];
                if (i == ((iMin < iMax) ? iMin : iMax))
                    for(int j =((jMin < jMax) ? jMin : jMax); j<5;j++) 
                        sum += arr[i, j];
                if (i == ((iMin > iMax) ? iMin : iMax))
                    for (int j = 0;j< ((jMin > jMax) ? jMin : jMax);j++)
                        sum += arr[i, j];
                for (int j = 0; j < 5; j++)
                    sum += arr[i, j];
            }

            Console.WriteLine($"Sum -> {sum}");
            Console.WriteLine($"iMin -> {iMin}");
            Console.WriteLine($"jMin -> {jMin}");
            Console.WriteLine($"iMax -> {iMax}");
            Console.WriteLine($"jMax -> {jMax}");
        }
        static void task3()
        {
            Cesar s = new Cesar();
            Console.Write("Введите текст: ");
            var message = Console.ReadLine();
            Console.Write("Введите ключ: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = s.Encrypt(message, secretKey);
            Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
            Console.WriteLine("Расшифрованное сообщение: {0}", s.Decrypt(encryptedText, secretKey));

        }
        static void task4()
        {
            Random rnd = new Random();
            int[,] arr = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = rnd.Next(10);
                }
            }
            four four = new four();
            Console.WriteLine("1)Умножение матрицы на число;\r\n2)Сложение матриц;\r\n3)Произведение матриц;\r\n4)Выход;");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    four.MultNum(arr);
                    task4();
                    break;
                case 2:
                    four.Sum(arr, arr);
                    task4();
                    break;
                case 3:
                    four.MultMat(arr, arr);
                    task4();
                    break;
                case 4:
                    break;
            }
        }
        static void task5()
        {
            string str = Console.ReadLine();
            string[] sum = str.Split('+');
            string[] min = str.Split('-');
            string[] mult = str.Split('*');
            string[] del = str.Split('/');

            if (sum.Length == 2)
            {
                int a = Convert.ToInt32(sum[0]);
                int b = Convert.ToInt32(sum[1]);
                Console.WriteLine($"{str} = {a + b}");
            }
            if (min.Length == 2)
            {
                int a = Convert.ToInt32(min[0]);
                int b = Convert.ToInt32(min[1]);
                Console.WriteLine($"{str} = {a - b}");
            }
            if (mult.Length == 2)
            {
                int a = Convert.ToInt32(mult[0]);
                int b = Convert.ToInt32(mult[1]);
                Console.WriteLine($"{str} = {a * b}");
            }
            if (del.Length == 2)
            {
                int a = Convert.ToInt32(del[0]);
                int b = Convert.ToInt32(del[1]);
                Console.WriteLine($"{str} = {a / b}");
            }
        }
        static void task6() { }
        static void task7() { }

        static void Main(string[] args)
        {
            task4();
            Console.ReadLine();
        }
    }
}

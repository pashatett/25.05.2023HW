using System;
using System.Collections.Generic;
using System.Linq;
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
        static void Main(string[] args)
        {
            task2();
            Console.ReadLine();
        }
    }
}

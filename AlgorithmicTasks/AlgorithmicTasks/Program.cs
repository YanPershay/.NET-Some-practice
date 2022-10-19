internal class Program
{
    private static void Main(string[] args)
    {
        //var numbers = Enumerable.Range(1, 100).ToArray();

        var numbers = new int[100];

        for(int i = 1; i <= 100; i++)
        {
            numbers[i - 1] = i;
        }

        //OddLeftEvenRight(numbers);

        //ShowNumbersDivisibleBy5And10(numbers);

        //ReverseString("Hello world");
        //string commonStr = "Hello world";
        //Console.WriteLine("'" + commonStr + "'" + " reverse result: " + ReverseString(commonStr));

        //PalindromeOrNot("step on no pets");

        //SumOfDigits(52341);

        //var smallNums = new int[] { 2, 9, 3, 5, 8, 100, 7 };
        //SecondLargestNumber(smallNums);

        //int[,] matrix = new int[4, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
        //MultiArrayToSingle(matrix);

        //int[] numsForMatrix = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        //SingleArrayToMulti(numsForMatrix, 3, 4);

        int[] unsortedNumbers = new int[9] { -5, 13, 16, 2, 8, 9, 11, 19, 1 };
        //BubbleSort(unsortedNumbers);
    }

    private static void OddLeftEvenRight(int[] numbers)
    {
        Console.WriteLine("------------Odd Left Even Right----------");

        var newNumbers = CloneIntArray(numbers);

        for(int i = 0; i < newNumbers.Length; i++)
        {
            for (int j = 0; j < newNumbers.Length - 1 - i; j++)
            {
                if (newNumbers[j] % 2 == 0)
                {
                    Swap(ref newNumbers[j], ref newNumbers[j + 1]);
                }
            }
        }

        for (int i = 0; i < newNumbers.Length; i++)
        {
            Console.Write(newNumbers[i] + " ");
        }

        Console.WriteLine();
    }

    private static void ShowNumbersDivisibleBy5And10(int[] numbers)
    {
        Console.WriteLine("------Show info if number diisible by 5 or 10------");

        var newNumbers = CloneIntArray(numbers);

        for (int i = 0; i < newNumbers.Length; i++)
        {
            if (newNumbers[i] % 10 == 0)
            {
                Console.WriteLine(newNumbers[i] + " divisible by 10");
            }
            else if (newNumbers[i] % 5 == 0)
            {
                Console.WriteLine(newNumbers[i] + " divisible by 5");
            }
            else
            {
                Console.WriteLine("Just " + newNumbers[i]);
            }
        }

        Console.WriteLine();
    }

    private static string ReverseString(string str)
    {
        Console.WriteLine("------Reverse string------");
        char[] chars = str.ToCharArray();

        for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
        {
            char startChar = chars[i];
            chars[i] = chars[j];
            chars[j] = startChar;
        }

        //Console.WriteLine(str + " reverse result: " + new string(chars));

        return new string(chars);
    }

    private static void PalindromeOrNot(string str)
    {
        Console.WriteLine("------Palindrome or not------");

        char[] chars = str.ToCharArray();

        int length = chars.Length;

        #region 1st way
        //int n = 0;
        //for (int i = 0, j = length - 1; i < length; i++, j--)
        //{
        //    if (chars[i] == chars[j])
        //    {
        //        n++;
        //    }
        //}

        //if (n == length)
        //{
        //    Console.WriteLine(str + " is Palindrome");
        //} else
        //{
        //    Console.WriteLine(str + " isn't Palindrome");
        //}
        #endregion

        #region 2nd way
        //bool flag = false;
        //for (int i = 0, j = length - 1; i < chars.Length / 2; i++, j--)
        //{
        //    if (chars[i] != chars[j])
        //    {
        //        flag = false;
        //        break;
        //    }
        //    else
        //    {
        //        flag = true;
        //    }
        //}

        //if (flag)
        //{
        //    Console.WriteLine(str + " is Palindrome");
        //}
        //else
        //{
        //    Console.WriteLine(str + " isn't Palindrome");
        //}
        #endregion

        #region 3rd way
        if (ReverseString(str) == str)
        {
            Console.WriteLine(str + " is Palindrome");
        }
        else
        {
            Console.WriteLine(str + " isn't Palindrome");
        }
        #endregion
    }

    private static void SumOfDigits(int number)
    {
        Console.WriteLine("-----Sum of number digits-----");
        int sum = 0;


        Console.Write("Sum of " + number + " digits is ");

        while (number > 1)
        {
            sum += number % 10;
            number /= 10;
        }

        Console.WriteLine(sum);
    }

    private static void SecondLargestNumber(int[] numbers)
    {
        Console.WriteLine("------Second largest number in unsorted array------");
        int length = numbers.Length;

        int max1 = int.MinValue;
        int max2 = int.MinValue;

        #region with one loop
        //foreach (int i in numbers)
        //{
        //    if (i > max1)
        //    {
        //        max2 = max1;
        //        max1 = i; 
        //    } else if (i < max1 && i > max2)
        //    {
        //        max2 = i;
        //    }
        //}
        #endregion

        //with 2 loops
        for (int i = 0; i < length; i++)
        {
            if (numbers[i] > max1)
            {
                max1 = numbers[i];
            }
        }

        for (int i = 0; i < length; i++)
        {
            if (numbers[i] < max1 && numbers[i] > max2)
            {
                max2 = numbers[i];
            }
        }

        Console.Write("Second MAX number in ");
        for (int i = 0; i < length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine("is " + max2);
    }

    private static void MultiArrayToSingle(int[,] multiArray)
    {
        Console.WriteLine("------Convert multi-array to single------");

        int columns = multiArray.GetLength(0);
        int rows = multiArray.GetLength(1);
        int index = 0;
        int[] singleArray = new int[columns * rows];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                singleArray[index] = multiArray[i, j];
                index++;
            }
        }

        Console.WriteLine("Original matrix:");
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Console.Write(multiArray[i,j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("New array:");
        for (int i = 0; i < singleArray.Length; i++)
        {
            Console.Write(singleArray[i] + " ");
        }
    }

    private static void SingleArrayToMulti(int[] singleArray, int rows, int columns)
    {
        int[,] multiArray = new int[rows, columns];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                multiArray[i, j] = singleArray[index];
                index++;
            }
        }

        Console.WriteLine("Original array:");
        for (int i = 0; i < singleArray.Length; i++)
        {
            Console.Write(singleArray[i] + " ");
        }

        Console.WriteLine();

        Console.WriteLine("New matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(multiArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void BubbleSort(int[] numbers)
    {
        int temp;
        int length = numbers.Length;
        Console.Write("Original array: ");
        for (int i = 0; i < length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < length - 1; i++)
        {
            for (int j = 0; j < length - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        Console.Write("Sorted array: ");
        for (int i = 0; i < length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
    }

    private static int[] CloneIntArray(int[] array) => (int[])array.Clone();

    private static void Swap(ref int first, ref int second)
    {
        int tempFirst = first;
        first = second;
        second = tempFirst;
    }
}
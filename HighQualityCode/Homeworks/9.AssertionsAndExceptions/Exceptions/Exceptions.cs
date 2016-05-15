using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr.Length == 0)
        {
            throw new ArgumentNullException("arr", "Array can not be empty!");
        }

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException("count", "Count can not be smaller than 1!");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("str", "String can not be null or empty!");
        }

        if (count > str.Length || count < 1)
        {
            throw new ArgumentOutOfRangeException("count", "Count can not be negative or greater than string's length!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number <= 1)
        {
            throw new ArgumentOutOfRangeException("number", "Number should be positive and greater than 1!");
        }

        bool isPrime = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
            }
        }

        if (isPrime)
        {
            Console.WriteLine(number + " is prime!");
        }
        else
        {
            Console.WriteLine(number + " is not prime!");
        }
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] {-1, 3, 2, 1}, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (ArgumentException a)
        {
            Console.WriteLine(a.Message);
        }
        catch (IndexOutOfRangeException i)
        {
            Console.WriteLine(i.Message);
        }

        try
        {
            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentNullException ne)
        {
            Console.WriteLine(ne.Message);
        }
        catch (ArgumentOutOfRangeException oe)
        {
            Console.WriteLine(oe.Message);
        }

        try
        {
            CheckPrime(23);
            CheckPrime(33);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentNullException ne)
        {
            Console.WriteLine(ne.Message);
        }
    }
}

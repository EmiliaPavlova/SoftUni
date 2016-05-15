namespace _3.OwnCode
{
    using System;
    using System.Linq;

    class OwnCode
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var largeNum = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsLargerThanNeighbours(numbers, i))
                {
                    largeNum = i;
                    break;
                }
            }

            Console.WriteLine(largeNum);
        }

        static bool IsLargerThanNeighbours(int[] array, int index)
        {

            if (index == 0)
            {
                if (array[index] > array[index + 1])
                {
                    return true;
                }

                return false;
            }

            if (index == (array.Length - 1))
            {
                if (array[index] > array[index - 1])
                {
                    return true;
                }

                return false;
            }

            if (array[index] > array[index + 1] && array[index] > array[index - 1])
            {
                return true;
            }

            return false;
        }
    }
}

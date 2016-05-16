using System;
class SpiralMatrix
{
	//Comment this part of the code and uncomment 
	//the code starting from line 80 to get the solution of the matrix
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string word = Console.ReadLine();
        int index = 0;
        char[,] matrix = new char[n, n];
        int oldN = n;
        int x = 0;
        int y = 0;

        //Creating a checkboard matrix and filling it with the elements of the input string 'word'
        int count = 0;
        for (int i = 0; i < oldN; i++)
        {
            for (int j = i%2 == 0 ? 0 : 1; j < oldN; j+=2)
            {
                matrix[i,j] = word[count];
                count++;
            }
        }
        for (int i = 0; i < oldN; i++)
        {
            for (int j = i % 2 == 0 ? 1 : 0; j < oldN; j += 2)
            {
                matrix[i,j] = word[count];
                count++;
            }
        }

        string sentance = "";
        while (n > 0)
        {
            for (int i = y; i <= y + n - 1; i++) // Go right.
            {
                sentance += matrix[x, i];
                index++;
            }

            for (int j = x + 1; j <= x + n - 1; j++) //Go down.
            {
                sentance += matrix[j, y + n - 1];
                index++;
            }

            for (int i = y + n - 2; i >= y; i--) // Go left.
            {
                sentance += matrix[x + n - 1, i];
                index++;
            }

            for (int i = x + n - 2; i >= x + 1; i--) // Go up.
            {
                sentance += matrix[i, y];
                index++;
            }
            x++;
            y++;
            n -= 2;
        }

        for (int i = 0; i < oldN; i++)
        {
            for (int j = 0; j < oldN; j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
        
        Console.WriteLine(sentance);
    }
         
		 
	//Uncomment the bottom part for the solution of the matrix
	/*
	static void Main(string[] args)
    {
	int n = int.Parse(Console.ReadLine());
	string word = Console.ReadLine();
	int index = 0;
	char[,] matrix = new char[n, n];
	int oldN = n;
	int x = 0;
	int y = 0;
	//Creating a spiral matrix and filling it with the elements of the input string 'word'
	while (n > 0)
	{
		for (int i = y; i <= y + n - 1; i++) // Go right.
		{
			matrix[x, i] = word[index];
			index++;
		}

		for (int j = x + 1; j <= x + n - 1; j++) //Go down.
		{
			matrix[j, y + n - 1] = word[index];
			index++;
		}

		for (int i = y + n - 2; i >= y; i--) // Go left.
		{
			matrix[x + n - 1, i] = word[index];
			index++;
		}

		for (int i = x + n - 2; i >= x + 1; i--) // Go up.
		{
			matrix[i, y] = word[index];
			index++;
		}
		x++;
		y++;
		n -= 2;
	}


	string sentance = "";
	for (int i = 0; i < oldN; i++)
	{
		for (int j = i%2 == 0 ? 0 : 1; j < oldN; j+=2)
		{
			sentance += matrix[i, j];
		}
	}
	for (int i = 0; i < oldN; i++)
	{
		for (int j = i % 2 == 0 ? 1 : 0; j < oldN; j += 2)
		{
			sentance += matrix[i, j];
		}
	}
	Console.WriteLine(sentance);

	sentance = sentance.ToLower();

	string output = "";
	for (int i = 0; i < sentance.Length; i++)
	{
		if (sentance[i] >= 97 && sentance[i] <= 122)
			output += sentance[i];
	}

	bool isPalindrome = true;
	for (int i = 0; i < output.Length; i++)
	{
		if (output[i] != output[output.Length-1-i])
		{
			isPalindrome = false;
		}
	}
	Console.WriteLine(isPalindrome);
	}
	*/    
}


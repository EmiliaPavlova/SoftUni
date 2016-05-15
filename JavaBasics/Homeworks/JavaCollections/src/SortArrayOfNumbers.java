// Write a program to enter a number n and n integer numbers and sort and print them. Keep the numbers in array of
// integers: int[].

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfNumbers {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        input.nextLine();
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++) {
            numbers[i] = input.nextInt();
        }
        Arrays.sort (numbers);
        for (int number : numbers) {
            System.out.printf("%d ", number);
        }
    }
}

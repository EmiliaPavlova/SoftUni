// Write a program to find all increasing sequences inside an array of integers. The integers are given in a single line,
// separated by a space. Print the sequences in the order of their appearance in the input array, each at a single line.
// Separate the sequence elements by a space. Find also the longest increasing sequence and print it at the last line.
// If several sequences have the same longest length, print the leftmost of them.

import java.util.Scanner;

public class LongestIncreasingSequence {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        String[] strings = input.nextLine().split(" ");
        int[] numbers = new int[strings.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(strings[i]);
        }
        int currentLength = 1;
        int longestLength = 1;
        int bestPosition = 0;
        int startPosition = 0;
        System.out.print(numbers[0]); //print the first element
        for (int i = 1; i < numbers.length ; i++) {
            if (numbers[i] > numbers[i - 1] ) {
                System.out.print(" " + numbers[i]);
                currentLength ++;
            } else {
                System.out.println();
                System.out.print(numbers[i]);
                currentLength = 1;
            }
            //the largest increasing sequence length and the index of its last element
            if (currentLength > longestLength) {
                longestLength = currentLength;
                bestPosition = i;
                startPosition = i - (longestLength - 1) ;
            }
        }

        System.out.println();
        System.out.print("Longest: ");
        for (int i = startPosition; i <= bestPosition; i++) {
            System.out.print(numbers[i] + " ");
        }
    }
}


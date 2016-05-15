// Write a program that enters an array of strings and finds in it the largest sequence of equal elements. If several
// sequences have the same longest length, print the leftmost of them. The input strings are given as a single line,
// separated by a space.

import java.util.Scanner;

public class LargestSequenceOfEqualStrings {
    public static void main (String[] args){
        Scanner input = new Scanner(System.in);
        String[] strings = input.nextLine().split(" ");
        int currentLength = 1;
        int longestLength = 1;
        String bestString = strings[0];
        for (int i = 0; i < strings.length - 1; i++) {
            if (strings[i].equals(strings[i+ 1]) ) {
                currentLength ++;
            }
            else {
                currentLength = 1;
            }
            if (currentLength > longestLength) {
                longestLength = currentLength;
                bestString = strings[i];
            }
        }
        for (int i = 0; i < longestLength; i++) {
            System.out.print(bestString + " ");
        }
    }
}
// Write a program that enters an array of strings and finds in it all sequence s of equal elements. The input strings
// are given as a single line, separated by a space.

import java.util.Scanner;

public class SequencesOfEqualStrings {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        String all = input.nextLine();
        String[] elements = all.split(" ");
        System.out.print(elements[0]);
        //print the first element
        for (int i = 1; i < elements.length; i++) {
        //check for repeating elements
            if (elements[i].equals(elements[i-1])) {
                System.out.print( " " + elements[i]);
            }
            else {
                System.out.println();
                System.out.print(elements[i]);

            }
        }
    }
}

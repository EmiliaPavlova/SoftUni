// Write a program to find how many times given string appears in given text as substring. The text is given at the first
// input line. The search string is given at the second input line. The output is an integer number. Please ignore the
// character casing.

import java.util.Scanner;

public class CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine().toLowerCase();
        String string = scan.nextLine().toLowerCase();
        int index = text.indexOf(string);
        int count = 0;
        while (index != -1) {
            index = text.indexOf(string, index + 1);
            count ++;
        }
        System.out.println(count);
    }
}
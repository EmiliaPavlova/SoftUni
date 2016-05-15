// Write a program to count the number of words in given sentence. Use any non-letter character as word separator.

import java.util.Scanner;

public class CountAllWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String[] allWords = input.split("[^A-Za-z]+"); // ("([().,!?:;'\"-]|\\s)+");
        int count = allWords.length;
        System.out.println(count);
    }
}

// Write a program to generate and print all 3-letter words consisting of given set of characters. For example if we
// have the characters 'a' and 'b', all possible words will be "aaa", "aab", "aba", "abb", "baa", "bab", "bba" and
// "bbb". The input characters are given as string at the first line of the input. Input characters are unique (there
// are no repeating characters).

import java.util.Scanner;

public class Generate3LetterWords {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        String string = input.nextLine();
        char[] letters = string.toCharArray();

        for (int i = 0; i < string.length(); i++) {
            for (int j = 0; j < string.length(); j++) {
                for (int k = 0; k < string.length(); k++) {
                    System.out.printf("%s%s%s ", letters[i], letters[j],letters[k]);
                }
            }
        }
    }
}


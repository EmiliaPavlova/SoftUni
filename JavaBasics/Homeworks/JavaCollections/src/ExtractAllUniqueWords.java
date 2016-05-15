// At the first line at the console you are given a piece of text. Extract all words from it and print them in
// alphabetical order. Consider each non-letter character as word separator. Take the repeating words only once.
// Ignore the character casing. Print the result words in a single line, separated by spaces.

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine().toLowerCase();
        String[] text = input.split("[^A-Za-z]+");
        Arrays.sort(text);
        ArrayList<String> words = new ArrayList<>();
        for (String word : text) {
            if (!words.contains(word)) {
                words.add(word);
            }
        }
        for (String word : words) {
            System.out.print(word + " ");
        }
    }
}

// Write a program to find the most frequent word in a text and print it, as well as how many times it appears in format
// "word->count". Consider any non-letter character as a word separator. Ignore the character casing. If several words
// have the same maximal frequency, print all of them in alphabetical order.

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeMap;

public class MostFrequentWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine().toLowerCase();
        String[] text = input.split("[^A-Za-z]+");

        //Arrays.sort(text);

        TreeMap<String, Integer> words = new TreeMap<>();

        for (String word: text) {
            Integer frequency = words.get(word);
            if (frequency == null) {
                frequency = 0;
            }
            words.put(word, frequency + 1);
        }
        int count = 0;
        int biggestCount = 0;
        for (String word : words.keySet()) {
            count = words.get(word);
            if (count > biggestCount) {
                biggestCount = count;
            }
        }
        int frequency = 0;
        for (String word : words.keySet()) {
            frequency = words.get(word);
            if (frequency == biggestCount) {
                System.out.println(word + " -> " + biggestCount + " times");
            }
        }

    }
}

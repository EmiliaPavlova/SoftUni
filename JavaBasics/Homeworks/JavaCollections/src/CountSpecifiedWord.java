// Write a program to find how many times a word appears in given text. The text is given at the first input line. The
// target word is given at the second input line. The output is an integer number. Please ignore the character casing.
// Consider that any non-letter character is a word separator.

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String word = scan.nextLine();
        String[] allWords = input.split("[^A-Za-z]+");
        int count = 0;
        String checkWord = "";
        for (int i = 0; i < allWords.length; i++) {
            checkWord = allWords[i].toLowerCase();
            if (checkWord.equals(word.toLowerCase())) {
                count++;
            }
            
        }
        System.out.println(count);
//
//        // second way
//        int count = 0;
//        Pattern p = Pattern.compile(word + "\\W+", Pattern.CASE_INSENSITIVE);
//        Matcher m = p.matcher(str);
//        while (m.find()) {
//            count++;
//        }
//        System.out.println(count);
    }
}

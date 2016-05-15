import java.util.HashSet;
import java.util.Scanner;

/**
 * Created by emily on 1/29/15.
 */
public class CognateWords {
    public static void main (String [] args) {
        Scanner input = new Scanner(System.in);
        String[] text = input.nextLine().split("[^a-zA-Z]+");
        HashSet<String> words = new HashSet<>();
        for (int a = 0; a < text.length; a++) {
            for (int b  = 0; b < text.length; b++) {
                for (int c = 0; c < text.length; c++) {
                    if (a != b) {
                        boolean matched = (text[a] + text[b]).equals(text[c]);
                        if (matched) {
                            words.add(text[a] + "|" + text[b] + "=" + text[c]);
                        }
                    }
                }
            }
        }
        if (!words.isEmpty()) {
            for (String word : words) {
                System.out.println(word);
            }
        } else {
            System.out.print("No");
        }
    }
}

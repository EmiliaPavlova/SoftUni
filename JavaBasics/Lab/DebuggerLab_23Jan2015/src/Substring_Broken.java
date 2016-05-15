import java.util.Scanner;

/**
 * Created by emily on 1/27/15.
 */
public class Substring_Broken {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        String text = input.nextLine();
        int jump = Integer.parseInt(input.nextLine());

        // p changer from BG to EN
        char search = 'p';
        boolean hasMatch = false;

        for (int i = 0; i < text.length(); i++) {

            if (text.charAt(i) == search) {
                hasMatch = true;

                int endIndex = jump;

                if (endIndex > text.length()) {
                    endIndex = text.length();
                }

                // defines string and set loop for the string
                String matchedString = "";
                for (int j = i; j <= i+endIndex; j++) {
                    if (j < text.length()) {
                        matchedString += text.charAt(j);
                    }
                }

                System.out.println(matchedString);
                i += jump;
            }
        }

        if (!hasMatch) {
            System.out.println("no");
        }
    }
}

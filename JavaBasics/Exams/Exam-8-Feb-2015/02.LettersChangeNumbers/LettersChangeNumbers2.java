import java.util.Scanner;

public class LettersChangeNumbers2 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] words = scanner.nextLine().split("\\s+");

        double totalSum = 0;

        for (String word : words) {
            String numberAsString = word.substring(1, word.length()-1);
            double number = Integer.parseInt(numberAsString);

            number = executeFirstChar(word.charAt(0), number);
            number = executeSecondChar(word.charAt(word.length()-1), number);

            totalSum += number;
        }

        System.out.printf("%.2f",totalSum);
    }

    private static double executeFirstChar(char c, double number) {
        if (c >= 65 && c <= 90) {
            return number / (c - 64);
        } else {
            return number * (c - 96);
        }
    }

    private static double executeSecondChar(char c, double number) {
        if (c >= 65 && c <= 90) {
            return number - (c - 64);
        } else {
            return number + (c - 96);
        }
    }
}

import java.util.ArrayList;
import java.util.Scanner;

/**
 * Created by emily on 1/26/15.
 */
public class BePositive_Broken {
    public static void main(String[] args) {
        @SuppressWarnings("resource")
        Scanner scn = new Scanner(System.in);

        int countSequences = scn.nextInt();
        // the scanner should go to the next line to read the numbers
        scn.nextLine();

        for (int i = 0; i < countSequences; i++) {
            String[] input = scn.nextLine().trim().split(" ");
            ArrayList<Integer> numbers = new ArrayList<>();

            for (int j = 0; j < input.length; j++) {
                if (!input[j].equals("") ) {
                    // wrong index
                    int num = Integer.parseInt(input[j]);
                    numbers.add(num);
                }
            }

            boolean found = false;

            for (int j = 0; j < numbers.size(); j++) {
                int currentNum = numbers.get(j);

                // included 0
                if (currentNum >= 0) {
                    // switched " " and "\n"
                    System.out.printf("%d%s", currentNum, j == numbers.size() - 1 ? "\n" : " ");
                    found = true;
                } else {
                    // changed condition
                    if (j + 1 <= numbers.size() - 1) {
                        currentNum += numbers.get(j + 1);
                        j++;

                        // included 0
                        if (currentNum >= 0) {
                            // switched " " and "\n"
                            System.out.printf("%d%s", currentNum, j == numbers.size() - 1 ? "\n" : " ");
                            found = true;
                        }
                    }
                }
            }

            if (!found) {
                System.out.println("(empty)");
            }
        }
    }
}

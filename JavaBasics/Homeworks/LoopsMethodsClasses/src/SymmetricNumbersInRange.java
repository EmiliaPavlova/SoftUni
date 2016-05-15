
// Write a program to generate and print all symmetric numbers in given range [start…end] (0 ≤ start ≤ end ≤ 999).
// A number is symmetric if its digits are symmetric toward its middle. For example, the numbers 101, 33, 989 and 5
// are symmetric, but 102, 34 and 997 are not symmetric.

import java.util.Scanner;

public class SymmetricNumbersInRange {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int startNumber = input.nextInt();
        int endNumber = input.nextInt();
        for (int i = startNumber; i <= endNumber; i++) {
            if (symmetricNumber(i)) {
                System.out.print(i + " ");
            }
        }
    }

    public static Boolean symmetricNumber(int number){
        boolean symmetric = false;
        String input2 = Integer.toString(number);
        for (int i = 0; i <= input2.length() / 2; i++) {
            if (input2.charAt(i) == input2.charAt(input2.length() -1- i)) {
                symmetric = true;
            }
            else {
                symmetric = false;
                break;
            }
        }
        return symmetric;
    }
}
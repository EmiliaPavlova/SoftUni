import java.util.Scanner;

/**
 * Created by emily on 1/25/15.
 */

// Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point c and prints
// them in 4 virtual columns on the console. Each column should have a width of 10 characters. The number a should be
// printed in hexadecimal, left aligned; then the number a should be printed in binary form, padded with zeroes, then
// the number b should be printed with 2 digits after the decimal point, right aligned; the number c should be printed
// with 3 digits after the decimal point, left aligned.

public class FormattingNumbers {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int a = input.nextInt();
        if (a >= 0 && a <= 500) {
            float b = input.nextFloat();
            float c = input.nextFloat();
            String hex = Integer.toHexString(a);
            System.out.print("|");
            System.out.printf("%-10s", hex);
            System.out.print("|");
            //String binary = Integer.toBinaryString(a);
            //System.out.printf(String.format("%10s", binary).replace(' ', '0'));
            System.out.printf("%010d", a);
            System.out.print("|");
            System.out.printf("%10.2f", b);
            System.out.print("|");
            System.out.printf("%-10.3f", c);
            System.out.print("|");
        } else {
            System.out.print("Invalid input");
        }
    }
}

import java.util.Scanner;

/**
 * Created by emily on 1/25/15.
 */

// Write a program that enters a positive integer number num and converts and prints it in hexadecimal form. You may
// use some built-in method from the standard Java libraries.

public class DecimalToHexadecimal {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int integer = input.nextInt();
        String hex = Integer.toHexString(integer);
        System.out.println(hex.toUpperCase());
//        second way
//        int decimal = new Scanner(System.in).nextInt();
//        System.out.printf("Hexadecimal: %X", hex);
    }
}

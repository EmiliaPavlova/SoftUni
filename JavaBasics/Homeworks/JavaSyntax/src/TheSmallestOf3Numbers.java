import java.util.Scanner;

/**
 * Created by emily on 1/24/15.
 */

// Write a program that finds the smallest of three numbers.

public class TheSmallestOf3Numbers {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("side a = ");
        double a = input.nextDouble();
        System.out.print("side b = ");
        double b = input.nextDouble();
        System.out.print("side c = ");
        double c = input.nextDouble();
        double smallestNumber = Math.min(a, Math.min(b, c));
        if (smallestNumber == (int) smallestNumber) {
            System.out.printf("%.0f", smallestNumber);
        } else {
            System.out.printf("%.1f", smallestNumber);
        }

    }
}

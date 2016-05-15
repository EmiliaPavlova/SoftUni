import java.util.Scanner;

/**
 * Created by emily on 1/24/15.
 */

// Write a program that enters the sides of a rectangle (two integers a and b) and calculates and prints the rectangle's area.

public class RectangleArea {
    public static void main (String[] args) {
        Scanner size = new Scanner(System.in);
        System.out.print("side a = ");
        int a = size.nextInt();
        System.out.print("side b = ");
        int b = size.nextInt();

        System.out.println("Rectangle area is " + (a * b) + ".");
    }
}

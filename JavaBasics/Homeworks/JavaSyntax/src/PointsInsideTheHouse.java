import java.util.Scanner;

/**
 * Created by emily on 1/26/15.
 */

// Write a program to check whether a point is inside or outside the house below. The point is given as a pair of
// floating-point numbers, separated by a space. Your program should print "Inside" or "Outside".

public class PointsInsideTheHouse {
    public static void main (String[] args) {
        Scanner input = new Scanner (System.in);
        System.out.print("");
        float x = input.nextFloat();
        System.out.print("");
        float y = input.nextFloat();
        double abc = Math.abs (12.5 * (8.5 - 3.5) + 22.5 * (3.5 - 8.5) + 17.5 * (8.5 - 8.5)) / 2;
        double abp = Math.abs (12.5 * (8.5 - y) + 22.5 * (y - 8.5) + x * (8.5 - 8.5)) / 2;
        double apc = Math.abs (12.5 * (y - 3.5) + x * (3.5 - 8.5) + 17.5 * (8.5 - y)) / 2;
        double pbc = Math.abs (x * (8.5 - 3.5) + 22.5 * (3.5 - y) + 17.5 * (y - 8.5)) / 2;
        if (abc == abp + apc + pbc) {
            System.out.println("Inside");
        } else if ((x >= 12.5 && x <= 17.5 || x >= 20 && x <= 22.5) && y >= 8.5 && y <= 13.5) {
            System.out.println("Inside");
        } else {
            System.out.println("Outside");
        }
    }
}
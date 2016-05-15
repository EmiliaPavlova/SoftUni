import java.util.Scanner;

/**
 * Created by emily on 1/24/15.
 */

// Write a program to check whether a point is inside or outside of the figure below. The point is given as a pair of
// floating - point numbers, separated by a space. Your program should print "Inside" or "Outside".

public class PointsInsideAFigure {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("");
        float x = input.nextFloat();
        System.out.print("");
        float y = input.nextFloat();
        if (x >= 12.5 && x <= 22.5 && y >= 6 && y <= 8.5) {
            System.out.println("Inside");
        } else if ((x >= 12.5 && x <= 17.5 || x >= 20 && x <= 22.5) && y >= 8.5 && y <= 13.5) {
            System.out.println("Inside");
        } else {
            System.out.println("Outside");
        }
    }
}

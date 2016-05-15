import java.util.Scanner;

/**
 * Created by emily on 1/24/15.
 */

// Write a program that enters 3 points in the plane (as integer x and y coordinates), calculates and prints the area of
// the triangle composed by these 3 points. Round the result to a whole number. In case the three points do not form a
// triangle, print "0" as result.

public class TriangleArea {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println();
        double a1 = input.nextInt();
        double a2 = input.nextInt();
        input.nextLine();
        double b1 = input.nextInt();
        double b2 = input.nextInt();
        input.nextLine();
        double c1 = input.nextInt();
        double c2 = input.nextInt();
        // all sides powered by 2
        double ab = (Math.pow((a1 - b1), 2) + Math.pow((a2 - b2), 2));
        double bc = (Math.pow((b1 - c1), 2) + Math.pow((b2 - c2), 2));
        double ca = (Math.pow((c1 - a1), 2) + Math.pow((c2 - a2), 2));
        // (ab^2 + bc^2 - ca^2)
        double area = ab + bc - ca;
        // 4 * ab^2 * bc^2 - area^2
        area = 4 * ab * bc - Math.pow(area, 2);
        // 1/4 * root(area)
        area = Math.sqrt(area) / 4;
        System.out.print((int)area);
    }
}

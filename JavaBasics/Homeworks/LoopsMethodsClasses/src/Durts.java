import java.util.Scanner;

/**
 * Created by emily on 1/29/15.
 */
public class Durts {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int centerX = input.nextInt();
        int centerY = input.nextInt();
        int r = input.nextInt();
        // cross
        double verticalMinX = centerX - (0.5 * r);
        double verticalMaxX = centerX + (0.5 * r);
        double verticalMinY = centerY - r;
        double verticalMaxY = centerY + r;
        double horizontalMinX = centerX - r;
        double horizontalMaxX = centerX + r;
        double horizontalMinY = centerY - (0.5 * r);
        double horizontalMaxY = centerY + (0.5 * r);

        int n = input.nextInt();
        for (int i = 0; i < n; i++) {
            int x = input.nextInt();
            int y = input.nextInt();
            boolean inside = insideCross (x, y, verticalMinX, verticalMaxX, verticalMinY, verticalMaxY) ||
                    insideCross(x, y, horizontalMinX, horizontalMaxX, horizontalMinY, horizontalMaxY);
            System.out.println(inside ? "yes" : "no");
        }
    }

    public static boolean insideCross (int x, int y, double minX, double maxX, double minY, double maxY) {
        boolean inside = (x >= minX) && (x <= maxX) && (y >= minY) && (y <= maxY);
        return inside;
    }
}

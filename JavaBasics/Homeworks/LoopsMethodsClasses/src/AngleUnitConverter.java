// Write a method to convert from degrees to radians. Write a method to convert from radians to degrees. You are given a
// number n and n queries for conversion. Each conversion query will consist of a number + space + measure. Measures are
// "deg" and "rad". Convert all radians to degrees and all degrees to radians. Print the results as n lines, each holding
// a number + space + measure. Format all numbers with 6 digit after the decimal point.

import java.util.Scanner;

public class AngleUnitConverter {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int n = Integer.parseInt(input.nextLine());
        double[] numbers = new double[n];
        String[] measure = new String[n];
        for (int i = 0; i < n; i++) {
            if (input.hasNextDouble()) {
                numbers[i] = input.nextDouble();
            }
            if (input.hasNext()) {
                measure[i] = input.next();
            }
        }
        for (int j = 0; j < n; j++) {
            if (measure[j].equals("rad")) {
                radiansToDegrees(numbers[j]);
            } else if(measure[j].equals("deg")) {
                degreesToRadians(numbers[j]);
            }
        }

    }

    public static void degreesToRadians(double degrees){
        double radians = (degrees * (double)Math.PI) / 180.0d;
        System.out.printf("%.6f rad\n",radians);
    }

    public static void radiansToDegrees(double radians){
        double degrees = radians * (180.0d /(double)Math.PI);
        System.out.printf("%.6f deg\n ",degrees);
    }
}

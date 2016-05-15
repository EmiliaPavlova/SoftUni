// Write a program to calculate the difference between two dates in number of days. The dates are entered at two
// consecutive lines in format day-month-year. Days are in range [1…31]. Months are in range [1…12]. Years are in range
// [1900…2100].

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class DaysBetweenTwoDates {
    public static void main (String[] args) throws ParseException {
        Scanner input = new Scanner(System.in);
        System.out.print("Start date (dd-MM-yyyy): ");
        String startDate= input.nextLine();
        System.out.print("End date (dd-MM-yyyy): ");
        String endDate = input.nextLine();
        SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
        Date start = null;
        Date end = null;
        String dateToStart = startDate;
        String dateToStop = endDate;
        start = format.parse(dateToStart);
        end = format.parse(dateToStop);
        long difference = end.getTime() - start.getTime();
        long days = difference / (24 * 60 * 60 * 1000); // calculated in days
        System.out.println(days);
    }
}

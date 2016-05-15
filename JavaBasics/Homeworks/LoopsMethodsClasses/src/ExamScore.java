import java.util.Scanner;
import java.util.TreeMap;

/**
 * Created by emily on 1/30/15.
 */
public class ExamScore {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        input.nextLine();
        input.nextLine();
        input.nextLine();
        TreeMap<Integer, TreeMap<String, Double>> results = new TreeMap<>();
        while (true) {
            String[] entry = input.nextLine().split("\\s*\\|\\s*");
            if (entry.length < 4) {
                break;
            }
            String name = entry[1];
            int score = Integer.parseInt(entry[2]);
            double grade = Double.parseDouble(entry[3]);
            if (!results.containsKey(score)) {
                results.put(score, new TreeMap<>());
            }
            results.get(score).put(name, grade);
        }
        for (Integer score : results.keySet()) {
            System.out.print(score + " -> ");
            System.out.print(results.get(score).keySet()); // print keys of inner map (names)
            double sum = 0;
            for (double grade : results.get(score).values()) {
                sum += grade;
            }
            double avg = sum / results.get(score).values().size();
            System.out.printf("; avg=%.2f\n", avg);
        }
    }
}

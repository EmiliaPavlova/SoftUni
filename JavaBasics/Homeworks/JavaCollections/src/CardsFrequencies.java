// We are given a sequence of N playing cards from a standard deck. The input consists of several cards (face + suit),
// separated by a space. Write a program to calculate and print at the console the frequency of each card face in format
// "card_face -> frequency". The frequency is calculated by the formula appearances / N and is expressed in percentages
// with exactly 2 digits after the decimal point. The card faces with their frequency should be printed in the order of
// the card face's first appearance in the input. The same card can appear multiple times in the input, but it's face
// should be listed only once in the output.

import java.util.LinkedHashMap;
import java.util.Scanner;

public class CardsFrequencies {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] input = scan.nextLine().split("[^A-Z0-9]+");
        LinkedHashMap<String, Double> faces = new LinkedHashMap<>();
        for (String cardFace : input) {
            Double frequency = faces.get(cardFace);
            if (frequency == null) {
                frequency = 0d;
            }
            faces.put(cardFace, frequency + 1);
        }
        for (String face : faces.keySet()) {
            double frequency = faces.get(face);
            double percent = (frequency/(double)input.length) * 100;
            System.out.printf("%s -> %.2f%%", face, percent);
            System.out.println();
        }
    }
}

// Write a program to generate n random hands of 5 different cards form a standard suit of 52 cards.

import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class RandomHandsOf5Cards {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        Random rnd = new Random();
        char[] suits = {'\u2660','\u2665', '\u2663','\u2666' };
        String[] faces = {"2", "3", "4", "5", "6", "7", "8" ,"9", "10", "J", "Q", "K", "A"};
        ArrayList<String> fullDeck = new ArrayList<String>();
        for (String face : faces) {
            for (Character suit : suits) {
                fullDeck.add("" + face + (char)suit);
            }
        }
        ArrayList<String> pulledCards = new ArrayList<String>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < 5; j++) {
                int index = rnd.nextInt(fullDeck.size());
                String card = fullDeck.get(index);
                fullDeck.remove(index);
                pulledCards.add(card);
                System.out.printf("%s ", card);
            }
            System.out.println();
            //fullDeck.addAll(pulledCards);
        }
    }
}

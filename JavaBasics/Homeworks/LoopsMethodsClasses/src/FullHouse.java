// In most Poker games, the "full house" hand is defined as three cards of the same face + two cards of the same face,
// other than the first, regardless of the card's suits. The cards faces are "2", "3", "4", "5", "6", "7", "8", "9",
// "10", "J", "Q", "K" and "A". The card suits are "♣", "♦", "♥" and "♠". Write a program to generate and print all full
// houses and print their number.

public class FullHouse {
    public static void main (String[] args) {
        char[] suits = {'\u2660','\u2665', '\u2663','\u2666' };
        String[] cards = {"2", "3", "4", "5", "6", "7", "8" ,"9", "10", "J", "Q", "K", "A"};
        int count = 0;
        for (int threeCards = 0; threeCards < 13; threeCards++) {
            for (int twoCards = 0; twoCards < 13; twoCards++) {
                if (threeCards != twoCards) {
                    for (int suit1 = 0; suit1 < 4; suit1++) {
                        for (int suit2 = suit1 + 1; suit2 < 4; suit2++) {
                            for (int suit3 = suit2 + 1; suit3 < 4; suit3++) {
                                for (int suit4 = 0; suit4 < 4; suit4++) {
                                    for (int suit5 = suit4 + 1; suit5 < 4; suit5++) {
                                        System.out.printf ("%1$s%3$s %1$s%4$s %1$s%5$s %2$s%6$s %2$s%7$s \n", cards[threeCards],cards[twoCards],
                                                suits[suit1], suits[suit2], suits[suit3], suits[suit4], suits[suit5]);
                                        count ++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        System.out.print(count);
    }
}

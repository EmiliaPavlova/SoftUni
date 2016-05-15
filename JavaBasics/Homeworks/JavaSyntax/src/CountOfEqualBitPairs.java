import java.util.Scanner;

/**
 * Created by emily on 1/25/15.
 */

// Write a program to count how many sequences of two equal bits ("00" or "11") can be found in the binary representation
// of given integer number n (with overlapping).

public class CountOfEqualBitPairs {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int result = 0;
        String binary = Integer.toBinaryString(n);
        // System.out.print(binary);
        for (int i = 0; i < binary.length()-1; i++) {
            char bit1 = binary.charAt(i);
            char bit2 = binary.charAt(i+1);
            if (bit1 == bit2) {
                result += 1;
            }
        }
        System.out.println(result);
    }
}

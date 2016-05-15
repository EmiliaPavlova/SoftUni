import java.util.Scanner;

/**
 * Created by emily on 1/25/15.
 */

// Write a program to calculate the count of bits 1 in the binary representation of given integer number n.

public class CountOfBitsOne {
    public static void main (String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int result = 0;
        String binary = Integer.toBinaryString(n);
        // System.out.print(binary);
        for (int i = 0; i < binary.length(); i++) {
            char bit = binary.charAt(i);
            if (bit == '1') {
                result += 1;
            }
        }

//        second way
//        for (int i = 0; i < 32; i++) {
//            if ((n&1)==1) {
//                result++;
//            }
//            n = n>>1;
//        }

        System.out.print(result);
    }
}

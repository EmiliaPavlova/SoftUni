import java.util.Objects;
import java.util.Scanner;

/**
 * Created by emily on 1/27/15.
 */
public class BitRotation_Broken {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        byte number = Byte.parseByte(input.nextLine());
        byte rotations = Byte.parseByte(input.nextLine());

        for (int i = 0; i < rotations; i++) {
            String direction = input.nextLine();

            // compared strings with .equals()
            if (Objects.equals(direction, "right")) {
                int rightMostBit = number & 1;
                number >>= 1;
                //number 6 changed to 5
                number |= rightMostBit << 5; // moved 5 possition and OR with the rightMostBit
                // compared strings with .equals()
            } else if (Objects.equals(direction, "left")) {
                //number 6 changed to 5
                int leftMostBit = (number >> 5) & 1;
                number <<= 1;
                number |= leftMostBit;
                //
                number &= ~(1 << 6);
            }
        }

        System.out.println(number);
    }
}

import java.util.Scanner;

public class GandalfsStash {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int initialHappiness = Integer.parseInt(scan.nextLine());

        String[] objects = scan.nextLine().toLowerCase().split("[^a-zA-Z]+");

        for (String object : objects) {
            switch (object) {
                case "cram":
                    initialHappiness += 2;
                    break;
                case "lembas":
                    initialHappiness += 3;
                    break;
                case "apple":
                    initialHappiness += 1;
                    break;
                case "melon":
                    initialHappiness += 1;
                    break;
                case "honeycake":
                    initialHappiness += 5;
                    break;
                case "mushrooms":
                    initialHappiness -= 10;
                    break;
                default:
                    initialHappiness -= 1;
                    break;
            }
        }
        System.out.println(initialHappiness);
        if (initialHappiness < -5 ) {
            System.out.println("Angry");
        } else if (initialHappiness >= -5 && initialHappiness < 0) {
            System.out.println("Sad");
        } else if (initialHappiness >= 0 && initialHappiness < 15) {
            System.out.println("Happy");
        } else if (initialHappiness >= 15) {
            System.out.println("Special JavaScript mood");
        }
    }
}

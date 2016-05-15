
import java.util.ArrayList;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class BubbleSort {
    public static void main (String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbers = scan.nextLine().replace("[", "").replace("]", "").split(", ");
        ArrayList<Integer> numbersArr = new ArrayList<Integer>();

        //TODO: Parse the numbers and add them to the list
        for (int i = 0; i < numbers.length; i++) {
            numbersArr.add(Integer.parseInt(numbers[i]));
        }

//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();

        //TODO: Write the sorting algorithm that you use for sorting the List's elements
        for (int one = 0; one < numbersArr.size() - 1; one++) {
            for (int two = one + 1; two < numbersArr.size(); two++) {
                if (numbersArr.get(one) > numbersArr.get(two)) {
                    int temp = numbersArr.get(two);
                    numbersArr.set(two, numbersArr.get(one));
                    numbersArr.set(one, temp);
                }
            }
        }
//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time/1000.0);
    }
}
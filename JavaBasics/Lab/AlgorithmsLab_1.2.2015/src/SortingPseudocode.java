package sort.bubble;


import java.util.ArrayList;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class SortingPseudocode {

    public static void main(String[] args) {
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

        for (int i = 0; i < numbersArr.size() - 1;i++) {
            int minNum = i;
            for (int j = i + 1; j < numbersArr.size(); j++) {
                if (numbersArr.get(j) < numbersArr.get(minNum)) {
                    minNum = j;
                }
            }
            if (numbersArr.get(minNum) != numbersArr.get(i)) {
                int temp = numbersArr.get(i);
                numbersArr.set(i, numbersArr.get(minNum));
                numbersArr.set(minNum, temp);
            }

        }
//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time/1000.0);
    }
}
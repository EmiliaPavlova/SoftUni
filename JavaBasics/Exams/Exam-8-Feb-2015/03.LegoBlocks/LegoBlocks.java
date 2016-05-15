import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class LegoBlocks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        ArrayList<ArrayList<Integer>> firstArr = new ArrayList<>();
        ArrayList<ArrayList<Integer>> secondArr = new ArrayList<>();

        readInputMatrix(scanner, n, firstArr);
        readInputMatrix(scanner, n, secondArr);

        mergeMatrices(firstArr, secondArr);

        boolean isRectangular = false;
        int size = firstArr.get(0).size();
        for (int i = 1; i < firstArr.size(); i++) {
            if(size == firstArr.get(i).size()) {
                isRectangular = true;
            } else {
                isRectangular = false;
                break;
            }
        }

        if (isRectangular) {
            for (ArrayList<Integer> integers : firstArr) {
                System.out.println(integers);
            }
        } else {
            int count = 0;
            for (ArrayList<Integer> integers : firstArr) {
                count += integers.size();
            }
            System.out.printf("The total number of cells is: %d", count);
        }
    }

    private static void mergeMatrices(ArrayList<ArrayList<Integer>> firstArr, ArrayList<ArrayList<Integer>> secondArr) {
        for (int i = 0; i < firstArr.size(); i++) {
            Collections.reverse(secondArr.get(i));
            firstArr.get(i).addAll(secondArr.get(i));
        }
    }

    private static void readInputMatrix(Scanner scanner, int n, ArrayList<ArrayList<Integer>> arr) {
        for (int i = 0; i < n; i++) {
            arr.add(new ArrayList<>());
            String[] numsAsStrings = scanner.nextLine().trim().split("\\s+");
            for (String numsAsString : numsAsStrings) {
                arr.get(i).add(Integer.parseInt(numsAsString));
            }
        }
    }
}

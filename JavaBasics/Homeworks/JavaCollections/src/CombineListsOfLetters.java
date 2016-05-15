// Write a program that reads two lists of letters l1 and l2 and combines them: appends all letters c from l2 to the end
// of l1, but only when c does not appear in l1. Print the obtained combined list. All lists are given as sequence of
// letters separated by a single space, each at a separate line. Use ArrayList<Character> of chars to keep the input and
// output lists.

import java.util.ArrayList;
import java.util.Scanner;

public class CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char[] l1 = scan.nextLine().replaceAll(" ", "").toCharArray();
        char[] l2 = scan.nextLine().replaceAll(" ", "").toCharArray();
        ArrayList<Character> list1 = new ArrayList<>();
        ArrayList<Character> list2 = new ArrayList<>();
        for (int i = 0; i < l1.length; i++) {
            list1.add(l1[i]);
        }
        for (int i = 0; i < l2.length; i++) {
            list2.add(l2[i]);
        }
        list2.removeAll(list1);
        list1.addAll(list2);
        for (char chars : list1) {
            System.out.print(chars + " ");
        }
    }
}

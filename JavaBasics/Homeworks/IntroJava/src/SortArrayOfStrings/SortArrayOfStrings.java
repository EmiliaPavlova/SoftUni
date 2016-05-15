package SortArrayOfStrings;

import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfStrings {
	public static void main(String[] args) {
		Scanner number = new Scanner(System.in);
		System.out.print("n = ");
		int n = number.nextInt();
		String words[] = new String[n];
		
		for (int i = 0; i < n; i++) {
			words[i] = number.next();
		}
		
		Arrays.sort(words);
		
		for (int j = 0; j < words.length; j++) {
			System.out.println(words[j]);
		}
	}
}
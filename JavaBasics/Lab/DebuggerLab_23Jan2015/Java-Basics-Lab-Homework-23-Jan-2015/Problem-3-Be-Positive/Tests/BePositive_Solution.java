import java.util.ArrayList;
import java.util.Scanner;

public class BePositive_Solution {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		// get N with nextLine() and parse
		int countSequences = Integer.parseInt(scn.nextLine());
		
		for (int i = 0; i < countSequences; i++) {
			String[] input = scn.nextLine().trim().split(" ");
			ArrayList<Integer> numbers = new ArrayList<>();
			
			for (int j = 0; j < input.length; j++) {
				if (!input[j].equals("")) {
					int num = Integer.parseInt(input[j]); // parse and add input[j], not input[i]
					numbers.add(num);
				}
			}
			
			boolean found = false;
			
			for (int j = 0; j < numbers.size(); j++) {				
				int currentNum = numbers.get(j);
				
				// print non-negative => when currentNum >= 0, instead of currentNum > 0
				if (currentNum >= 0) {
					// j != numbers.size() instead of j == numbers.size()
					System.out.printf("%d%s", currentNum, j != numbers.size() - 1 ? " " : "\n");
					found = true;
				} 
				
				// check if j is not the last index, otherwise j++ => IndexOutOfBoundsException
				else if (j != numbers.size() - 1) { 
					currentNum += numbers.get(j + 1);
					j++; // increment j
					
					if (currentNum >= 0) {
						// j != numbers.size() instead of j == numbers.size()
						System.out.printf("%d%s", currentNum, j != numbers.size() - 1 ? " " : "\n");
						found = true;
					}					
				}
			}
			
			if (!found) {
				System.out.println("(empty)");
			} 			
		}		
	}
}

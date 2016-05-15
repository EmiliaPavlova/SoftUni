import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class _03_LargestSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String words = input.nextLine();
		String[] wordList = words.split(" ");
		Map<String, Integer> counters = new TreeMap<String, Integer>();
		for (String str : wordList) {
			Integer count = counters.get(str);
			if (count == null) {
				count = 0;
			}
			counters.put(str, count + 1);
		}
		Map.Entry<String, Integer> maxEntry = null;
		for (Map.Entry<String, Integer> entry : counters.entrySet()) {
			if (maxEntry == null
					|| entry.getValue().compareTo(maxEntry.getValue()) > 0) {
				maxEntry = entry;
			}
		}
		for (int i = 0; i < maxEntry.getValue(); i++) {
			System.out.print(maxEntry.getKey() + " ");
		}
	}

}

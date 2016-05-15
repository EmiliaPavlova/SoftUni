import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class UserLogs {

	public static void main(String[] args) {
		TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
		
		Scanner scan = new Scanner(System.in);
		
		String command = scan.nextLine();
		
		while (!command.equals("end")) {
			String input[] = command.split(" ");
			
			String[] ipElements = input[0].split("=");
			String ip = ipElements[1];
			
			String[] userElements = input[2].split("="); 
			String user = userElements[1];
			
			insertData(data, ip, user);
			
			command = scan.nextLine();
		}
		
		printData(data);
	}

	private static void insertData(
			TreeMap<String, LinkedHashMap<String, Integer>> data,
			String ip,
			String user) {
		
		if (!data.containsKey(user)) {
			data.put(user, new LinkedHashMap<String, Integer>());
			data.get(user).put(ip, 1);
		}
		else {
			Integer count = 0;
			if (data.get(user).containsKey(ip)) {
				count = data.get(user).get(ip);
			}
			
			data.get(user).put(ip, count + 1);
		}
	}
	
	private static void printData(
			TreeMap<String, LinkedHashMap<String, Integer>> data) {
		
		for(Map.Entry<String,LinkedHashMap<String, Integer>> entry : data.entrySet()) {
			  String user = entry.getKey();
			  LinkedHashMap<String, Integer> hashMap = entry.getValue();

			  System.out.println(user + ": ");
			  
			  for(Map.Entry<String,Integer> secondEntry : hashMap.entrySet()) {
				  String ip = secondEntry.getKey();
				  Integer count = secondEntry.getValue();

				  System.out.print(ip + " => " + count);
				  String lastKey = getLastKey(hashMap);
				  
				  if (ip.equals(lastKey)) {
					  System.out.print(".");
				  }
				  else {
					  System.out.print(", ");  
				  }
			  }
			  
			  System.out.println();
		}
	}
	
	public static String getLastKey(LinkedHashMap<String, Integer> hashMap) {
		  String out = "";
		  for (String key : hashMap.keySet()) {
		    out = key;
		  }
		  return out;
	}

}

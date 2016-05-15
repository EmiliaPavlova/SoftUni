// Write a program to read a text file "Input.txt" holding a sequence of integer numbers, each at a separate line. Print
// the sum of the numbers at the console. Ensure you close correctly the file in case of exception or in case of normal
// execution. In case of exception (e.g. the file is missing), print "Error" as a result.

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;

public class SumNumbersFromATextFile {
    public static void main (String[] args) {
        try{
            BufferedReader reader = new BufferedReader(new FileReader("src/Input.txt"));
            BufferedWriter writer = new BufferedWriter(new FileWriter("src/Input_copy.txt"));
            String line;
            int sum = 0;
            while ((line = reader.readLine()) != null) {
                int number = Integer.parseInt(line);
                sum+=number;
            }
            writer.write(String.format("%s", sum));
            System.out.print(sum);
            writer.close();
            reader.close();
        }catch(Exception exeption){
            System.out.println("Error");
            exeption.printStackTrace();
        }
    }
}

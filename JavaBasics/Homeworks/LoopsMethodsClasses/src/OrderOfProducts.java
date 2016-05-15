import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;

/**
 * Created by emily on 1/29/15.
 */
public class OrderOfProducts {
    public static void main (String[] args) {
        ArrayList<Product> products = new ArrayList<Product>();
        try {
            BufferedReader reader = new BufferedReader(new FileReader("src/Products.txt"));
            String input = null;
            while ((input = reader.readLine()) != null) {
                String[] splitted = input.split(" ");
                products.add(new Product(splitted[0], Double.parseDouble(splitted[1])));
            }
        }catch (Exception exception) {
            System.err.println("Error");
            exception.printStackTrace();
        }
        double result = 0;
        try {
            BufferedReader reader = new BufferedReader(new FileReader("src/Order.txt"));
            String input = null;
            while ((input = reader.readLine()) != null) {
                String[] splitted = input.split(" ");
                double quantity = Double.parseDouble(splitted[0]);
                String currentProduct = splitted[1];
                for (Product product : products) {
                    if (product.getName().equals(currentProduct)) {
                        result += quantity * product.getPrice();
                    }
                }
            }
            reader.close();
        }catch (Exception exception) {
            System.err.println("Error");
            exception.printStackTrace();
        }
        try (BufferedWriter writer = new BufferedWriter(new FileWriter("src/Output_ordered_products.txt"))) {
            writer.write(String.format("%.2f", result));
            writer.close();
        }catch (Exception exception) {
            System.err.println("Error");
            exception.printStackTrace();
        }

    }
}

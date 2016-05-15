// Create a class Product to hold products, which have name (string) and price (decimal number). Read from a text file
// named "Input.txt" a list of products. Each product will be in format name + space + price. You should hold the products
// in objects of class Product. Sort the products by price and write them in format price + space + name in a file named
// "Output.txt". Ensure you close correctly all used resources.

import java.io.*;
import java.util.ArrayList;
import java.util.Collections;

public class ListOfProducts {
    public static void main (String[] args) {
        ArrayList<Product> products = new ArrayList<Product>();
        try {
            BufferedReader reader = new BufferedReader(new FileReader("src/Input_products.txt"));
            BufferedWriter writer = new BufferedWriter(new FileWriter("src/Output.txt"));
            String input;
            while ((input = reader.readLine()) != null) {
                String[] splited = input.split(" ");
                products.add(new Product(splited[0], Double.parseDouble(splited[1])));
            }
            Collections.sort(products);
            for (Product product : products) {
                writer.write(product.getPrice() + " " + product.getName() +"\r\n");
                System.out.printf("%1$.2f %2$s\n", product.getPrice(), product.getName());
            }
            reader.close();
            writer.close();
        } catch (IOException exeption) {
            System.out.println("Error");
            exeption.printStackTrace();
        }
    }
}
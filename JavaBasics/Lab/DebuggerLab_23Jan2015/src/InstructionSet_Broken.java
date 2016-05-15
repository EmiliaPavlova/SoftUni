import java.util.Scanner;

/**
 * Created by emily on 1/26/15.
 */
public class InstructionSet_Broken {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String opCode = input.nextLine();

        while (!opCode.equals("END")) {
            String[] codeArgs = opCode.split(" ");

            long result = 0;
            switch (codeArgs[0]) {
                case "INC": {
                    long operandOne = Integer.parseInt(codeArgs[1]);
                    // cast to long
                    result = (long) operandOne + 1;
                    break;
                }
                case "DEC": {
                    int operandOne = Integer.parseInt(codeArgs[1]);
                    // cast to long
                    result = (long) operandOne - 1;
                    break;
                }
                case "ADD": {
                    int operandOne  = Integer.parseInt(codeArgs[1]);
                    int operandTwo = Integer.parseInt(codeArgs[2]);
                    // cast to long only one int
                    result = (long) operandOne + operandTwo;
                    break;
                }
                case "MLA": {
                    int operandOne  = Integer.parseInt(codeArgs[1]);
                    int operandTwo = Integer.parseInt(codeArgs[2]);
                    // cast to long only one int
                    result = (long)operandOne * operandTwo;
                    break;
                }
                default:
                    break;
            }
            //jumping to tne next line to read "END"
            opCode = input.nextLine();
            System.out.println(result);
        }
    }
}

// Write a program to extract all email addresses from given text. The text comes at the first input line. Print the
// emails in the output, each at a separate line. Emails are considered to be in format <user>@<host>, where:
// - <user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them.
// - <host> is a sequence of at least two words, separated by dots '.'. Each word is sequence of letters and can have
// hyphens '-' between the letters.
// - Example of valid emails: info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net,
// info-bg@software-university.software.academy.

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ExtractEmails {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String email = "[\\w-+]+(?:\\.[\\w-+]+)*@(?:[\\w-]+\\.)+[a-zA-Z]{2,7}";
        Pattern pat = Pattern.compile(email);
        Matcher match = pat.matcher(text);
        while (match.find()) {
            System.out.println(match.group());
        }
    }
}

package DeckOfCards;

import java.io.FileOutputStream;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

public class DeckOfCards {
	public static void main(String args[]) {
		Document cardsPDF = new Document();
		try {
			PdfWriter.getInstance(cardsPDF, new FileOutputStream("Deck-of-Cards.pdf"));
			cardsPDF.open();
			
			// Table
			PdfPTable table = new PdfPTable(4);
			table.setWidthPercentage(70F);
			table.getDefaultCell().setFixedHeight(100F);
			
			// Font
			BaseFont baseFont = BaseFont.createFont("arialbd.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
			Font black = new Font(baseFont, 30F, 0, BaseColor.BLACK);
			Font red = new Font(baseFont, 30F, 0, BaseColor.RED);
			
			// Cards
			String card = "";
			String face = "";
			char suit = ' ';
			// Cards Face
			for (int f = 14; f >= 2; f--) {
				switch (f) {
					case 10: face = f + " "; break;
					case 11: face = "J "; break;
					case 12: face = "Q "; break;
					case 13: face = "K "; break;
					case 14: face = "A "; break;
					default: face = f + " "; break;
				}
				// Cards Suit
				for (int s = 1; s <= 4; s++) {
					switch (s) {
						case 1: suit = '\u2660'; break;
						case 2: suit = '\u2665'; break;
						case 3: suit = '\u2666'; break;
						case 4: suit = '\u2663'; break;
					}
					
					// Set SuitColor
					card = face + suit;
					if (s == 1 || s == 4) {
						table.addCell(new Paragraph(card, black));
					} 
					else if (s == 2 || s == 3) {
						table.addCell(new Paragraph(card, red));
					}
				}
			}
			// Insert the Table in the Document
			cardsPDF.add(table);
			cardsPDF.close();
		} 
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}

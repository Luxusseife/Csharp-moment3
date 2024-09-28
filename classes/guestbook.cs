// Laddar paket för lagring på fil i JSON-format.
using System.Text.Json;
using System.IO;

// Gemensamt namespace för samtliga filer.
namespace Moment3
{
    // Klassen Guestbook hanterar allt relaterat till gästboken.
    class Guestbook
    {
        // Lista som lagrar alla gästboksinlägg.
        private List<Entry> entryList { get; set; } = new List<Entry>();

        // Filväg där gästboksinläggen sparas i JSON-format.
        private readonly string filePath = "guestbook.json";

        // Lägger till ett nytt gästboksinlägg i listan och sparar det.
        public void AddEntry(Entry entry)
        {
            // Lägger till det nya inlägget i listan över gästboksinlägg.
            entryList.Add(entry);

            // Skriver ut ett bekräftelsemeddelande till användaren.
            Console.WriteLine("\nDitt inlägg är tillagt!");

            // Sparar alla inlägg, inklusive det nya, till filen.
            SaveEntries();
        }

        // Serialiserar och sparar alla gästboksinlägg till en JSON-fil.
        private void SaveEntries()
        {
            // Konverterar listan med inlägg till en JSON-sträng.
            string jsonString = JsonSerializer.Serialize(entryList);

            // Skriver över JSON-strängen till filen.
            File.WriteAllText(filePath, jsonString);
        }

        // Läser in alla gästboksinlägg från JSON-filen om det finns sparade inlägg.
        public void LoadEntries()
        {
            // Kontrollerar filens existens innan den läses in.
            if (File.Exists(filePath))
            {
                // Läser in JSON-strängen från filen.
                string jsonString = File.ReadAllText(filePath);

                // Konverterar JSON-strängen tillbaka till en lista av gästboksinlägg.
                entryList = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? new List<Entry>();
            }
        }

        // Visar alla gästboksinlägg. 
        public void DisplayAllEntries()
        {
            // Om listan är tom visas ett meddelande.
            if (entryList.Count == 0)
            {
                Console.WriteLine("\nGästboken är tom.");
                // Avbryter metoden om gästboken är tom.
                return;
            }
            // Om listan innehåller inlägg...
            else
            {
                // LIstan skrivs ut med serialiserade index framför.
                Console.WriteLine("\n--- GÄSTBOKSINLÄGG ---\n");

                // Loopar igenom hela listan och skriver ut varje sparat inlägg med index.
                for (int i = 0; i < entryList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {entryList[i].Name} - {entryList[i].Message}");
                }
            }
        }

        // Raderar ett gästboksinlägg baserat på angivet index.
        public void DeleteEntry(int index)
        {
            // Kontrollerar om index är giltigt, saknas från input eller är felaktigt.
            if (index > 0 && index <= entryList.Count)
            {
                // Om giltigt index angivits, raderas inlägget.
                entryList.RemoveAt(index - 1);

                // Bekräftelse-meddelande skickas till användaren.
                Console.WriteLine("\nDet angivna inlägget är raderat.");

                // Sparar och uppdaterar listan efter radering.
                SaveEntries(); 
            }
            else
            {
                // Visar felmeddelande till användaren.
                Console.WriteLine("\nDu har angivit ett ogiltigt index, försök igen.");
            }
        }
    }
}
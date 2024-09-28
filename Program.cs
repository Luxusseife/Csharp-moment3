// Gemensamt namespace för samtliga filer.
namespace Moment3;

class Program
{
    static void Main(string[] args)
    {
        // Skapar ett nytt objekt utifrån mallen i guestbooks-klassen.
        var guestbook = new Guestbook();

        // Läser in den sparade listan/gästboken.
        guestbook.LoadEntries();

        // Initierar input-variabel.
        string? userInput;

        // Loopen fortsätter tills användaren väljer att avsluta.
        do
        {
            // Rensar konsollen innan varje "meny" visas.
            Console.Clear();

            // Skriver ut en "meny" för gästboken.
            Console.WriteLine("\nV Ä L K O M M E N  T I L L  J E N N Y S  G Ä S T B O K !");
            Console.WriteLine("\nVälj ett av följande val:");
            Console.WriteLine("\n1 - Gör ett gästboksinlägg.");
            Console.WriteLine("2 - Visa alla gästboksinlägg.");
            Console.WriteLine("3 - Ta bort ett gästboksinlägg.");
            Console.WriteLine("\nX - Avsluta appen.\n");

            // Läser in användarens input.
            userInput = Console.ReadLine();

            // Olika cases körs beroende på användarens input.
            switch (userInput)
            {
                // Skapar ett nytt gästboksinlägg efter att ha fått input från användaren.
                case "1":
                    // Ber om input och läser in det.
                    Console.WriteLine("\nSkriv in ditt namn:");
                    string? name = Console.ReadLine();
                    Console.WriteLine("\nSkriv in ditt meddelande:");
                    string? message = Console.ReadLine();

                    // Om namn eller meddelande har angivits korrekt skapas ett inlägg.
                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(message))
                    {
                        // Skapar ett nytt objekt utifrån mallen i entry-klassen.
                        var newEntry = new Entry(name, message);
                        guestbook.AddEntry(newEntry);
                    }
                    // Om fälten lämnats tomma, visas ett felmeddelande.
                    else
                    {
                        Console.WriteLine("\nBåde namn och meddelande behöver anges. Inga tomma fält accepteras.");
                    }
                    break;

                // Visar alla befintliga gästboksinlägg.
                case "2":
                    // Anropar metoden som visar alla inlägg.
                    guestbook.DisplayAllEntries();
                    break;

                // Raderar ett gästboksinlägg baserat på index som anges av användaren.
                case "3":
                    // Ber om input.
                    Console.WriteLine("\nAnge index för inlägget du önskar radera:\n");

                    // Initierar variabel för index som ska raderas.
                    int indexToDelete;

                    // Försöker konvertera användarens input till ett giltigt heltal (index).
                    if (int.TryParse(Console.ReadLine(), out indexToDelete))
                    {
                        // Om konverteringen lyckas, raderas gästboksinlägget.
                        guestbook.DeleteEntry(indexToDelete);
                    }
                    // Om konverteringen misslyckas, visas ett felmeddelande.
                    else
                    {
                        Console.WriteLine("\nOgiltigt index har angivits. Försök igen!");
                    }
                    break;

                // Avslutar programmet med ett avskedsmeddelande.
                case "X":
                case "x":
                    // Visar meddelande.
                    Console.WriteLine("\nAppen avslutas. Ha en bra dag!");
                    break;

                // Visar ett felmeddelande vid ogiltigt val.
                default:
                    Console.WriteLine("\nEtt felaktigt val har gjorts. Försök igen!");
                    break;
            }

            // Ber användaren trycka på ENTER för att gå vidare med valet som gjorts.
            Console.WriteLine("\nTryck på ENTER för att fortsätta.");
            Console.ReadLine();

        // Loopen avslutas när användaren väljer att avsluta med X eller x.
        } while (userInput?.ToUpper() != "X");
    }
}

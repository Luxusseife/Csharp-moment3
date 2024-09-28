// Gemensamt namespace för samtliga filer.
namespace Moment3
{
    // Klassen Entry representerar ett gästboksinlägg.
    class Entry
    {
        // Konstruktor för att skapa ett nytt gästboksinlägg med namn och meddelande.
        public Entry(string name, string message)
        {
            // Tilldelar värden till egenskaperna.
            Name = name;
            Message = message;
        }

        // Publika egenskaper för att lagra namn och meddelande.
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
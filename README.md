Ladda ner projektet som en zip fil och extrahera den till skrivbordet.
Öppna projektet med .sln filen i mappen, sen klickar du på properties under HotelBookingApp solutionen, och väljer sedan references och därefter “Add reference”, och kryssar i DAL och RestAPI.

Få databasen i projektet:

1. Kör scriptet för databasen i SQL Manager studio
2. I projektet DAL i Visual Studio lägger du till en ny item, välj där ADO.NET SQL Entity model, följ anvisningarna och lägg till ditt Server namn från SQL Manager.
3. Nu ska SQL & Visual Studio länka tillsammans och databasen kommer att autogenereras i projektet.
4. För att lägga till/ta bort exempelvis ett hotell kan du antingen göra en query i SQL Manager eller i Visual Studios server explorer
5. Kör queryn och välj “Build Soulition” för att uppdatera och kontrollera så att inga felkoder dykt upp
6. Kör programmet och kontrollera att dina ändringar i databasen har fungerat

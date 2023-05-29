namespace Dz16_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PoemCollection collection = new PoemCollection();

            Poem poem1 = new Poem
            {
                Title = "The Raven",
                Author = "Edgar Allan Poe",
                Year = 1845,
                Text = "Once upon a midnight dreary...",
                Theme = "Gothic"
            };
            collection.AddPoem(poem1);
            Console.WriteLine("Add poem 1 to file");

            Poem poem2 = new Poem
            {
                Title = "If",
                Author = "Rudyard Kipling",
                Year = 1910,
                Text = "If you can keep your head when all about you...",
                Theme = "Inspiration"
            };
            collection.AddPoem(poem2);
            Console.WriteLine("Add poem 2 to file");

            Poem poem3 = new Poem
            {
                Title = "The Road Not Taken",
                Author = "Robert Frost",
                Year = 1916,
                Text = "Two roads diverged in a yellow wood...",
                Theme = "Reflection"
            };
            collection.AddPoem(poem3);
            Console.WriteLine("Add poem 3 to file\n");

            List<Poem> poemsWithTitle = collection.SearchPoemsByTitle("The Raven");
            Console.WriteLine("Search poem with title 'Raven':");
            PrintPoems(poemsWithTitle);

            List<Poem> poemsWithAuthor = collection.SearchPoemsByAuthor("Edgar Allan Poe");
            Console.WriteLine("Search poem with author 'Edgar Allan Poe':");
            PrintPoems(poemsWithAuthor);

            List<Poem> poemsWithYear = collection.SearchPoemsByYear(1910);
            Console.WriteLine("Search poem with year of wrote '1910':");
            PrintPoems(poemsWithYear);

            List<Poem> poemsWithTheme = collection.SearchPoemsByTheme("Inspiration");
            Console.WriteLine("Search poem with theme 'Inspiration':");
            PrintPoems(poemsWithTheme);

            Poem poemToUpdate = poemsWithAuthor[0];
            Poem updatedPoem = new Poem
            {
                Title = "The Raven",
                Author = "Edgar Allan Poe",
                Year = 1845,
                Text = "Once upon a midnight dreary, while I pondered, weak and weary...",
                Theme = "Gothic, Horror"
            };
            collection.UpdatePoem(poemToUpdate, updatedPoem);
            Console.WriteLine("Poem 1 was updated\n");

            collection.RemovePoem(poem3);
            Console.WriteLine("Poem 3 was deleted\n");

            collection.SaveCollectionToFile("poems.txt");
            Console.WriteLine("Poems was saved to file\n");

            PoemCollection loadedCollection = new PoemCollection();
            loadedCollection.LoadCollectionFromFile("poems.txt");
            Console.WriteLine("Poems was loaded from file:");
            PrintPoems(loadedCollection.GetAllPoems());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Reports:\n");
            Console.Write("Enter title to make the report: ");
            string reportTitle = Console.ReadLine();
            List<Poem> poemsByTitle = collection.GenerateReportByTitle(reportTitle);
            Console.WriteLine($"Report for poems with title '{reportTitle}':");
            PrintPoems(poemsByTitle);

            Console.Write("Enter author to make the report: ");
            string reportAuthor = Console.ReadLine();
            List<Poem> poemsByAuthor = collection.GenerateReportByAuthor(reportAuthor);
            Console.WriteLine($"Report for poems by author '{reportAuthor}':");
            PrintPoems(poemsByAuthor);

            Console.Write("Enter theme to make the report: ");
            string reportTheme = Console.ReadLine();
            List<Poem> poemsByTheme = collection.GenerateReportByTheme(reportTheme);
            Console.WriteLine($"Report for poems with theme '{reportTheme}':");
            PrintPoems(poemsByTheme);

            Console.Write("Enter text to make the report: ");
            string reportWord = Console.ReadLine();
            List<Poem> poemsByWord = collection.GenerateReportByWordInText(reportWord);
            Console.WriteLine($"Report for poems containing the word '{reportWord}' in the text:");
            PrintPoems(poemsByWord);

            Console.Write("Enter year to make the report: ");
            int reportYear = int.Parse(Console.ReadLine());
            List<Poem> poemsByYear = collection.GenerateReportByYear(reportYear);
            Console.WriteLine($"Report for poems written in the year {reportYear}:");
            PrintPoems(poemsByYear);

            Console.Write("Enter the length of poem for the report: ");
            int reportLength = int.Parse(Console.ReadLine());
            List<Poem> poemsByLength = collection.GenerateReportByLength(reportLength);
            Console.WriteLine($"Report for poems with a length of {reportLength} characters:");
            PrintPoems(poemsByLength);
        }

        static void PrintPoems(List<Poem> poems)
        {
            if (poems.Count > 0)
            {
                foreach (Poem poem in poems)
                {
                    Console.WriteLine($"Title: {poem.Title}");
                    Console.WriteLine($"Author: {poem.Author}");
                    Console.WriteLine($"Year: {poem.Year}");
                    Console.WriteLine($"Text: {poem.Text}");
                    Console.WriteLine($"Theme: {poem.Theme}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No poems found with the given characteristics\n");
            }
        }
    }
}
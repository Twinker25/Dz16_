using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz16_
{
    class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }
    }

    class PoemCollection
    {
        private List<Poem> poems;

        public PoemCollection()
        {
            poems = new List<Poem>();
        }

        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public void RemovePoem(Poem poem)
        {
            poems.RemoveAll(p => p.Title == poem.Title && p.Author == poem.Author && p.Year == poem.Year && p.Theme == poem.Theme);
        }

        public void UpdatePoem(Poem oldPoem, Poem newPoem)
        {
            int index = poems.IndexOf(oldPoem);
            if (index != -1)
            {
                poems[index] = newPoem;
            }
        }

        public List<Poem> SearchPoemsByTitle(string title)
        {
            return poems.FindAll(p => p.Title.ToLower().Contains(title.ToLower()));
        }

        public List<Poem> SearchPoemsByAuthor(string author)
        {
            return poems.FindAll(p => p.Author.ToLower().Contains(author.ToLower()));
        }

        public List<Poem> SearchPoemsByYear(int year)
        {
            return poems.FindAll(p => p.Year == year);
        }

        public List<Poem> SearchPoemsByTheme(string theme)
        {
            return poems.FindAll(p => p.Theme.ToLower().Contains(theme.ToLower()));
        }

        public void SaveCollectionToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Poem poem in poems)
                {
                    writer.WriteLine(poem.Title);
                    writer.WriteLine(poem.Author);
                    writer.WriteLine(poem.Year);
                    writer.WriteLine(poem.Text);
                    writer.WriteLine(poem.Theme);
                }
            }
        }

        public void LoadCollectionFromFile(string fileName)
        {
            poems.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string title = reader.ReadLine();
                    string author = reader.ReadLine();
                    int year = int.Parse(reader.ReadLine());
                    string text = reader.ReadLine();
                    string theme = reader.ReadLine();

                    Poem poem = new Poem
                    {
                        Title = title,
                        Author = author,
                        Year = year,
                        Text = text,
                        Theme = theme
                    };

                    poems.Add(poem);
                }
            }
        }

        public List<Poem> GetAllPoems()
        {
            return poems;
        }




        public List<Poem> GenerateReportByTitle(string title)
        {
            return poems.FindAll(p => p.Title.ToLower().Contains(title.ToLower()));
        }

        public List<Poem> GenerateReportByAuthor(string author)
        {
            return poems.FindAll(p => p.Author.ToLower().Contains(author.ToLower()));
        }

        public List<Poem> GenerateReportByTheme(string theme)
        {
            return poems.FindAll(p => p.Theme.ToLower().Contains(theme.ToLower()));
        }

        public List<Poem> GenerateReportByWordInText(string word)
        {
            return poems.FindAll(p => p.Text.ToLower().Contains(word.ToLower()));
        }

        public List<Poem> GenerateReportByYear(int year)
        {
            return poems.FindAll(p => p.Year == year);
        }

        public List<Poem> GenerateReportByLength(int length)
        {
            return poems.FindAll(p => p.Text.Length >= length);
        }
    }
}

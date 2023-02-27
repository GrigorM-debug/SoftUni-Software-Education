using System.Net.Http.Headers;

string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

string title = input[0];
string content = input[1];
string author = input[2];

Article article = new Article(title, content, author);


int numberOfInputs = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfInputs; i++)
{
    string[] commandInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

    string command = commandInfo[0];
    string newValue = commandInfo[1];

    switch (command)
    {
        case "Edit":
            article.Edit(newValue);
            break;
        case "ChangeAuthor":
            article.ChangeAuthor(newValue);
            break;
        case "Rename":
            article.Rename(newValue);
            break;
    }
}
Console.WriteLine(article);


class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }

    public void Edit(string content)
    {
        Content = content;
    }

    public void ChangeAuthor(string author)
    {
        Author = author;
    }

    public void Rename(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
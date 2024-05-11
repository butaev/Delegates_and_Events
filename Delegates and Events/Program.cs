namespace Delegates_and_Events;

public static class Program
{
    private static void Main()
    {
        var collection = new List<string>() { "1", "-100", "137" };
        Console.WriteLine($"Максимальное значение в коллекции: {collection.GetMax(float.Parse)}");

        var searcher = new FileSearcher();

        searcher.FileFound += OnSearcherOnFileFound;
        searcher.Search("C:\\otus");
        searcher.FileFound -= OnSearcherOnFileFound;
    }

    private static void OnSearcherOnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"Найден файл: {e.FileName}");
        if (e.FileName == "otus.txt")
        {
            e.CancelRequested = true;
            Console.WriteLine("Отмена поиска");
        }
    }
}
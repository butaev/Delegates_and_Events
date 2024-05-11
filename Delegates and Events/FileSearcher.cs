namespace Delegates_and_Events;

public class FileSearcher
{
    public event EventHandler<FileArgs>? FileFound;

    public void Search(string directory)
    {
        foreach (var file in Directory.EnumerateFiles(directory))
        {
            var args = RaiseFileFound(Path.GetFileName(file));
            if (args.CancelRequested)
            {
                break;
            }
        }
    }

    private FileArgs RaiseFileFound(string file)
    {
        var args = new FileArgs(file);
        FileFound?.Invoke(this, args);
        return args;
    }
}
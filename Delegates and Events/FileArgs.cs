namespace Delegates_and_Events;

public class FileArgs : EventArgs
{
    public string FileName { get; }
    public bool CancelRequested { get; set; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}
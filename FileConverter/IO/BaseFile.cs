namespace FileConverter.IO;

public abstract class BaseFile
{
    protected string Filename { get; }

    protected BaseFile(string filename)
    {
        Filename = filename;
    }
}
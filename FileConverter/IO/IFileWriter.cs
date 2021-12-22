namespace FileConverter.IO;

public interface IFileWriter
{
    void Write(IEnumerable<object> value);
}
using ChoETL;

namespace FileConverter.IO;

public class CsvFile : BaseFile, IFileIO
{
    private const char GroupChar = '_';

    public CsvFile(string filename) : base(filename)
    {

    }

    public List<object> Read()
    {
        var inputText = File.ReadAllText(Filename);

        using var data = ChoCSVReader.LoadText(inputText).WithFirstLineHeader().Configure(c => c.NestedColumnSeparator = GroupChar);

        return data.ToList();
    }

    public void Write(IEnumerable<object> file)
    {
        using var parser = new ChoCSVWriter(Filename).WithFirstLineHeader();

        parser.Write(file);
    }
}
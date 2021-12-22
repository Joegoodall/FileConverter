using ChoETL;
using System.Text.Json;

namespace FileConverter.IO;

public class JsonFile : BaseFile, IFileIO
{
    public JsonFile(string filename) : base(filename)
    {

    }

    public List<object> Read()
    {
        var inputText = File.ReadAllText(Filename);

        using var data = ChoJSONReader.LoadText(inputText);

        return data.ToList();
    }

    public void Write(IEnumerable<object> value)
    {
        var json = JsonSerializer.Serialize(value);

        File.WriteAllText(Filename, json);
    }
}
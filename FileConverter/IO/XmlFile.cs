using ChoETL;

namespace FileConverter.IO;

public class XmlFile : BaseFile, IFileIO
{
    public XmlFile(string filename) : base(filename)
    {

    }

    public List<object> Read()
    {
        var inputText = File.ReadAllText(Filename);

        using var data = ChoXmlReader.LoadText(inputText);

        var result = new List<object>();

        foreach (var item in data.OfType<ChoDynamicObject>())
        {
            item.DynamicObjectName = null; // Removes Row_ prefix when writing

            result.Add(item);
        }

        return result;
    }

    public void Write(IEnumerable<object> value)
    {
        using var parser = new ChoXmlWriter(Filename).WithXPath("Root/Row");

        parser.Write(value);
    }
}
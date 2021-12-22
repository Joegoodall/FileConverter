using FileConverter.IO;

namespace FileConverter;

public static class Converter
{
    public static void ConvertFile(string path, string output)
    {
        var reader = GetIOHandler(path);
        var writer = GetIOHandler(output);

        ConvertFile(reader, writer);
    }

    public static void ConvertFile(IFileReader reader, IFileWriter writer)
    {
        var data = reader.Read();

        writer.Write(data);
    }

    public static IFileIO GetIOHandler(string path)
    {
        var extension = Path.GetExtension(path);

        if (!Enum.TryParse(extension.Replace(".", string.Empty), true, out SupportedFileType supportedFileType))
            throw new NotSupportedException($"Extension {extension} is not supported.");

        return GetIOHandler(supportedFileType, path);
    }

    public static IFileIO GetIOHandler(SupportedFileType supportedFileType, string path)
    {
        return supportedFileType switch
        {
            SupportedFileType.Csv => new CsvFile(path),
            SupportedFileType.Xml => new XmlFile(path),
            SupportedFileType.Json => new JsonFile(path),
            _ => throw new ArgumentOutOfRangeException(nameof(supportedFileType), supportedFileType, null)
        };
    }
}
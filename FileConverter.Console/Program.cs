using CommandLine;
using FileConverter;
using FileConverter.Console;

Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);

static void RunOptions(Options opts)
{
    try
    {
        Converter.ConvertFile(opts.InputFilename, opts.OutputFilename);
    }
    catch (NotSupportedException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
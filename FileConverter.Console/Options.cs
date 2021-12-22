using CommandLine;

namespace FileConverter.Console;

internal class Options
{
    [Option('i', "input", Required = true, HelpText = "Input filename.")]
    public string InputFilename { get; set; } = default!;

    [Option('o', "output", Required = true, HelpText = "Output filename.")]
    public string OutputFilename { get; set; } = default!;
}
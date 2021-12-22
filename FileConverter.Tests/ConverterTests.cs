using FileConverter.IO;
using FileConverter.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FileConverter.Tests;

public class Tests
{
    [Test]
    public void GetIOHandler_Valid()
    {
        var fileHandler = Converter.GetIOHandler(SupportedFileType.Csv, "Example.xml");

        Assert.IsInstanceOf(typeof(CsvFile), fileHandler);
    }

    [Test]
    public void GetIOHandler_NotSupportedException()
    {
        Assert.Throws<NotSupportedException>(() => Converter.GetIOHandler(".xyz"));
    }

    [Test]
    public void ConvertFile_Example()
    {
        Converter.ConvertFile("Example.csv", "Example.json");
    }

    [Test]
    public void MockIO_Example()
    {
        var reader = new Mock<IFileReader>();
        var writer = new Mock<IFileWriter>();

        Converter.ConvertFile(reader.Object, writer.Object);
    }

    [Test]
    public void CreateFileFromDB_Example()
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "Dave", Address = new() { Line1 = "Street", Line2 = "Town" } },
            new Customer { Name = "Joe", Address = new()  { Line1 = "Street", Line2 = "Town" } }
        };

        var fileHandler = Converter.GetIOHandler(SupportedFileType.Xml, "Example.xml");

        fileHandler.Write(customers);
    }
}
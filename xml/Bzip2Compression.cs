using ICSharpCode.SharpZipLib.BZip2;
using System.Text;
using System.Text.RegularExpressions;

namespace DataCompression.xml;

public static class Bzip2Compression
{
    public static void Compress()
    {
        Console.Write("Enter the full path of the XML file: ");
        string xmlFilePath = Console.ReadLine();

        if (!File.Exists(xmlFilePath))
        {
            Console.WriteLine("File not found. Please check the path and try again.");
            return;
        }

        if (Path.GetExtension(xmlFilePath).ToLower() != ".xml")
        {
            Console.WriteLine("The specified file is not an XML file.");
            return;
        }

        try
        {
            string directoryPath = Path.GetDirectoryName(xmlFilePath);
            string fileName = Path.GetFileNameWithoutExtension(xmlFilePath);
            string compressedFilePath = Path.Combine(directoryPath, fileName + "_compressed.bz2");

            // Load and compress XML
            string xmlContent = File.ReadAllText(xmlFilePath);
            string compressedXml = RemoveWhitespace(xmlContent);

            // Use BZip2 compression
            CompressBZip2(compressedXml, compressedFilePath);

            Console.WriteLine($"XML file compressed successfully. Compressed file created at: {compressedFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static string RemoveWhitespace(string xml)
    {
        // Remove all whitespace between tags
        return Regex.Replace(xml, @">\s+<", "><");
    }

    static void CompressBZip2(string input, string outputPath)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        using (FileStream outFile = File.Create(outputPath))
        using (BZip2OutputStream bzipStream = new BZip2OutputStream(outFile, 9))
        {
            bzipStream.Write(inputBytes, 0, inputBytes.Length);
        }
    }
}

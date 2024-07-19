using ICSharpCode.SharpZipLib.Zip;
using System.Text;
using System.Xml.Linq;

namespace DataCompression.xml;

public static class LZMACompression
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
            string zipFilePath = Path.Combine(directoryPath, fileName + "_compressed.zip");

            // Load and compress XML
            XDocument doc = XDocument.Load(xmlFilePath);
            string compressedXml = CompressXml(doc);

            // Use LZMA compression
            CompressLZMA(compressedXml, zipFilePath);

            Console.WriteLine($"XML file compressed successfully. Zip file created at: {zipFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static string CompressXml(XDocument doc)
    {
        // Remove whitespace and format the XML to a single line
        return doc.ToString(SaveOptions.DisableFormatting);
    }

    static void CompressLZMA(string input, string outputPath)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        using (FileStream outFile = File.Create(outputPath))
        using (ZipOutputStream zipStream = new ZipOutputStream(outFile))
        {
            zipStream.SetLevel(9); // 0-9, 9 being the highest compression
            ZipEntry entry = new ZipEntry("compressedXml.xml");
            entry.DateTime = DateTime.Now;
            zipStream.PutNextEntry(entry);

            zipStream.Write(inputBytes, 0, inputBytes.Length);
            zipStream.CloseEntry();
        }
    }
}

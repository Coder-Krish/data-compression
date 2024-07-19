
using System;
using System.IO;
using System.IO.Compression;
namespace DataCompression.xml;

public static class NormalCompression
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
            string zipFilePath = Path.Combine(directoryPath, fileName + ".zip");

            using (FileStream zipToCreate = new FileStream(zipFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    string fileNameInZip = Path.GetFileName(xmlFilePath);
                    ZipArchiveEntry zipEntry = archive.CreateEntry(fileNameInZip);

                    using (StreamWriter writer = new StreamWriter(zipEntry.Open()))
                    {
                        writer.Write(File.ReadAllText(xmlFilePath));
                    }
                }
            }

            Console.WriteLine($"XML file compressed successfully. Zip file created at: {zipFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

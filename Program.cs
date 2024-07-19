using DataCompression.xml;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("\n 1. Basic Compression \n 2. LZMA Algorithm \n 3. BZip2 Algorithm \n Choose the algorithm you want to use: ");
        string selection = Console.ReadLine();
        switch (selection)
        {
            case "1":
                {
                    //Compress using Normal Compression
                    NormalCompression.Compress();
                }
                break;
            case "2":
                {

                    //Compress using LZMA Compression Algorithm.
                    LZMACompression.Compress();
                }
                break;
            case "3":
                {
                    //Compress using Bzip2 Compression Algorithm
                    Bzip2Compression.Compress();
                }
                break;
            default:
                {
                    Console.WriteLine("Uh Oh! Your choice is beyond the provided Options. ");
                }
                break;
        }
    }
}
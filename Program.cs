using DataCompression.xml;

class Program
{
    static void Main(string[] args)
    {
        //Compress using Normal Compression
        //NormalCompression.Compress();

        //Compress using LZMA Compression Algorithm.
        //LZMACompression.Compress();

        //Compress using Bzip2 Compression Algorithm
        Bzip2Compression.Compress();
    }
}
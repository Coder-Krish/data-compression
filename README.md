# XML File Compressor

This console application provides a simple way to compress XML files using three different methods. It's designed to reduce the size of XML files while maintaining their structure and content.

## Features

- Compress XML files using three different methods:
  1. Basic compression (applies normal compression)
  2. Advanced compression (removes whitespace and applies LZMA compression algorithm)
  3. Ultra compression (removes whitespace, and applies Bzip2 Compression algorithm)
- Uses BZip2 compression for efficient file size reduction
- Preserves XML structure and content (except for whitespace)
- Easy-to-use command-line interface

## Prerequisites

- .NET8 SDK
- SharpZipLib NuGet package

## Installation

1. Clone this repository or download the source code.
2. Open the solution in Visual Studio or your preferred IDE.
3. Restore NuGet packages to install SharpZipLib.

## Usage

1. Build and run the application.
2. When prompted, enter the full path to the XML file you want to compress.
3. The application will create a compressed file in the same directory as the original XML file.

## Example

```bash
Enter the full path of the XML file: C:\Users\YourName\Documents\sample.xml
Choose compression method (1: Basic, 2: Advanced, 3: Ultra): 2
XML file compressed successfully. Compressed file created at: C:\Users\YourName\Documents\sample_compressed.bz2
```

## Notes

- Compression ratios may vary depending on the content and structure of your XML files.
- Always keep a backup of your original XML files before compressing.

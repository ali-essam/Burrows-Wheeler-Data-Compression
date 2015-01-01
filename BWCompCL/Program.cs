using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Burrows_Wheeler_Data_Compression;

namespace BWCompCL
{
    class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                if (options.AddToArchive)
                {
                    string filePath = options.Files.First();
                    byte[] fileData = File.ReadAllBytes(filePath);
                    Console.WriteLine("{0} bytes read.", fileData.Length);
                    byte[] compressedFileData = BWCompression.Compress(fileData);
                    File.WriteAllBytes(options.ArchivePath, compressedFileData);
                    Console.WriteLine("{0} bytes compressed into {1} bytes.",
                        fileData.Length, compressedFileData.Length);
                    Console.WriteLine("Compression ratio = {0}%.",
                        (float)compressedFileData.Length / fileData.Length);
                    Console.WriteLine("Compression Time = {0}ms.", stopWatch.ElapsedMilliseconds);
                }
                else if (options.ExtractFromArchive)
                {
                    byte[] archiveData = File.ReadAllBytes(options.ArchivePath);
                    Console.WriteLine("{0} bytes read.", archiveData.Length);
                    byte[] decompressedFileData = BWCompression.Decompress(archiveData);
                    string filePath = options.Files.First();
                    File.WriteAllBytes(filePath, decompressedFileData);
                    Console.WriteLine("Decompression Time = {0}ms.", stopWatch.ElapsedMilliseconds);
                }
                else
                {
                    Console.WriteLine(options.GetUsage());
                }
            }
#if DEBUG
            Console.Write("Press any key to continue...");
            Console.ReadKey();
#endif
        }
    }
}

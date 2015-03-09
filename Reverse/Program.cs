using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reverse
{
    public class Program
    {
        delegate string[] ReverseLines(List<string> lines);
        
        public static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("usage: reverse full-path-to-file [-r1 | -r2 | -r3]");
                return;
            }
            
            string filePath = args.First();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: {0}", filePath);
                return;
            }

            var lines = new List<string>(File.ReadAllLines(filePath));
            Console.WriteLine(String.Format("Total lines: {0}", lines.Count()));
            
            // magic happens here
            ReverseLines reverseAlgorithm = GetReverseAlgorithm(args.Last());
            File.WriteAllLines(filePath, reverseAlgorithm(lines));

            Console.WriteLine("Reversed.");
        }

        private static ReverseLines GetReverseAlgorithm(string algorithmName)
        {
            switch (algorithmName)
            {
                case "-r2":
                    return ReverseWithListMethods;
                case "-r3":
                    return ReverseManual;
                default:
                    return ReverseWithLINQ;
            }
        }

        public static string[] ReverseWithLINQ(List<string> lines)
        {
            return lines.Reverse<string>().ToArray();
        }

        public static string[] ReverseWithListMethods(List<string> lines)
        {
            lines.Reverse();
            return lines.ToArray();
        }

        public static string[] ReverseManual(List<string> lines)
        {
            string[] reversed = new string[lines.Count];
            for(int i=lines.Count - 1; i>=0; i--)
            {
                reversed[i] = lines[lines.Count - 1 - i];
            }

            return reversed;
        }
    }
}

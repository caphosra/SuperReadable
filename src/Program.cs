using System;
using System.IO;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace SuperReadable
{
    class Program
    {
        public static string result = "";

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("SuperReadable (c) 2019 capra314cabra\r\n");

                string input = null;
                while(true)
                {
                    Console.Write(">> ");
                    input = Console.ReadLine();

                    if(input == "exit") return;

                    if(File.Exists(input))
                    {
                        Run(input);
                    }
                    else
                    {
                        Console.Error.WriteLine("[ERROR] Not found the file.");
                    }
                }
            }
            else
            {
                Run(args[0]);
            }
        }

        static void Run(string file)
        {
            var stream = new AntlrFileStream(file);
            var lexer = new SuperReadableLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new SuperReadableParser(tokens);
            
            var visitor = new StatementVisitor();
            var program = visitor.Visit(parser.file());

            program.Run();
        }
    }
}

using CommandLine;
using System.Collections.Generic;

namespace Tester
{
    internal class Options
    {
        //[Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
        //public IEnumerable<string> InputFiles { get; set; }

        //// Omitting long name, defaults to name of property, ie "--verbose"
        //[Option(Default = false, HelpText = "Prints all messages to standard output.")]
        //public bool Verbose { get; set; }

        //[Option("stdin", Default = false, HelpText = "Read from stdin")]
        //public bool stdin { get; set; }

        //[Value(0, MetaName = "offset", HelpText = "File offset.")]
        //public long? Offset { get; set; }

        [Option('c', Default = false, HelpText = "Test Connecto to database.")]
        public bool ConnectionTester { get; internal set; }
    }
}

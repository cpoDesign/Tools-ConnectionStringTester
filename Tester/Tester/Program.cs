using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tester.Tester;

namespace Tester
{
    class Program
    {
        static int Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
     .WithParsed<Options>(opts => RunOptionsAndReturnExitCode(opts))
     .WithNotParsed<Options>((errs) => HandleParseError(errs));


            //Func<IOptions, string> reader = opts =>
            //{
            //    var fromTop = opts.GetType() == typeof(HeadOptions);
            //    return opts.Lines.HasValue
            //        ? ReadLines(opts.FileName, fromTop, (int)opts.Lines)
            //        : ReadBytes(opts.FileName, fromTop, (int)opts.Bytes);
            //};
            //Func<IOptions, string> header = opts =>
            //{
            //    if (opts.Quiet)
            //    {
            //        return string.Empty;
            //    }
            //    var fromTop = opts.GetType() == typeof(HeadOptions);
            //    var builder = new StringBuilder("Reading ");
            //    builder = opts.Lines.HasValue
            //        ? builder.Append(opts.Lines).Append(" lines")
            //        : builder.Append(opts.Bytes).Append(" bytes");
            //    builder = fromTop ? builder.Append(" from top:") : builder.Append(" from bottom:");
            //    return builder.ToString();
            //};
            //Action<string> printIfNotEmpty = text =>
            //{
            //    if (text.Length == 0) { return; }
            //    Console.WriteLine(text);
            //};

            //var result = Parser.Default.ParseArguments<HeadOptions, TailOptions>(args);
            //var texts = result
            //    .MapResult(
            //        (HeadOptions opts) => Tuple.Create(header(opts), reader(opts)),
            //        (TailOptions opts) => Tuple.Create(header(opts), reader(opts)),
            //        _ => MakeError());

            //printIfNotEmpty(texts.Item1);
            //printIfNotEmpty(texts.Item2);

            //return texts.Equals(MakeError()) ? 1 : 0;
            return 1;
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var error in errs)
            {
                ConsoleLogger.Info(error.ToString());
            }
        }

        private static void RunOptionsAndReturnExitCode(Options opts)
        {
            if (opts.ConnectionTester)
            {
                new Tester.DataAccessTester().CheckDatabaseConnectivity();
            }
        }
    }
}
using System;

namespace Tester.Tester
{
    public class ConsoleLogger
    {
        /// <summary>
        /// Prints out message to the console
        /// </summary>
        /// <param name="message">Message to be added to console</param>
        public static void Info(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }

        internal static void RenderSeparator(int repeatTimes, string separatorSingleItem)
        {
            string separatorText = string.Empty;
            for (var i = 0; i <= repeatTimes; i++)
            {
                separatorText += separatorSingleItem;
            }

            Console.WriteLine(separatorText);
        }

        internal static void HighLight(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{DateTime.Now} - {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
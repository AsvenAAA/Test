using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        public static string ResponseBody { get; set; }
        static async Task Main(string[] args)
        {
            try
            {
                await GetPage();
                WriteToFile();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nCatch exception!");
                Console.WriteLine($"\nMessage:    {e.Message}" +
                                  $"\nTargetSite: {e.TargetSite}" +
                                  $"\nStackTrace: {e.StackTrace}" +
                                  $"\nSource:     {e.Source}" +
                                  $"\nHResult:    {e.HResult}");

                Console.ReadKey();
            }

        }

        public static async Task GetPage()
        {
            Uri uri = new Uri("https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/await");
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            ResponseBody = await response.Content.ReadAsStringAsync();
        }

        public static MatchCollection GetValue()
        {
            Program prog = new Program();
            string patternForRegex = "async(w*)";
            Regex regex = new Regex(patternForRegex, RegexOptions.IgnorePatternWhitespace);
            MatchCollection matches = regex.Matches(ResponseBody);
            return matches;
        }

        public static void WriteToFile()
        {
            using (StreamWriter writeToFile = new StreamWriter(@"C:\Users\Asven\Desktop\Mytest.txt"))
            {
                foreach (Match searchValue in GetValue())
                {
                    writeToFile.Write(searchValue.Value);
                }
                writeToFile.Close();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        public static async Task Full()
        {
            try
            {
                Uri uri = new Uri("https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/await");
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                string patternForRegex = "await(w*)";
                Regex regex = new Regex(patternForRegex, RegexOptions.IgnorePatternWhitespace);
                MatchCollection matches = regex.Matches(responseBody);

                using (StreamWriter writeToFile = new StreamWriter(@"C:\Users\Asven\Desktop\Mytest.txt"))
                {
                    foreach (Match searchValue in matches)
                    {
                        writeToFile.Write(searchValue.Value);
                    }
                    writeToFile.Close();
                }

                Console.WriteLine("Done!");
                Console.ReadKey();

            }

            catch (HttpRequestException e)
            {
                Console.WriteLine("\nCatch exception!");
                Console.WriteLine($"\nMessage:    {e.Message}" +
                                  $"\nTargetSite: {e.TargetSite}" +
                                  $"\nStackTrace: {e.StackTrace}" +
                                  $"\nSource:     {e.Source}" +
                                  $"\nHResult:    {e.HResult}");

                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Test
{
    class HttpSpeaker
    {
        public static string StatusMessage{get;set;}
        public static async Task<string> GetPage()
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri
                    ("https://technopoint.ru/");
                HttpResponseMessage response = await client.GetAsync(uri);
                response?.EnsureSuccessStatusCode();
                StatusMessage = "Ok";
                return await response.Content.ReadAsStringAsync();
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
                return "App down! Need a genius!!!";
            }
        }
    }
}

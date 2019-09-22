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
        static async Task Main()
        {
            await HttpSpeaker.GetPage();
            if(HttpSpeaker.StatusMessage != null)
            {
                FileCreator file = new FileCreator();
                file.WriteToFile();
            }
        }
    }
}

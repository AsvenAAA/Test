using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Test
{
    class TextFinder
    {
        public static MatchCollection GetValue()
        {
            string patternForRegex = "await(w*)";
            Regex regex = new Regex(patternForRegex, RegexOptions.IgnorePatternWhitespace);
            MatchCollection matches = regex.Matches(HttpSpeaker.GetPage().Result);
            return matches;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCrewJSONFormatter
{
    static class JsonFile
    {
        static List<string> JSONFileTextLines = new List<string>();

        public static List<string> ProcessJSONFile(string fileName, FormatterForm fw)
        {
            List<string> formattedJSONLines = new List<string>();
            Encoding fileEncoding = GetChatEncoding(fileName);

            List<string> justJSONLines = File.ReadAllLines(fileName, fileEncoding).ToList<string>();
            
            //Process the file

            return justJSONLines;
        }

        private static Encoding GetChatEncoding(string filename)
        {
            Encoding currentEncoding = null;
            using (var reader = new StreamReader(filename, Encoding.UTF8, true))
            {
                reader.Peek(); // you need this!
                currentEncoding = reader.CurrentEncoding;
            }
            return currentEncoding;

        }
    }
}

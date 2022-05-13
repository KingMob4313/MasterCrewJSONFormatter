using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MasterCrewJSONFormatter
{
    static class JsonFile
    {
        static readonly List<string> JSONFileTextLines = new List<string>();

        public static List<string> ProcessJSONFile(string fileName, FormatterForm fw)
        {
            List<string> formattedJSONLines = new List<string>();
            Encoding fileEncoding = GetChatEncoding(fileName);

            List<string> justJSONLines = File.ReadAllLines(fileName, fileEncoding).ToList<string>();

            //Process the file
            List<string> processedLines = ProcessJSONLines(justJSONLines, fw);

            return processedLines;
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

        private static List<string> ProcessJSONLines(List<string> allChatText, FormatterForm currentWindow)
        {
            List<string> currentChatLines = new List<string>();
            foreach (string line in allChatText)
            {
                string cleanLine = CleanUpJSONLines(line);

                currentChatLines.Add(cleanLine + "\r\n");
            }
            //currentWindow.FormattedLinesText.Content = currentChatLines.Count.ToString();
            return currentChatLines;
        }

        private static string CleanUpJSONLines(string line)
        {
            //Roll through and make your line changes
            //In this case, we're moving the id from the json collection header to a PersonId

            string newLine = string.Empty;
            string personId = getLineId(line);
            if (personId != "-1")
            {
                string replacementJson = "   \"" + personId + "\":{";
                newLine = line.Replace(replacementJson, "{\"PersonId\":\"" + personId + "\"");
                return newLine;
            }
            else
            { return line; }

        }

        private static string getLineId(string line)
        {
            if (line.Length == 9 && line.Contains(":{"))
            {
                return line.Substring(4, 2);
            }
            else if (line.Length == 8 && line.Contains(":{"))
            {
                return line.Substring(4, 1);
            }
            else
            {
                return "-1";
            }

        }
    }
}

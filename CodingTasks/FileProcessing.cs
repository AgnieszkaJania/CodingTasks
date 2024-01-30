using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public static class FileProcessing
    {
        private const string FILE_EXTENSION_TXT = ".txt";
        private const string FILE_COLUMN_SEPARATOR = ",";
        public static bool IsFileInCorrectFormat(string filePath)
        {
           if(Path.GetExtension(filePath) != FILE_EXTENSION_TXT)
           {
                return false;
           }
          return true;
        }
        public static IList<string> ReadAllLinesFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            IList<string> textLines = new List<string>();
            while (!sr.EndOfStream)
            {
                textLines.Add(sr.ReadLine());
            }
            sr.Close();
            return textLines;
        }
        public static void WriteLinesToFile(IList<string> lines, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath, false);
            foreach(string line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }
        private static Tuple<string, int, int> _parseFromDataRecord(string dataRecord)
        {

            string[] columns = dataRecord.Split(FILE_COLUMN_SEPARATOR);
            return Tuple.Create(columns[0], int.Parse(columns[1]), int.Parse(columns[2]));

        }
        private static string _parseToDataRecord(Tuple<string, int, int, int> data)
        {
            return $"{data.Item1},{data.Item2},{data.Item3},{data.Item4}";
        }
        private static int _calculate(Func<int, int, int> calculation, int firstValue, int secondValue)
        {
            return calculation(firstValue, secondValue);
        }
        public static IList<string> CalculateValues(IList<string> sourceTextLines, Func<int, int, int> calculation)
        {
            IList<string> calculatedLines = new List<string>();
            foreach (string line in sourceTextLines)
            {
                var values = _parseFromDataRecord(line);
                calculatedLines.Add(_parseToDataRecord(Tuple.Create(values.Item1, values.Item2, values.Item3,
                    _calculate(calculation, values.Item2, values.Item3))));
            }
            return calculatedLines;
        }
        public static void ProcesFileData(string sourceFilePath, string destinationFilePath, Func<int, int, int> calculation)
        {
            var textLines = ReadAllLinesFromFile(sourceFilePath);
            WriteLinesToFile(CalculateValues(textLines, calculation), destinationFilePath);
        }
    }
}

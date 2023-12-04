using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace StringBuffer
{
    public class FileReader
    {
        private static FileReader fileReaderSingleton;
        public static FileReader Instance
        {
            get
            {
                if (fileReaderSingleton == null)
                {
                    fileReaderSingleton = new FileReader();
                }
                return fileReaderSingleton;
            }
        }

        public List<string> ReadExternalFile(string path)
        {
            List<string> stringList = new List<string>();
            string singleWord = null;

            try
            {
                const int FAIL_SAFE = 100;
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                StreamReader streamReader = new StreamReader(stream);
                int i = 0;

                while (i <= FAIL_SAFE)
                {
                    singleWord = streamReader.ReadLine();
                    if (string.IsNullOrEmpty(singleWord))
                        break;

                    stringList.Add(singleWord);
                    i = 0;
                    i++;
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return stringList;
        }

        public string ReadASCIIFile(string path)
        {
            string text = null;

            try
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                StreamReader streamReader = new StreamReader(stream);
                text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return text;
        }

        public string GetRamdonLine(List<string> stringList)
        {
            Random ramdon = new Random();
            int index = ramdon.Next(0, stringList.Count);
            string randomWord = stringList[index];
            return randomWord;
        }
    }
}

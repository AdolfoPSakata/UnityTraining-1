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

        public List<string> ReadWordDatabase(string path)
        {
            List<string> wordList = new List<string>();

            try
            {
                const int FAIL_SAFE = 100;
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                StreamReader streamReader = new StreamReader(stream);
                string singleWord = null;
                int i = 0;

                while (i <= FAIL_SAFE)
                {
                    singleWord = streamReader.ReadLine();
                    if (string.IsNullOrEmpty(singleWord))
                        break;

                    wordList.Add(singleWord);
                    i = 0;
                    i++;
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return wordList;
        }

        public string GetRandomLine(List<string> wordList)
        {
            Random ramdon = new Random();
            int index = ramdon.Next(0, wordList.Count);
            string randomWord = wordList[index];
            return randomWord;
        }
    }
}

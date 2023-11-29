using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UnityTraining_1
{
    class WordManager
    {
        private List<string> cachedWordList = new List<string>();
        const int FAIL_SAFE = 100;

        public WordManager(string path)
        {
            InitManager(path);
        }

        private List<string> ReadWordDatabase(string path)
        {
            List<string> wordList = new List<string>();
            try
            {
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

        private void InitManager(string path)
        {
            cachedWordList = ReadWordDatabase(path);
        }

        public string GetRandomWord()
        {
            Random ramdon = new Random();
            int index = ramdon.Next(0, cachedWordList.Count);
            string randomWord = cachedWordList[index];
            return randomWord;
        }
    }
}

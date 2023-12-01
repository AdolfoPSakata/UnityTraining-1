using System;
using System.Configuration;

namespace StringBuffer
{
    internal class BufferController
    {
        internal enum Mode
        {
            Line,
            Collum,
            Block,
        }

        internal Tuple<int, int> ModeSelection(Mode mode, int i, int line, int collum)
        {
            int indexX, indexY = 0;
            switch (mode)
            {
                case Mode.Line:
                    {
                        indexX = line;
                        indexY = i + collum;
                        break;
                    }
                case Mode.Collum:
                    {
                        indexX = i + line;
                        indexY = collum;
                        break;
                    }
                case Mode.Block:
                    {
                        indexX = line;
                        indexY = collum;
                        break;
                    }
                default:
                    {
                        indexX = 0;
                        indexY = 0;
                        break;
                    }
            }
            Tuple<int, int> tuple = new Tuple<int, int>(indexX, indexY);
            return tuple;
        }

        internal string RepeatChar(char singleChar, int count)
        {
            string finalString = null;
            for (int i = 0; i < count; i++)
            {
                finalString += singleChar;
            }
            return finalString;
        }

        public string[,] ModifyBuffer(BufferChange change)
        {
            Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
            int j = 0;
            do
            {
                for (int i = 0; i < change.toWrite.Length; i++)
                {
                    tuple = ModeSelection(change.mode, i, change.line, change.collum);
                    change.buffer[tuple.Item1 + j, tuple.Item2] = change.toWrite[i].ToString();
                }
                j++;
            } while (j <= change.repeat);
            return change.buffer;
        }

        public string[,] SetBuffer()
        {
            int maxX = int.Parse(ConfigurationManager.AppSettings["MaxChar_X"]);
            int maxY = int.Parse(ConfigurationManager.AppSettings["MaxChar_Y"]);
            string[,] buffer = new string[maxX, maxY];

            for (int x = 0; x < maxX; x++)
            {
                int lastIndex = 0;
                for (int y = 0; y < maxY; y++)
                {
                    buffer[x, y] = "+";
                    lastIndex = y;
                }
                buffer[x, lastIndex] = "\n";
            }
            return buffer;
        }
    }

    internal class BufferChange
    {
        public BufferController.Mode mode;
        public string[,] buffer;
        public string toWrite;
        public int line;
        public int collum;
        public int repeat;

        public BufferChange(BufferController.Mode mode, string[,] buffer, string toWrite, int line, int collum, int repeat)
        {
            this.mode = mode;
            this.buffer = buffer;
            this.toWrite = toWrite;
            this.line = line;
            this.collum = collum;
            this.repeat = repeat;
        }
    }
}

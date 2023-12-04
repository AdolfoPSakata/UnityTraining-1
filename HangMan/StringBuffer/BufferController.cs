using System;
using System.Configuration;

namespace StringBuffer
{
    internal class BufferController : IBufferController
    {
        public enum Mode
        {
            Line,
            Collum,
            Block,
        }

        private int maxX = int.Parse(ConfigurationManager.AppSettings["MaxChar_X"]);
        private int maxY = int.Parse(ConfigurationManager.AppSettings["MaxChar_Y"]);

        public Tuple<int, int> GetModeSelection(Mode mode, int i, int line, int collum)
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
                        indexY = i + collum;
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
        public string[,] ModifyBuffer(BufferChange change, string[,] buffer)
        {
            return Modify(change, buffer);
        }
        public string[,] CreateBuffer()
        {
            return SetNewBuffer();
        }
        private string[,] Modify(BufferChange change, string[,] buffer)
        {
            Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
            int j = 0;
            int index = 0;
            do
            {
                for (int i = 0; i <= change.toWrite.Length - 1; i++)
                {
                    if (change.toWrite[i].ToString() == "\n")
                        break;
                    else if (change.toWrite[i].ToString() == "\r")
                        index++;
                    else
                    {
                        tuple = GetModeSelection(change.mode, i, change.line, change.collum);
                        if (string.IsNullOrWhiteSpace(buffer[tuple.Item1 + j, tuple.Item2]))
                            buffer[tuple.Item1 + j, tuple.Item2] = change.toWrite[index].ToString();
                        index++;
                    }

                    if (change.toWrite.Length <= index)
                        return buffer;
                }
                j++;
                index++;
            } while (change.toWrite.Length - 1 > index);
            return buffer;
        }
        private string[,] SetNewBuffer()
        {
            string[,] buffer = new string[maxX, maxY];

            for (int x = 0; x < maxX; x++)
            {
                int lastIndex = 0;
                for (int y = 0; y < maxY; y++)
                {
                    buffer[x, y] = " ";
                    lastIndex = y;
                }
                buffer[x, lastIndex] = "\n";
            }
            return buffer;
        }
    }
    internal class BufferChange
    {
        internal BufferController.Mode mode;
        internal string toWrite;
        internal int line;
        internal int collum;

        internal BufferChange(BufferController.Mode mode, string toWrite, int line, int collum)
        {
            this.mode = mode;
            this.toWrite = toWrite;
            this.line = line;
            this.collum = collum;
        }
    }
}

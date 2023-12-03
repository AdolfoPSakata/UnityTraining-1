using System;

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

        internal string RepeatChar(char singleChar, int count)
        {
            string finalString = null;
            for (int i = 0; i < count; i++)
            {
                finalString += singleChar;
            }

            return finalString;
        }

        public string[,] ModifyBuffer(BufferChange change, string[,] buffer)
        {
            //Change to a tool script
            Tuple<int, int> tuple = new Tuple<int, int>(0, 0);
            int j = 0;
            int index = 0;
            do
            {
                for (int i = 0; i <= change.toWrite.Length - 1; i++)
                {
                    if (change.toWrite[i].ToString() == "\n")
                    {
                        break;
                    }
                    else if (change.toWrite[i].ToString() == "\r")
                    {
                        index++;
                    }
                    else
                    {
                        tuple = ModeSelection(change.mode, i, change.line, change.collum);
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

        public string[,] SetBuffer(int line, int collum)
        {
            string[,] buffer = new string[line, collum];

            for (int x = 0; x < line; x++)
            {
                int lastIndex = 0;
                for (int y = 0; y < collum; y++)
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


        public BufferController.Mode mode;
        public string toWrite;
        public int line;
        public int collum;

        public BufferChange(BufferController.Mode mode, string toWrite, int line, int collum)
        {
            this.mode = mode;
            this.toWrite = toWrite;
            this.line = line;
            this.collum = collum;
        }
    }
}

namespace StringBuffer
{
    internal partial class BufferController
    {
        public interface IWriteMode
        {
            int IndexX { get; set; }
            int IndexY { get; set; }
            public abstract void UpdateIndexes(int line, int collum, int i);
        }

        public class WriteModeLine : IWriteMode
        {
            public WriteModeLine() { }

            public int IndexX { get; set; }
            public int IndexY { get; set; }

            public void UpdateIndexes(int line, int collum, int i)
            {
                IndexX = line;
                IndexY = i + collum;
            }
        }

        public class WriteModeCollum : IWriteMode
        {
            public WriteModeCollum() { }

            public int IndexX { get; set; }
            public int IndexY { get; set; }
            public void UpdateIndexes(int line, int collum, int i)
            {
                IndexX = i + line;
                IndexY = collum;
            }
        }
        public class WriteModeBlock : IWriteMode
        {
            public WriteModeBlock() { }
            public int IndexX { get; set; }
            public int IndexY { get; set; }

            public void UpdateIndexes(int line, int collum, int i)
            {
                IndexX = line;
                IndexY = i + collum;
            }
        }
    }
}

using System;

namespace StringBuffer
{
    public class Screens
    {
        BufferController bufferController = new BufferController();
        
        public string[,] test()
        {
            string[,] buffer = bufferController.SetBuffer();
            bufferController.ModifyBuffer(BufferController.Mode.Line, buffer, "test", 10, 2, 0);
            return buffer;
        }
    }
}

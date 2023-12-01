namespace StringBuffer
{
    public class Screens
    {
        //BufferController.Mode, string[,], string, int, int, int> action = bufferController.ModifyBuffer;
        BufferController bufferController = new BufferController();
        private string[,] cachedBuffer = new string[,] { };
        BufferChange change;
        public string[,] ScreenConstructor()
        {
            cachedBuffer = bufferController.SetBuffer();
            change = new BufferChange(BufferController.Mode.Line, cachedBuffer, "*", 0, 0, 1);
            cachedBuffer = bufferController.ModifyBuffer(change);


            //bufferController.ModifyBuffer(change);
            //new BufferChange(BufferController.Mode.Collum, cachedBuffer, "*", 0, 0, 20);
            //new BufferChange(BufferController.Mode.Line, cachedBuffer, "*", 19, 0, 0);
            //new BufferChange(BufferController.Mode.Collum, cachedBuffer, "*", 0, 60, 20);
            //};
            //BufferController[] windowFrame = {
            //     new BufferController (BufferController.Mode.Line, cachedBuffer, "*", 0, 0, 0 ),
            //     new BufferController(BufferController.Mode.Collum, cachedBuffer, "*", 0, 0, 20),
            //     new BufferController(BufferController.Mode.Line, cachedBuffer, "*", 19, 0, 0),
            //     new BufferController(BufferController.Mode.Collum, cachedBuffer, "*", 0, 60, 20),
            //};
            return cachedBuffer;
        }
    }
}

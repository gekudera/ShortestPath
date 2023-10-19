namespace Final_work
{
    internal class FileWriter
    {
        public static void Write(string filePath, string content) => 
            File.WriteAllText(filePath, content);
    }
}

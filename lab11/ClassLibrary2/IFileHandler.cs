using System.IO;

public interface IFileHandler
{
    int[,] LoadFromJson(TextReader reader);
    void SaveToJson(TextWriter writer, int[,] matrix);
}
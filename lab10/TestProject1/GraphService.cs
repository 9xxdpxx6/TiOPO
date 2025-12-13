using System;
using System.IO;

public class GraphService
{
    private readonly IFileHandler _fileHandler;

    public GraphService(IFileHandler fileHandler)
    {
        _fileHandler = fileHandler;
    }

    /// <summary>
    /// Находит кратчайший путь, загружая граф из JSON-строки.
    /// </summary>
    /// <param name="jsonContent">Строка, содержащая матрицу графа в формате JSON.</param>
    /// <param name="startVertex">Начальная вершина.</param>
    /// <param name="endVertex">Конечная вершина.</param>
    /// <returns>Кратчайший путь или пустой список, если путь не найден.</returns>
    public System.Collections.Generic.List<int> FindShortestPathFromJson(string jsonContent, int startVertex, int endVertex)
    {
        // Используем внедренную зависимость для загрузки данных
        using (var reader = new StringReader(jsonContent))
        {
            int[,] matrix = _fileHandler.LoadFromJson(reader);
            var graph = new Graph(matrix);
            return graph.FindShortestPath(startVertex, endVertex);
        }
    }
}
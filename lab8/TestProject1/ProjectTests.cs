using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

[TestFixture]
public class ProjectTests
{
    private FileHandler _fileHandler;

    [SetUp]
    public void Setup()
    {
        _fileHandler = new FileHandler();
    }

    // --- Тестирование FileHandler ---

    [Test]
    public void FileHandler_LoadFromJson_ShouldReturnCorrectMatrix()
    {
        // Arrange: создаем строку с JSON и оборачиваем ее в StringReader
        // JsonSerializer.Deserialize может читать как компактный, так и форматированный JSON
        string jsonString = "[[0,1],[1,0]]";
        using var reader = new StringReader(jsonString);

        // Act: загружаем данные из строкового потока
        int[,] matrix = _fileHandler.LoadFromJson(reader);

        // Assert: проверяем результат
        Assert.AreEqual(2, matrix.GetLength(0));
        Assert.AreEqual(0, matrix[0, 0]);
        Assert.AreEqual(1, matrix[0, 1]);
        Assert.AreEqual(1, matrix[1, 0]);
        Assert.AreEqual(0, matrix[1, 1]);
    }

    /// <summary>
    /// Вспомогательный метод для сравнения двух матриц.
    /// </summary>
    private bool AreMatricesEqual(int[,] m1, int[,] m2)
    {
        if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
            return false;

        for (int i = 0; i < m1.GetLength(0); i++)
        {
            for (int j = 0; j < m1.GetLength(1); j++)
            {
                if (m1[i, j] != m2[i, j])
                    return false;
            }
        }
        return true;
    }

    [Test]
    public void FileHandler_SaveAndLoad_ShouldReturnOriginalMatrix()
    {
        // Arrange: создаем исходную матрицу
        var originalMatrix = new int[,] { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
        int[,] loadedMatrix;

        // Act: сохраняем матрицу в строку, а затем загружаем ее из этой же строки
        using (var writer = new StringWriter())
        {
            _fileHandler.SaveToJson(writer, originalMatrix);
            string json = writer.ToString();

            using (var reader = new StringReader(json))
            {
                loadedMatrix = _fileHandler.LoadFromJson(reader);
            }
        }

        // Assert: сравниваем исходную и загруженную матрицы
        Assert.IsTrue(AreMatricesEqual(originalMatrix, loadedMatrix), "Матрицы должны быть идентичны после сохранения и загрузки.");
    }


    // --- Тестирование класса Graph с использованием заглушек (фиктивных данных) ---
    [Test]
    public void Graph_FindShortestPath_PathExists_ShouldReturnCorrectPath()
    {
        // Arrange: создаем "заглушку" - матрицу, описывающую граф
        var matrix = new int[,]
        {
            { 0, 1, 1, 0 }, // 0 -> 1, 2
            { 1, 0, 0, 1 }, // 1 -> 0, 3
            { 1, 0, 0, 1 }, // 2 -> 0, 3
            { 0, 1, 1, 0 }  // 3 -> 1, 2
        };
        var graph = new Graph(matrix);

        // Act
        var path = graph.FindShortestPath(0, 3);

        // Assert: Проверяем свойства пути, а не его точную последовательность
        Assert.IsNotEmpty(path, "Path should not be empty");
        Assert.AreEqual(0, path.First(), "Path should start at vertex 0");
        Assert.AreEqual(3, path.Last(), "Path should end at vertex 3");
        Assert.AreEqual(3, path.Count, "Path length should be 3");

        // Проверяем, что каждый шаг в пути является валидным ребром в графе
        for (int i = 0; i < path.Count - 1; i++)
        {
            Assert.IsTrue(matrix[path[i], path[i + 1]] > 0, $"Edge from {path[i]} to {path[i + 1]} does not exist");
        }
    }

    [Test]
    public void Graph_FindShortestPath_NoPath_ShouldReturnEmptyList()
    {
        // Arrange: граф, где нет пути между вершинами
        var matrix = new int[,]
        {
            { 0, 1, 0 },
            { 1, 0, 0 },
            { 0, 0, 0 }
        };
        var graph = new Graph(matrix);

        // Act
        var path = graph.FindShortestPath(0, 2);

        // Assert
        Assert.IsEmpty(path);
    }

    [Test]
    public void Graph_FindShortestPath_SameStartEnd_ShouldReturnSingleVertex()
    {
        // Arrange
        var matrix = new int[,] { { 0 } };
        var graph = new Graph(matrix);

        // Act
        var path = graph.FindShortestPath(0, 0);

        // Assert
        Assert.AreEqual(1, path.Count);
        Assert.AreEqual(0, path[0]);
    }
}
using System;
using System.Collections.Generic;
using System.IO;

public class FileHandler
{
    /// <summary>
    /// Загружает матрицу смежности из JSON-потока.
    /// </summary>
    /// <param name="reader">Текстовый поток (например, StreamReader или StringReader).</param>
    /// <returns>Матрица смежности в виде двумерного массива.</returns>
    public int[,] LoadFromJson(TextReader reader)
    {
        string json = reader.ReadToEnd();
        // Десериализуем в список списков, т.к. int[,] не поддерживается
        var jaggedArray = System.Text.Json.JsonSerializer.Deserialize<List<List<int>>>(json);

        if (jaggedArray == null || jaggedArray.Count == 0)
        {
            return new int[0, 0];
        }

        int rows = jaggedArray.Count;
        int cols = jaggedArray[0].Count;

        // Проверяем, что матрица прямоугольная (все строки одинаковой длины)
        foreach (var row in jaggedArray)
        {
            if (row.Count != cols)
            {
                throw new FormatException("JSON не представляет собой корректную прямоугольную матрицу.");
            }
        }

        // Преобразуем список списков обратно в двумерный массив
        var matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = jaggedArray[i][j];
            }
        }

        return matrix;
    }

    /// <summary>
    /// Сохраняет матрицу смежности в JSON-поток.
    /// </summary>
    /// <param name="writer">Текстовый поток (например, StreamWriter или StringWriter).</param>
    /// <param name="matrix">Матрица смежности для сохранения.</param>
    public void SaveToJson(TextWriter writer, int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        var jaggedArray = new List<List<int>>(rows);

        // Преобразуем двумерный массив в список списков для сериализации
        for (int i = 0; i < rows; i++)
        {
            var row = new List<int>(cols);
            for (int j = 0; j < cols; j++)
            {
                row.Add(matrix[i, j]);
            }
            jaggedArray.Add(row);
        }

        var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
        // Сериализуем список списков
        string json = System.Text.Json.JsonSerializer.Serialize(jaggedArray, options);
        writer.Write(json);
    }
}
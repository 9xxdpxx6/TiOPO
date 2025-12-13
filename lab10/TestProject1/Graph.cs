using System;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    // Внутреннее представление графа - список связности
    private readonly Dictionary<int, List<int>> _adjacencyList;
    public int VertexCount => _adjacencyList.Count;

    /// <summary>
    /// Создает граф из матрицы смежности.
    /// </summary>
    /// <param name="adjacencyMatrix">Матрица смежности, где 0 - нет ребра, 1 - есть ребро.</param>
    public Graph(int[,] adjacencyMatrix)
    {
        _adjacencyList = new Dictionary<int, List<int>>();
        int n = adjacencyMatrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            _adjacencyList[i] = new List<int>();
            for (int j = 0; j < n; j++)
            {
                if (adjacencyMatrix[i, j] > 0)
                {
                    _adjacencyList[i].Add(j);
                }
            }
        }
    }

    /// <summary>
    /// Находит кратчайший путь между двумя вершинами с помощью поиска в ширину (BFS).
    /// </summary>
    /// <param name="startVertex">Начальная вершина.</param>
    /// <param name="endVertex">Конечная вершина.</param>
    /// <returns>Список вершин, представляющий кратчайший путь. Если путь не найден, возвращает пустой список.</returns>
    public List<int> FindShortestPath(int startVertex, int endVertex)
    {
        if (!_adjacencyList.ContainsKey(startVertex) || !_adjacencyList.ContainsKey(endVertex))
        {
            return new List<int>(); // Возвращаем пустой путь, если вершины не существуют
        }

        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        var parent = new Dictionary<int, int>();

        queue.Enqueue(startVertex);
        visited.Add(startVertex);

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();

            if (currentVertex == endVertex)
            {
                // Восстанавливаем путь
                var path = new List<int>();
                int step = endVertex;
                while (parent.ContainsKey(step))
                {
                    path.Add(step);
                    step = parent[step];
                }
                path.Add(startVertex);
                path.Reverse();
                return path;
            }

            foreach (var neighbor in _adjacencyList[currentVertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent[neighbor] = currentVertex;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new List<int>(); // Путь не найден
    }

    /// <summary>
    /// Преобразует граф обратно в матрицу смежности для сохранения.
    /// </summary>
    public int[,] ToAdjacencyMatrix()
    {
        int n = _adjacencyList.Count;
        var matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            foreach (var neighbor in _adjacencyList[i])
            {
                matrix[i, neighbor] = 1;
            }
        }
        return matrix;
    }
}
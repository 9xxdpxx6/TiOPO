using NUnit.Framework;
using NSubstitute; // <-- Важно: подключить NSubstitute
using System;
using System.Collections.Generic;
using System.IO;

[TestFixture]
public class GraphServiceTests
{
    private GraphService _graphService;
    private IFileHandler _fileHandlerSubstitute; // Наш "двойник"

    [SetUp]
    public void Setup()
    {
        // 1. Создаем тестового двойника (mock) для интерфейса IFileHandler
        _fileHandlerSubstitute = Substitute.For<IFileHandler>();

        // 2. Создаем наш сервис, передавая ему двойник вместо реального объекта
        _graphService = new GraphService(_fileHandlerSubstitute);
    }

    [Test]
    public void FindShortestPathFromJson_PathExists_ShouldReturnCorrectPath()
    {
        // Arrange (Подготовка)
        var stubMatrix = new int[,]
        {
            { 0, 1, 1, 0 },
            { 1, 0, 0, 1 },
            { 1, 0, 0, 1 },
            { 0, 1, 1, 0 }
        };
        string jsonInput = "any_json_string"; // Содержимое JSON неважно, мы его перехватим

        // 3. Настраиваем поведение двойника: когда его метод LoadFromJson вызовут с любым TextReader,
        // он должен вернуть нашу заранее подготовленную матрицу (stubMatrix).
        _fileHandlerSubstitute.LoadFromJson(Arg.Any<TextReader>()).Returns(stubMatrix);

        // Act (Действие)
        var path = _graphService.FindShortestPathFromJson(jsonInput, 0, 3);

        // Assert (Проверка)
        Assert.IsNotEmpty(path);
        Assert.AreEqual(0, path[0]);
        Assert.AreEqual(3, path[path.Count - 1]);

        // 4. Проверяем взаимодействие: убедимся, что метод LoadFromJson у нашего двойника
        // действительно был вызван ровно один раз.
        _fileHandlerSubstitute.Received(1).LoadFromJson(Arg.Any<TextReader>());
    }

    [Test]
    public void FindShortestPathFromJson_NoPath_ShouldReturnEmptyList()
    {
        // Arrange
        var stubMatrix = new int[,]
        {
            { 0, 1, 0 },
            { 1, 0, 0 },
            { 0, 0, 0 }
        };
        _fileHandlerSubstitute.LoadFromJson(Arg.Any<TextReader>()).Returns(stubMatrix);

        // Act
        var path = _graphService.FindShortestPathFromJson("any_json", 0, 2);

        // Assert
        Assert.IsEmpty(path);
        _fileHandlerSubstitute.Received(1).LoadFromJson(Arg.Any<TextReader>());
    }
}
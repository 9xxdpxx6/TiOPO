using NUnit.Framework;
using System;

[TestFixture]
public class DequeTests
{
    private Deque<int> _deque;

    [SetUp]
    public void Setup()
    {
        _deque = new Deque<int>();
    }

    // --- Тесты для состояния Empty (Требования TR-E1 ... TR-E6) ---
    [Test]
    public void PushFront_OnEmptyDeque_ShouldTransitionToOneItemState()
    {
        _deque.PushFront(10);
        Assert.AreEqual(1, _deque.Count, "Count should be 1");
        Assert.AreEqual(10, _deque.PeekFront(), "Front item should be 10");
        Assert.AreEqual(10, _deque.PeekBack(), "Back item should be 10");
    }

    [Test]
    public void PushBack_OnEmptyDeque_ShouldTransitionToOneItemState()
    {
        _deque.PushBack(20);
        Assert.AreEqual(1, _deque.Count, "Count should be 1");
        Assert.AreEqual(20, _deque.PeekFront(), "Front item should be 20");
        Assert.AreEqual(20, _deque.PeekBack(), "Back item should be 20");
    }

    [Test]
    public void PopFront_OnEmptyDeque_ShouldThrowException() =>
        Assert.Throws<InvalidOperationException>(() => _deque.PopFront());

    [Test]
    public void PopBack_OnEmptyDeque_ShouldThrowException() =>
        Assert.Throws<InvalidOperationException>(() => _deque.PopBack());

    [Test]
    public void PeekFront_OnEmptyDeque_ShouldThrowException() =>
        Assert.Throws<InvalidOperationException>(() => _deque.PeekFront());

    [Test]
    public void PeekBack_OnEmptyDeque_ShouldThrowException() =>
        Assert.Throws<InvalidOperationException>(() => _deque.PeekBack());

    // --- Тесты для состояния OneItem (Требования TR-O1 ... TR-O6) ---
    [Test]
    public void PushFront_OnOneItemDeque_ShouldTransitionToMultipleItemsState()
    {
        _deque.PushBack(10); // Устанавливаем состояние OneItem
        _deque.PushFront(20);

        Assert.AreEqual(2, _deque.Count, "Count should be 2");
        Assert.AreEqual(20, _deque.PeekFront(), "Front item should be 20");
        Assert.AreEqual(10, _deque.PeekBack(), "Back item should be 10");
    }

    [Test]
    public void PushBack_OnOneItemDeque_ShouldTransitionToMultipleItemsState()
    {
        _deque.PushFront(10); // Устанавливаем состояние OneItem
        _deque.PushBack(20);

        Assert.AreEqual(2, _deque.Count, "Count should be 2");
        Assert.AreEqual(10, _deque.PeekFront(), "Front item should be 10");
        Assert.AreEqual(20, _deque.PeekBack(), "Back item should be 20");
    }

    [Test]
    public void PopFront_OnOneItemDeque_ShouldTransitionToEmptyState()
    {
        _deque.PushBack(10); // Устанавливаем состояние OneItem
        int item = _deque.PopFront();

        Assert.AreEqual(10, item, "Returned item should be 10");
        Assert.AreEqual(0, _deque.Count, "Count should be 0");
        Assert.IsTrue(_deque.IsEmpty, "Deque should be empty");
    }

    [Test]
    public void PopBack_OnOneItemDeque_ShouldTransitionToEmptyState()
    {
        _deque.PushBack(10); // Устанавливаем состояние OneItem
        int item = _deque.PopBack();

        Assert.AreEqual(10, item, "Returned item should be 10");
        Assert.AreEqual(0, _deque.Count, "Count should be 0");
        Assert.IsTrue(_deque.IsEmpty, "Deque should be empty");
    }

    // --- Тесты для состояния MultipleItems (Требования TR-M1 ... TR-M6) ---
    [Test]
    public void PushFront_OnMultipleItemsDeque_ShouldAddToFront()
    {
        // Устанавливаем состояние MultipleItems
        _deque.PushBack(10);
        _deque.PushBack(20);

        _deque.PushFront(5);

        Assert.AreEqual(3, _deque.Count, "Count should be 3");
        Assert.AreEqual(5, _deque.PeekFront(), "Front item should be 5");
        Assert.AreEqual(20, _deque.PeekBack(), "Back item should be 20");
    }

    [Test]
    public void PushBack_OnMultipleItemsDeque_ShouldAddToBack()
    {
        // Устанавливаем состояние MultipleItems
        _deque.PushFront(10);
        _deque.PushFront(20);

        _deque.PushBack(25);

        Assert.AreEqual(3, _deque.Count, "Count should be 3");
        Assert.AreEqual(20, _deque.PeekFront(), "Front item should be 20");
        Assert.AreEqual(25, _deque.PeekBack(), "Back item should be 25");
    }

    [Test]
    public void PopFront_OnMultipleItemsDeque_ShouldReturnCorrectItem()
    {
        // Устанавливаем состояние MultipleItems
        _deque.PushBack(10);
        _deque.PushBack(20);
        _deque.PushBack(30);

        int item = _deque.PopFront();

        Assert.AreEqual(10, item, "Returned item should be 10");
        Assert.AreEqual(2, _deque.Count, "Count should be 2");
        Assert.AreEqual(20, _deque.PeekFront(), "New front item should be 20");
    }

    [Test]
    public void PopBack_OnMultipleItemsDeque_ShouldReturnCorrectItem()
    {
        // Устанавливаем состояние MultipleItems
        _deque.PushBack(10);
        _deque.PushBack(20);
        _deque.PushBack(30);

        int item = _deque.PopBack();

        Assert.AreEqual(30, item, "Returned item should be 30");
        Assert.AreEqual(2, _deque.Count, "Count should be 2");
        Assert.AreEqual(20, _deque.PeekBack(), "New back item should be 20");
    }
}
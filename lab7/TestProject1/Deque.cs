using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Дек (двусторонняя очередь), реализованный на основе односвязного списка.
/// Внимание: операции PushBack и PopBack имеют сложность O(n) из-за необходимости
/// обхода всего списка для доступа к предпоследнему элементу.
/// </summary>
/// <typeparam name="T">Тип элементов, хранящихся в деке.</typeparam>
public class Deque<T> : IEnumerable<T>
{
    // Внутренний класс для представления узла односвязного списка
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node _head; // Голова списка (начало дека)
    private Node _tail; // Хвост списка (конец дека)
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    /// <summary>
    /// Добавляет элемент в начало дека.
    /// </summary>
    public void PushFront(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = _head;
        _head = newNode;

        if (_tail == null) // Если дек был пуст
        {
            _tail = _head;
        }
        _count++;
    }

    /// <summary>
    /// Добавляет элемент в конец дека.
    /// Сложность: O(n) из-за обхода списка.
    /// </summary>
    public void PushBack(T item)
    {
        Node newNode = new Node(item);

        if (_head == null) // Если дек пуст
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // В односвязном списке для добавления в конец нужно найти предпоследний узел
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            _tail = newNode;
        }
        _count++;
    }

    /// <summary>
    /// Удаляет и возвращает элемент из начала дека.
    /// </summary>
    public T PopFront()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст.");

        T item = _head.Data;
        _head = _head.Next;
        _count--;

        if (_head == null) // Если дек стал пустым
        {
            _tail = null;
        }
        return item;
    }

    /// <summary>
    /// Удаляет и возвращает элемент из конца дека.
    /// Сложность: O(n) из-за обхода списка.
    /// </summary>
    public T PopBack()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст.");

        if (_head.Next == null) // Если в деке один элемент
        {
            T item = _head.Data;
            _head = null;
            _tail = null;
            _count = 0;
            return item;
        }

        // Находим предпоследний узел
        Node current = _head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        T itemToReturn = current.Next.Data;
        current.Next = null;
        _tail = current;
        _count--;
        return itemToReturn;
    }

    /// <summary>
    /// Возвращает элемент из начала дека без его удаления.
    /// </summary>
    public T PeekFront()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст.");
        return _head.Data;
    }

    /// <summary>
    /// Возвращает элемент из конца дека без его удаления.
    /// </summary>
    public T PeekBack()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст.");
        return _tail.Data;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
using ClassLibrary1;
using NUnit.Framework;
using System.Linq;

namespace TestProject2
{
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
            _deque.PushBack(10);
            _deque.PushFront(20);

            Assert.AreEqual(2, _deque.Count, "Count should be 2");
            Assert.AreEqual(20, _deque.PeekFront(), "Front item should be 20");
            Assert.AreEqual(10, _deque.PeekBack(), "Back item should be 10");
        }

        [Test]
        public void PushBack_OnOneItemDeque_ShouldTransitionToMultipleItemsState()
        {
            _deque.PushFront(10);
            _deque.PushBack(20);

            Assert.AreEqual(2, _deque.Count, "Count should be 2");
            Assert.AreEqual(10, _deque.PeekFront(), "Front item should be 10");
            Assert.AreEqual(20, _deque.PeekBack(), "Back item should be 20");
        }

        [Test]
        public void PopFront_OnOneItemDeque_ShouldTransitionToEmptyState()
        {
            _deque.PushBack(10);
            int item = _deque.PopFront();

            Assert.AreEqual(10, item, "Returned item should be 10");
            Assert.AreEqual(0, _deque.Count, "Count should be 0");
            Assert.IsTrue(_deque.IsEmpty, "Deque should be empty");
        }

        [Test]
        public void PopBack_OnOneItemDeque_ShouldTransitionToEmptyState()
        {
            _deque.PushBack(10);
            int item = _deque.PopBack();

            Assert.AreEqual(10, item, "Returned item should be 10");
            Assert.AreEqual(0, _deque.Count, "Count should be 0");
            Assert.IsTrue(_deque.IsEmpty, "Deque should be empty");
        }

        // --- Тесты для состояния MultipleItems (Требования TR-M1 ... TR-M6) ---
        [Test]
        public void PushFront_OnMultipleItemsDeque_ShouldAddToFront()
        {
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
            _deque.PushBack(10);
            _deque.PushBack(20);
            _deque.PushBack(30);

            int item = _deque.PopBack();

            Assert.AreEqual(30, item, "Returned item should be 30");
            Assert.AreEqual(2, _deque.Count, "Count should be 2");
            Assert.AreEqual(20, _deque.PeekBack(), "New back item should be 20");
        }

        // --- Тесты на корректность после чередования операций ---
        [Test]
        public void MixedOperations_ShouldMaintainCorrectOrder()
        {
            _deque.PushBack(1);
            _deque.PushFront(2);
            _deque.PushBack(3);
            _deque.PushFront(4);

            Assert.AreEqual(4, _deque.Count);
            Assert.AreEqual(4, _deque.PeekFront());
            Assert.AreEqual(3, _deque.PeekBack());

            Assert.AreEqual(4, _deque.PopFront());
            Assert.AreEqual(3, _deque.PopBack());
            Assert.AreEqual(1, _deque.PopBack());
            Assert.AreEqual(2, _deque.PopFront());

            Assert.IsTrue(_deque.IsEmpty);
        }

        // --- Тест на PeekBack после PushFront в пустой дек ---
        [Test]
        public void PushFront_ThenPeekBack_ShouldReturnSameItem()
        {
            _deque.PushFront(42);
            Assert.AreEqual(42, _deque.PeekBack());
        }

        // --- Тест на PeekFront после PushBack в пустой дек ---
        [Test]
        public void PushBack_ThenPeekFront_ShouldReturnSameItem()
        {
            _deque.PushBack(42);
            Assert.AreEqual(42, _deque.PeekFront());
        }

        // --- Тест на PopBack при двух элементах ---
        [Test]
        public void PopBack_WithTwoItems_ShouldWorkCorrectly()
        {
            _deque.PushBack(10);
            _deque.PushBack(20);

            var back = _deque.PopBack();
            Assert.AreEqual(20, back);
            Assert.AreEqual(1, _deque.Count);
            Assert.AreEqual(10, _deque.PeekFront());
            Assert.AreEqual(10, _deque.PeekBack());
            Assert.AreEqual(10, _deque.PopBack());
            Assert.IsTrue(_deque.IsEmpty);
        }

        // --- Тест на PopFront при двух элементах ---
        [Test]
        public void PopFront_WithTwoItems_ShouldWorkCorrectly()
        {
            _deque.PushFront(20);
            _deque.PushFront(10);

            var front = _deque.PopFront();
            Assert.AreEqual(10, front);
            Assert.AreEqual(1, _deque.Count);
            Assert.AreEqual(20, _deque.PeekFront());
            Assert.AreEqual(20, _deque.PeekBack());
            Assert.AreEqual(20, _deque.PopFront());
            Assert.IsTrue(_deque.IsEmpty);
        }

        // --- Тест на корректность _tail после PopFront из состояния с 2 элементами ---
        [Test]
        public void PopFront_FromTwoItems_ShouldUpdateTailCorrectly()
        {
            _deque.PushBack(1);
            _deque.PushBack(2);

            _deque.PopFront();

            Assert.AreEqual(2, _deque.PeekFront());
            Assert.AreEqual(2, _deque.PeekBack());
            Assert.AreEqual(1, _deque.Count);
        }

        // --- Тест на корректность _head после PopBack из состояния с 2 элементами ---
        [Test]
        public void PopBack_FromTwoItems_ShouldUpdateHeadCorrectly()
        {
            _deque.PushFront(2);
            _deque.PushFront(1);

            _deque.PopBack();

            Assert.AreEqual(1, _deque.PeekFront());
            Assert.AreEqual(1, _deque.PeekBack());
            Assert.AreEqual(1, _deque.Count);
        }

        // --- Тест на PushBack в дек из одного элемента ---
        [Test]
        public void PushBack_AfterOneItem_ShouldSetTailCorrectly()
        {
            _deque.PushFront(5);
            _deque.PushBack(6);

            Assert.AreEqual(5, _deque.PeekFront());
            Assert.AreEqual(6, _deque.PeekBack());
            Assert.AreEqual(2, _deque.Count);
        }

        // --- Тест на PushFront в дек из одного элемента ---
        [Test]
        public void PushFront_AfterOneItem_ShouldSetHeadCorrectly()
        {
            _deque.PushBack(5);
            _deque.PushFront(4);

            Assert.AreEqual(4, _deque.PeekFront());
            Assert.AreEqual(5, _deque.PeekBack());
            Assert.AreEqual(2, _deque.Count);
        }

        // --- Тест на PopBack при множестве элементов ---
        [Test]
        public void PopBack_AfterMultiplePushBacks_ShouldReturnLast()
        {
            _deque.PushBack(1);
            _deque.PushBack(2);
            _deque.PushBack(3);
            _deque.PushBack(4);

            Assert.AreEqual(4, _deque.PopBack());
            Assert.AreEqual(3, _deque.PopBack());
            Assert.AreEqual(2, _deque.PopBack());
            Assert.AreEqual(1, _deque.PopBack());
            Assert.IsTrue(_deque.IsEmpty);
        }

        // --- Тест на PopFront при множестве элементов ---
        [Test]
        public void PopFront_AfterMultiplePushFronts_ShouldReturnLastPushed()
        {
            _deque.PushFront(1);
            _deque.PushFront(2);
            _deque.PushFront(3);
            _deque.PushFront(4);

            Assert.AreEqual(4, _deque.PopFront());
            Assert.AreEqual(3, _deque.PopFront());
            Assert.AreEqual(2, _deque.PopFront());
            Assert.AreEqual(1, _deque.PopFront());
            Assert.IsTrue(_deque.IsEmpty);
        }

        // --- Тест на корректность Count ---
        [Test]
        public void Count_ShouldBeAccurateAfterComplexSequence()
        {
            _deque.PushFront(1);
            Assert.AreEqual(1, _deque.Count);
            _deque.PushBack(2);
            Assert.AreEqual(2, _deque.Count);
            _deque.PopFront();
            Assert.AreEqual(1, _deque.Count);
            _deque.PushFront(3);
            Assert.AreEqual(2, _deque.Count);
            _deque.PopBack();
            Assert.AreEqual(1, _deque.Count);
            _deque.PopFront();
            Assert.AreEqual(0, _deque.Count);
        }

        // --- Тест на null-значения ---
        [Test]
        public void CanStoreNullValues()
        {
            var nullDeque = new Deque<string>();
            nullDeque.PushFront(null);
            nullDeque.PushBack("hello");
            Assert.AreEqual(null, nullDeque.PopFront());
            Assert.AreEqual("hello", nullDeque.PopBack());
            Assert.IsTrue(nullDeque.IsEmpty);
        }

        // =============== КРИТИЧЕСКИ ВАЖНЫЕ ТЕСТЫ ДЛЯ УБИЙСТВА МУТАНТОВ ===============

        [Test]
        public void PushBack_ShouldMaintainCorrectOrderInEnumeration()
        {
            _deque.PushBack(1);
            _deque.PushBack(2);
            _deque.PushBack(3);
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 1, 2, 3 }, items);
        }

        [Test]
        public void PopBack_ShouldMaintainCorrectOrderInEnumeration()
        {
            _deque.PushBack(1);
            _deque.PushBack(2);
            _deque.PushBack(3);
            _deque.PopBack();
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 1, 2 }, items);
        }

        [Test]
        public void PopBack_OnOneItem_SetsCountToZero()
        {
            _deque.PushBack(5);
            _deque.PopBack();
            Assert.AreEqual(0, _deque.Count);
        }

        [Test]
        public void PushFront_OnEmptyDeque_SetsTailCorrectly()
        {
            _deque.PushFront(42);
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 42 }, items);
        }

        [Test]
        public void PushBack_OnEmptyDeque_SetsHeadCorrectly()
        {
            _deque.PushBack(42);
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 42 }, items);
        }

        [Test]
        public void AfterPopBack_FromTwoItems_EnumerationIsCorrect()
        {
            _deque.PushBack(10);
            _deque.PushBack(20);
            _deque.PopBack();
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 10 }, items);
        }

        [Test]
        public void AfterPopFront_FromTwoItems_EnumerationIsCorrect()
        {
            _deque.PushFront(20);
            _deque.PushFront(10);
            _deque.PopFront();
            var items = _deque.ToList();
            Assert.AreEqual(new[] { 20 }, items);
        }
    }
}
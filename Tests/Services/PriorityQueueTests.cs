using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using AstroAnts.Services;
using Moq;

namespace Tests.Services
{

    public class DumpData : IComparable<DumpData>
    {
        public int Value { get; set; }

        public DumpData(int value)
        {
            Value = value;
        }

        public int CompareTo(DumpData other)
        {
            return Value > other.Value ? 1 : Value < other.Value ? -1 : 0;
        }
    }

    [TestFixture]
    public class PriorityQueueTests
    {

        private PriorityQueue<int> _priorityQueue;


        [SetUp]
        public void BuildQueue()
        {
            _priorityQueue = new PriorityQueue<int>(10);
        }

        [Test]
        public void PriorityQueueAddTest()
        {
            _priorityQueue.Add(1);
            _priorityQueue.Add(5);
            _priorityQueue.Add(7);
            _priorityQueue.Add(3);
            _priorityQueue.Add(2);

            Assert.AreEqual(_priorityQueue.GetData(), new int[]{1,2,7,5,3});
        }

        [Test]
        public void PriorityQueueGetMinNullTest()
        {
            Assert.Throws<IndexOutOfRangeException>(delegate { _priorityQueue.ExtractMin(); }); // when array is empty
        }

        [Test]
        public void PriorityQueueGetMinTest()
        {
            _priorityQueue.Add(1);
            _priorityQueue.Add(5);
            _priorityQueue.Add(7);
            _priorityQueue.Add(3);
            _priorityQueue.Add(2);

            Assert.AreEqual(_priorityQueue.ExtractMin(), 1);
            Assert.AreEqual(_priorityQueue.ExtractMin(), 2);
            Assert.AreEqual(_priorityQueue.ExtractMin(), 3);
            Assert.AreEqual(_priorityQueue.ExtractMin(), 5);
        }

        [Test]
        public void PriorityQueueContainTest()
        {
            
            _priorityQueue.Add(1);
            _priorityQueue.Add(7);
            _priorityQueue.Add(5);

            Assert.True(_priorityQueue.Contains(1));
            Assert.True(_priorityQueue.Contains(5));
            Assert.False(_priorityQueue.Contains(-1));
            Assert.False(_priorityQueue.Contains(20));
        }

        [Test]
        public void PriorityQueueCombinationAddMinTest()
        {
            _priorityQueue.Add(1);
            _priorityQueue.Add(5);
            _priorityQueue.Add(7);
            _priorityQueue.ExtractMin();
            _priorityQueue.Add(3);
            _priorityQueue.Add(2);
            _priorityQueue.ExtractMin();

            Assert.AreEqual(_priorityQueue.GetData(), new int[] { 3, 7, 5 });
        }

        [Test]
        public void PriorityQueueUpdateDistTest()
        {
            PriorityQueue<DumpData> priorityQueue = new PriorityQueue<DumpData>(10);

            DumpData temp1 = new DumpData(3);
            DumpData temp2 = new DumpData(2);
            DumpData temp3 = new DumpData(10);

            priorityQueue.Add(temp1);
            priorityQueue.Add(temp2);
            priorityQueue.Add(temp3);

            Assert.AreEqual(priorityQueue.GetData(), new DumpData[] { temp2, temp1, temp3 });

            temp3.Value = 1;
            priorityQueue.UpdateDistance(temp3);

            Assert.AreEqual(priorityQueue.GetData(), new DumpData[] { temp3, temp1, temp2 });
        }

        [Test]
        public void PriorityQueueComparatorTest()
        {
            Mock<IComparer<int>> comparator = new Mock<IComparer<int>>();
            comparator.Setup(m => m.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(0); // all values are equal

            Mock<IEqualityComparer<int>> equalityComparer = new Mock<IEqualityComparer<int>>();
            equalityComparer.Setup(m => m.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false); // every int is always different

            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(10, comparator.Object, equalityComparer.Object);

            priorityQueue.Add(7);
            priorityQueue.Add(1);
            priorityQueue.Add(2);

            Assert.AreEqual(priorityQueue.GetData(), new int[] { 7, 1, 2 });

            Assert.AreEqual(priorityQueue.ExtractMin(),7);

        }
    }
}
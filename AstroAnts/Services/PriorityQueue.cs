using System;
using System.Collections.Generic;
using AstroAnts.Graphs;

namespace AstroAnts.Services
{
    public class PriorityQueue<T>
    {
        private int _capacity;

        private readonly Dictionary<T, int> _contains
            ; // slow increase of memory (reference of nodes is kept at two places), but contain atd. operations takes O(1) time

        public PriorityQueue(int capacity)
        {
            Comparer = Comparer<T>.Default;
            EqualityComparer = EqualityComparer<T>.Default;
            Data = new T[capacity];
            Count = 0;
            _contains = new Dictionary<T, int>(EqualityComparer);

            _capacity = capacity;
        }

        public PriorityQueue(int capacity, IComparer<T> comparer, IEqualityComparer<T> equalityComparer)
        {
            Comparer = comparer;
            EqualityComparer = equalityComparer;
            Data = new T[capacity];
            Count = 0;
            _contains = new Dictionary<T, int>(EqualityComparer);

            _capacity = capacity;
        }

        public IComparer<T> Comparer { get; }
        public IEqualityComparer<T> EqualityComparer { get; }
        public T[] Data { get; set; }
        public int Count { get; set; }

        public void Add(T item, bool ignoreReordering = false)
        {
            if (_capacity == Count) IncreaseArray();

            Data[Count] = item; // store item at last place
            _contains.Add(item, Count); // add to hash set
            Count++;

            //PrintData("Add before");
            if (!ignoreReordering) MoveUp(Count - 1); // move to right place
            //PrintData("add after");
        }

        public bool Contains(T item)
        {
            return _contains.ContainsKey(item);
        }

        private void MoveUp(int position)
        {
            while (position > 0 && Comparer.Compare(Data[(position - 1) / 2], Data[position]) == 1
            ) // switch if parent is bigger
            {
                var originalParentPos = (position - 1) / 2;
                Swap(position, originalParentPos);
                position = originalParentPos;
            }
        }

        private void MoveDown(int position)
        {
            // binary tree -> two childrens
            var lchild = 2 * position + 1;
            var rchild = 2 * position + 2;
            var largest = 0;
            if (lchild < Count && Comparer.Compare(Data[lchild], Data[position]) == -1
            ) // move child up if bigger that parent
                largest = lchild;
            else
                largest = position;
            if (rchild < Count && Comparer.Compare(Data[rchild], Data[largest]) == -1)
                largest = rchild;
            if (largest != position) // move childs if position was changed
            {
                Swap(position, largest);
                MoveDown(largest); // continue 
            }
        }

        public void UpdateDistance(T item)
        {
            if(Contains(item)) MoveUp(_contains[item]);
        }

        private  void Swap(int position1, int position2)
        {
            _contains[Data[position1]] = position2;
            _contains[Data[position2]] = position1;

            var temp = Data[position1];
            Data[position1] = Data[position2];
            Data[position2] = temp;
        }

        public T ExtractMin(bool ignoreReordering = false) // !!removes min value
        {
            //PrintData("Data");
            if (Count == 0) throw new IndexOutOfRangeException();

            var item = Data[0]; // obtain first
            Swap(0, Count - 1); //move first to last
            Count--; // shorten heap
            if (!ignoreReordering)
                MoveDown(0); // reorder
            _contains.Remove(item);

            return item;
        }

        public T[] GetData()
        {
            T[] res = new T[Count];
            Array.Copy(Data, 0, res, 0, Count);
            return res;
        }

        private void IncreaseArray(int multiply = 2)
        {
            _capacity *= multiply;
            var DataTemp = new T[_capacity];
            for (var i = 0; i < Count; i++) DataTemp[i] = Data[i];
            Data = DataTemp;
        }

        private void PrintData(string info = "")
        {
            if (info != "") Console.Write(info + ": ");

            for (var i = 0; i < Count; i++)
            {
                if (Data[i] == null) break;
                Console.Write((Data[i] as GraphNodeHeuristic).NodeValue + " ");
            }
            Console.WriteLine();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._3_DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] arr;

        public DynamicArray()
        {
            this.Capacity = 8;
            T[] arr = new T[this.Capacity];
        }

        public DynamicArray(int capacity)
        {
            this.Capacity = 8;
            this.Arr = new T[this.Capacity];
            this.Length = this.Arr.Count();
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.Length = collection.Count();
            this.Capacity = this.Length;
            T[] arr = new T[this.Capacity];
            this.arr = collection.ToArray();
        }

        public int Length { get; set; }

        public int Capacity { get; set; }

        public T[] Arr
        {
            get { return this.arr; }
            set { this.arr = value; }
        }

        public void Add(T item)
        {
            if (this.Arr.Length < this.Arr.Count())
            {
                this.Arr[this.Arr.Count() + 1] = item;
            }
            else
            {
                Array.Resize(ref this.arr, this.Arr.Length * 2);
                this.Arr[this.Arr.Count() + 1] = item;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (this.Arr.Length < this.Arr.Length + collection.Count())
            {
                Array.Resize(ref this.arr, this.Arr.Length + collection.Count());
            }

            Array.Copy(collection.ToArray(), 0, this.Arr, this.Arr.GetUpperBound(0) + 1, collection.Count());
        }

        public void Remove(T item)
        {
            for (int i = 0; i < this.Arr.Length; i++)
            {
                if (this.Arr[i].Equals(item))
                {
                    Array.Clear(this.Arr, i, 1);
                }
            }
        }

        public void Insert(int n, IEnumerable<T> collection)
        {
            T[] temp = null;

            if (this.Arr.Length < this.Arr.Length + collection.Count())
            {
                Array.Resize(ref this.arr, this.Arr.Length + collection.Count());
            }

            Array.Copy(this.Arr, n, temp, 0, collection.Count());
            Array.Copy(collection.ToArray(), 0, this.Arr, n + 1, temp.Length);
            Array.Copy(temp, 0, this.Arr, this.Arr.GetUpperBound(0) + 1, temp.Count());
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

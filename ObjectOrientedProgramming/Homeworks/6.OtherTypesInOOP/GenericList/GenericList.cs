using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    using System.Collections;

    class GenericList<T> : IEnumerable where T : IComparable
    {
        private const int DefaultCapacity = 16;

        private T[] array;

        private int currentIndex;

        public GenericList(int initialCapacity = DefaultCapacity)
        {
            this.array = new T[initialCapacity];
            this.Count = this.currentIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }

            private set
            {
                this.currentIndex = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException("Index is outside the boundaries of the GenericList.");
                }

                return this.array[index];
            }
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The GenericList is empty");
            }

            T minEelement = this.array[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (minEelement.CompareTo(this.array[i]) > 0)
                {
                    minEelement = this.array[i];
                }
            }

            return minEelement;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The GenericList is empty");
            }

            T maxEelement = this.array[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (maxEelement.CompareTo(this.array[i]) < 0)
                {
                    maxEelement = this.array[i];
                }
            }

            return maxEelement;
        }

        public void Add(T elementToAdd)
        {
            if (this.Count + 1 >= this.array.Length)
            {
                this.ResizeList();
            }

            this.array[this.Count] = elementToAdd;

            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException("Index is outside the boundaries of the GenericList.");
            }

            T[] newArray = new T[this.array.Length];
            Array.Copy(this.array, 0, newArray, 0, index);
            Array.Copy(this.array, index + 1, newArray, index, this.Count - index - 1);

            this.Count--;
            this.array = newArray;
        }

        public void Remove(T elementToRemove)
        {
            int index = this.IndexOf(elementToRemove);

            if (index == -1)
            {
                throw new ArgumentException("Specified element was not found.");
            }

            this.RemoveAt(index);
        }

        public void InsertAt(int index, T newElement)
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("List is empty");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(string.Format("Invalid index: {0}.", index));
            }

            if (this.Count == this.array.Length)
            {
                this.ResizeList();
            }

            T[] newArray = new T[this.Capacity];
            Array.Copy(this.array, 0, newArray, 0, index);
            newArray[index] = newElement;

            this.Count++;
            Array.Copy(this.array, index, newArray, index + 1, this.Count - index - 1);
            this.array = newArray;
        }

        public int IndexOf(T elementToFind)
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int index = 0; index < this.Count; index++)
            {
                if (object.ReferenceEquals(this.array[index], elementToFind))
                {
                    return index;
                }

                if (typeof(T).IsValueType && this.array[index].Equals(elementToFind))
                {
                    return index;
                }
            }

            return -1;
        }

        public void Clear()
        {
            this.Count = 0;
            this.array = new T[DefaultCapacity];
        }

        public int LastIndexOf(T elementToFind)
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int index = this.Count - 1; index >= 0; index--)
            {
                if (object.ReferenceEquals(this.array[index], elementToFind))
                {
                    return index;
                }

                if (typeof(T).IsValueType && this.array[index].Equals(elementToFind))
                {
                    return index;
                }
            }

            return -1;
        }

        public bool Contains(T elementToCheck)
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("List is empty");
            }

            bool contains = this.IndexOf(elementToCheck) != -1;
            return contains;
        }

        public override string ToString()
        {
            var resultElements = this.array.Take(this.Count);

            return this.Count > 0 ? string.Join(", ", resultElements) : "list is empty";
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.array.Take(this.Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Version()
        {
            Type type = typeof(GenericList<T>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var ver in allAttributes)
            {
                if (ver is VersionAttribute)
                {
                    VersionAttribute temp = ver as VersionAttribute;
                    Console.WriteLine("GenericList Version {0}.{1}", temp.MajorVersion, temp.MinorVersion.ToString("X2"));
                }
            }
        }

        private void ResizeList()
        {
            int newArraySize = this.array.Length * 2;
            T[] newArray = new T[newArraySize];

            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}

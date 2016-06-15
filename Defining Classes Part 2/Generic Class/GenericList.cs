namespace DefiningClassesHomework2
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int InitialSize = 8;
        private T[] elements;
        private int nextIndex;
       
        public GenericList()
        {
            this.Length = InitialSize;
            this.elements = new T[InitialSize];
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.nextIndex;
            }

            private set
            {
                if (value == this.Length)
                {
                    var length = this.Length * 2;
                    var newElements = new T[length];

                    for (int i = 0; i < this.Length; i++)
                    {
                        newElements[i] = this.elements[i];
                    }

                    this.elements = newElements;
                    this.nextIndex = this.Length;
                    this.Length = length;
                }
                else
                {
                    this.nextIndex = value;
                }
            }
        }

        private int Length { get; set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Requested index: " + index + " is outside the bounds of the collection");
                }

                return this.elements[index];
            }

            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException("Requested index: " + index + " is outside the bounds of the collection");
                }
                else if (index == this.Count)
                {
                    this.Count++;
                }

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            this.elements[this.Count] = element;
            this.Count++;
        }

        public void Add(params T[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                this.Add(list[i]);
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element.Equals(this.elements[i]))
                {
                    return i;
                }
            }

            return -1;  
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T[] elementsBeforeIndex;

            if (index != 0)
            {
                elementsBeforeIndex = new T[index];
                Array.Copy(this.elements, 0, elementsBeforeIndex, 0, index);
            }
            else
            {
                elementsBeforeIndex = new T[0];
            }

            T[] elementsAfterIndex;

            if (index != this.Count - 1)
            {
                elementsAfterIndex = new T[this.Count - index - 1];
                Array.Copy(this.elements, index + 1, elementsAfterIndex, 0, this.Count - index - 1);
            }
            else
            {
                elementsAfterIndex = new T[0];
            }
          
            this.Clear();

            if (index != 0)
            {
                this.Add(elementsBeforeIndex);
            }

            if (index != this.Count - 1)
            {
                this.Add(elementsAfterIndex);
            }         
        }

        public void InsertAt(int index, T element) 
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T[] elementsBeforeIndex;

            if (index != 0)
            {
                elementsBeforeIndex = new T[index];
                Array.Copy(this.elements, 0, elementsBeforeIndex, 0, index);
            }
            else
            {
                elementsBeforeIndex = new T[0];
            }

            T[] elementsAfterIndex;

            if (index != this.Count)
            {
                elementsAfterIndex = new T[this.Count - index - 1];
                Array.Copy(this.elements, index + 1, elementsAfterIndex, 0, this.Count - index - 1);
            }
            else
            {
                elementsAfterIndex = new T[0];
            }

            this.Clear();

            if (index != 0)
            {
                this.Add(elementsBeforeIndex);
            }

            this.Add(element);

            if (index != this.Count)
            {
                this.Add(elementsAfterIndex);
            }         
        }

        public void Clear()
        {
            this.Length = InitialSize;
            this.elements = new T[InitialSize];
            this.Count = 0;
        }

        public T Min()
        {
            T min = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                strBuilder.Append(String.Format("[{0}]: {1}", i, this.elements[i]));
                strBuilder.Append("\n");
            }

            strBuilder.Remove(strBuilder.Length - 1, 1);

            return strBuilder.ToString();
        }
    }
}

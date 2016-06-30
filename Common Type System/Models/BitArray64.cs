namespace Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private readonly int hash;
        private ulong number;

        public BitArray64(ulong number)
        {
            this.number = number;
            this.hash = number.GetHashCode();
        }

        public int this[int i]
        {
            get
            {
                ulong mask = (ulong)1 << i;
                mask &= this.number;
                return mask == 0
                    ? 0
                    : 1;
            }

            set
            {
                if (i < 0 || i > 64)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value == 0)
                {
                    this.number &= ~((ulong)1 << i);
                }
                else if (value == 1)
                {
                    this.number |= (ulong)1 << i;
                }
                else
                {
                    throw new ArgumentException("Only 0 or 1 values allowed");
                }
            }
        }

        public static bool operator ==(BitArray64 b1, BitArray64 b2)
        {
            return b2 != null && b1 != null && b1.number == b2.number;
        }

        public static bool operator !=(BitArray64 b1, BitArray64 b2)
        {
            return !(b1 == b2);
        }

        public override int GetHashCode()
        {
            return this.hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as BitArray64;

            return other != null && other.number == this.number;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

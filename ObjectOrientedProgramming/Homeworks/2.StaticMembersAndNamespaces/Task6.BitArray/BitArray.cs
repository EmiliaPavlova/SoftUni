using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task6.BitArray
{
    class BitArray
    {
        private byte[] bitArr;
        private int length;

        public BitArray(int length)
        {
            this.Length = length;
            this.BitArr = new byte[length];
            for (int i = 0; i < length; i++)
            {
                BitArr[i] = 0;
            }
        }

        public byte[] BitArr { get; set; }

        public int Length
        {
            get { return this.length; }

            set
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("The length must be in the range:[1...100 000]");
                }
                this.length = value;
            }
        }

        public byte this[int index]
        {
            get
            {
                return this.BitArr[index];
            }
            set
            {
                if (index < 0 || index >= 100000)
                {
                    throw new ArgumentOutOfRangeException("The index must be in the range:[0...100 000]");
                }
                this.BitArr[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger result = 0;
            int i = 0;
            while (i < BitArr.Length)
            {
                if (BitArr[i] == 1)
                {
                    int count = i / 64;
                    int index = i % 64;
                    BigInteger tempResult = 1;

                    for (int j = 0; j < count; j++)
                    {
                        tempResult *= BitArr[i] * (BigInteger)Math.Pow(2, 64);
                    }
                    tempResult *= BitArr[i] * (BigInteger)Math.Pow(2, index);
                    result += tempResult;
                }

                i++;
            }
            return result.ToString();
        }
    }
}

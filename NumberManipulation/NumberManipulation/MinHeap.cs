using System;
using System.Diagnostics;

namespace NumberManipulation
{
    public class MinHeap
    {
        public int[] data;
        int count = 0;
        int limit;

        public MinHeap(int limit)
        {
            this.data = new int[limit];
            this.limit = limit;
        }

        public int DeleteMin()
        {
            if (count == 0)
            {
                return -1;
            }

            int minVal = this.data[0];
            this.data[0] = this.data[count - 1];

            count--;

            int idx = 0;

            while (true)
            {
                int lc = (idx) * 2 + 1, rc = (idx) * 2 + 2;
                int lv = lc >= count ? int.MaxValue : this.data[lc];
                int rv = rc >= count ? int.MaxValue : this.data[rc];

                if (this.data[idx] < lv && this.data[idx] < rv)
                {
                    break;
                }
                if (this.data[idx] > rv && rv <= lv)
                {
                    this.data[rc] = this.data[idx];
                    this.data[idx] = rv;
                    idx = rc;
                }
                else if (this.data[idx] > lv && lv <= rv)
                {
                    this.data[lc] = this.data[idx];
                    this.data[idx] = lv;
                    idx = lc;
                }
            }

            return minVal;
        }

        public void Insert(int value)
        {
            if (count == limit)
            {
                count--;
                this.DeleteMin();
            }

            int idx = count++;
            data[idx] = value;

            while (idx != 0)
            {
                int parent = (idx - 1) / 2;
                if (this.data[idx] < this.data[parent])
                {
                    int temp = this.data[idx];
                    this.data[idx] = this.data[parent];
                    this.data[parent] = temp;
                    idx = parent;
                    continue;
                }

                break;                
            }
        }


        public void TestSort()
        {
            var r = new Random();
            for (int i = 0; i < limit; i++)
            {
                this.Insert(r.Next()%10000);
            }

            int prev = 0;
            while (count != 0)
            {
                int pres = this.DeleteMin();
                Debug.Assert(prev <= pres);
                Console.WriteLine(pres);
                prev = pres;
            }
        }
    }
}

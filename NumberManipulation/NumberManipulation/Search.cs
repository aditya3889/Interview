using System.Diagnostics;

namespace NumberManipulation
{
    public class Search
    {
        public static int FindIndexOf(int[] values, int data)
        {
            if (values == null || values.Length == 0)
            {
                return -1;
            }

            int end = values.Length-1, start = 0;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (values[mid] > data)
                {
                    end = mid - 1;
                }
                else if (values[mid] < data)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static int FindFirstIndexOf(int[] values, int data)
        {
            if (values == null || values.Length == 0)
            {
                return -1;
            }

            int end = values.Length - 1, start = 0;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (values[mid] > data)
                {
                    end = mid - 1;
                }
                else if (values[mid] < data)
                {
                    start = mid + 1;
                }
                else
                {
                    if (mid - 1 >= 0 && values[mid-1] == data)
                    {
                        end = mid - 1;
                        continue;
                    }

                    return mid;
                }
            }

            return -1;
        }

        public static void TestFindIndexOf()
        {
            Debug.Assert(FindIndexOf(null, 2) == -1);
            Debug.Assert(FindIndexOf(new int[] { 2 }, 2) == 0);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3} , 2) == 1);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3 }, 0) == -1);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3 }, 1) == 0);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3 }, 3) == 2);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3 }, 4) == -1);
            Debug.Assert(FindIndexOf(new int[] { 1, 2, 3, 4 }, 4) == 3);
        }

        public static void TestFindFirstIndexOf()
        {
            Debug.Assert(FindFirstIndexOf(null, 2) == -1);
            Debug.Assert(FindFirstIndexOf(new int[] { 2 }, 2) == 0);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3 }, 2) == 1);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3 }, 0) == -1);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3 }, 1) == 0);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3 }, 3) == 2);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3 }, 4) == -1);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3, 4 }, 4) == 3);
            Debug.Assert(FindFirstIndexOf(new int[] { 2, 2, 2 }, 2) == 0);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 2, 2, 3 }, 2) == 1);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 2, 3 }, 2) == 1);
            Debug.Assert(FindFirstIndexOf(new int[] { 1, 2, 3, 3 }, 3) == 2);

        }
    }
}

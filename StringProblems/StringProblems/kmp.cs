namespace StringProblems
{
    using System.Diagnostics;

    public class kmp
    {
        public static int[] BuildFailureTable(string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return new int[0];
            }

            int nL = needle.Length;
            int[] failureTable = new int[nL + 1];
            failureTable[0] = failureTable[1] = 0;
            for (int i = 2; i < nL; i++)
            {
                int cnd = failureTable[i - 1];
                while (true)
                {
                    if (needle[i - 1] == needle[cnd])
                    {
                        failureTable[i] = cnd + 1;
                        break;
                    }
                    else if (cnd == 0)
                    {
                        failureTable[i] = 0;
                        break;
                    }
                    else
                    {
                        cnd = failureTable[cnd];
                    }
                }
            }

            return failureTable;
        }

        public static int FindIndexOf(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
            {
                return -1;
            }

            int[] failureTable = BuildFailureTable(needle);
            int cnd = 0, i = 0, hL = haystack.Length, nL = needle.Length;
            
            while (i < hL)
            {
                if (haystack[i] == needle[cnd])
                {
                    cnd++;
                    i++;
                    if (cnd == nL)
                    {
                        return i-cnd;
                    }

                }
                else if (cnd == 0)
                {
                    i++;
                }
                else
                {
                    cnd = failureTable[cnd];
                }
            }

            return -1;
        }

        public static void Test()
        {
            Debug.Assert(FindIndexOf("abcaba", "bc") == 1);
            Debug.Assert(FindIndexOf("abcaba", "cd") == -1);
            Debug.Assert(FindIndexOf("abcababcabd", "abcabd") == 5);

        }
    }
}

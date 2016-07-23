using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProblems
{
    public class StringManipulation
    {
        public static string ReverseString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            StringBuilder sb = new StringBuilder();
            int end = s.Length - 1;
            while (end >= 0)
            {
                sb.Append(s[end--]);
            }

            return sb.ToString();
        }

        public static void TestReverseString()
        {
            Debug.Assert(String.Equals(ReverseString("hello"), "olleh"));
            Debug.Assert(String.Equals(ReverseString(null), null));
            Debug.Assert(String.Equals(ReverseString(""), ""));
            Debug.Assert(String.Equals(ReverseString("hell"), "lleh"));
        }
    }
}

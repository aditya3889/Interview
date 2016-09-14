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

        public static void Reverse(List<char> arr, int start, int end)
        {
            while (start < end)
            {
                char temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++; end--;
            }

            return;
        }

        public static bool isValidChar(char c)
        {
            return !(c == ' ' || c == '\b' || c == '\t');
        }

        public static string ReverseWords(string s)
        {
            s = s.Trim();
            var arr = new List<char>();
            int l = s.Length;

            int idx = 0, i = 0;
            while (i < l && !isValidChar(s[i]))
            {
                i++;
            }

            bool isPrevWhitespace = false;
            while (i < l)
            {
                if (isValidChar(s[i]))
                {
                    arr.Add(s[i++]);
                    isPrevWhitespace = false;
                }
                else
                {
                    if (!isPrevWhitespace)
                    {
                        arr.Add(s[i++]);
                    }
                    else
                    {
                        i++;
                    }

                    isPrevWhitespace = true;
                }
            }

            l = arr.Count;

            Reverse(arr, 0, l - 1);
            int start = 0;
            while (i < l)
            {
                while (start < l && !isValidChar(arr[start]))
                {
                    start++;
                }

                i = start;
                while (i < l && isValidChar(arr[i]))
                {
                    i++;
                }

                Reverse(arr, start, i - 1);
            }



            return new string(arr.ToArray());
        }

        public static void TestReverseString()
        {
            Debug.Assert(String.Equals(ReverseString("hello"), "olleh"));
            Debug.Assert(String.Equals(ReverseString(null), null));
            Debug.Assert(String.Equals(ReverseString(""), ""));
            Debug.Assert(String.Equals(ReverseString("hell"), "lleh"));

            Debug.Assert(String.Equals(ReverseWords("   a   b   "), "b a"));
        }
    }
}

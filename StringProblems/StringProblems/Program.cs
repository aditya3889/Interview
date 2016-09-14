using System;

namespace StringProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //kmp.Test();
            //StringManipulation.TestReverseString();
            Trie c = new Trie();
            c.AddWord("a");
            c.AddWord("ab");
            c.AddWord("bad");
            Console.WriteLine(c.Search("a"));
            Console.WriteLine(c.Search("a."));
            Console.WriteLine(c.Search("ab"));
            Console.WriteLine(c.Search(".a"));
            Console.WriteLine(c.Search(".b"));
            Console.WriteLine(c.Search("ab."));
            Console.WriteLine(c.Search("."));
            Console.WriteLine(c.Search(".."));
            Console.WriteLine(c.Search("..d"));
        }
    }
}

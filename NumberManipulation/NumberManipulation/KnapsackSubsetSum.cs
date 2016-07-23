using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberManipulation
{
    public class KnapsackSubsetSum
    {
        public class Candidate
        {
            public List<List<int>> Candidates { get; private set; }
            private int count;

            public Candidate()
                : this(false)
            {
            }

            public Candidate(bool initializeEmptySolution)
            {
                this.Candidates = new List<List<int>>();
                if (initializeEmptySolution)
                {
                    this.Candidates.Add(new List<int>());
                    this.count += 1;
                }
            }            

            public bool IsReachable()
            {
                return this.Candidates.Any();
            }

            public void Append(int data)
            {
                for (int i = 0; i < count; i++)
                {
                    this.Candidates[i].Add(data);
                }
            }

            public void AppendRange(Candidate candidate)
            {
                if (candidate == null)
                {
                    return;
                }

                this.Candidates.AddRange(candidate.Candidates.Select(t => t.Select(u => u).ToList()).ToList());
                this.count += candidate.Candidates.Count();
            }

            internal void Print()
            {
                if (!this.IsReachable())
                {
                    Console.WriteLine("No solutions");
                }

                for (int i = 0; i < this.Candidates.Count(); i++)
                {
                    for (int j=0; j < this.Candidates[i].Count(); j++)
                    {
                        Console.Write(this.Candidates[i][j] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        // Equivalent to the 0-1 knapsack problem.
        // [1,1,2,3,4,5] -> [[1,2,3,4], [1,2,3,4], [2,3,5], [1,4,5]]
        // [1,2,3,4,5], 10 -> [[1,2,3,4], [2,3,5], [1,4,5]]
        public static void PrintAllSubsetSums(int[] values, int sum)
        {
            if (values == null || sum < 0)
            {
                return;
            }

            int nums = values.Length;
            Candidate[,] candidates = new Candidate[sum+1, nums + 1];

            for (int i=0; i <= nums; i++)
            {
                candidates[0, i] = new Candidate(true);
            }
            for (int i=1; i <= sum; i++)
            {
                candidates[i, 0] = new Candidate();
            }

            for (int i=1; i <= sum; i++)
            {
                for (int j = 1; j <= nums; j++)
                {
                    var currentCandidates = new Candidate(false);
                    if (i - values[j-1] >= 0 && candidates[i-values[j-1], j - 1].IsReachable())
                    {
                        currentCandidates.AppendRange(candidates[i - values[j - 1], j - 1]);
                        currentCandidates.Append(values[j - 1]);
                    }
                    if (candidates[i, j - 1].IsReachable())
                    {
                        currentCandidates.AppendRange(candidates[i, j - 1]);
                    }

                    candidates[i, j] = currentCandidates;
                }
            }

            candidates[sum, nums].Print();
        }

        public static void TestAllSubsetSums()
        {
            PrintAllSubsetSums(new int[] { 2, 2, 3, 5, 7, 8 }, 10);
            PrintAllSubsetSums(new int[] { 2, 2, 3, 5, 7, 8 }, 27);
            PrintAllSubsetSums(new int[] { 8 }, 27);
            PrintAllSubsetSums(new int[] { 1, 2, 3, 4, 5 }, 10);
            PrintAllSubsetSums(new int[] { 1, 1, 2, 3, 4, 5 }, 10);
        }
    }
}

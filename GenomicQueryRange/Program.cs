using System;

namespace GenomicQueryRange
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "CAGCCTA";
            int[] P = { 2, 5, 0 };
            int[] Q = { 4, 5, 6 };
            Console.WriteLine(solution(S,P,Q));
        }
        public static string solution(string S, int[] P, int[] Q)
        {
            var nuclueotide = new int[S.Length + 1, 4];
            for (int i = 0; i < S.Length; i++)
            {
                //find the prefix sum of each of the nuclueotides
                if (i > 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        nuclueotide[i + 1, j] += nuclueotide[i, j];
                    }
                }
                //mark the position of each nuclueotide in a 2D array
                switch (S[i])
                {
                    case 'A':
                        nuclueotide[i + 1, 0]++;
                        break;
                    case 'C':
                        nuclueotide[i + 1, 1]++;
                        break;
                    case 'G':
                        nuclueotide[i + 1, 2]++;
                        break;
                    case 'T':
                        nuclueotide[i + 1, 3]++;
                        break;
                }
            }
            //return the value of the minimal impact factor of nucleotides contained in the given range
            int[] final = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] == Q[i])
                {
                    switch (S[P[i]])
                    {
                        case 'A':
                            final[i] = 1;
                            break;
                        case 'C':
                            final[i] = 2;
                            break;
                        case 'G':
                            final[i] = 3;
                            break;
                        case 'T':
                            final[i] = 4;
                            break;
                    }
                }
                else
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if ((nuclueotide[Q[i] + 1, k] - nuclueotide[P[i], k]) > 0)
                        {
                            final[i] = k + 1;
                            break;
                        }
                    }
                }
            }
            var result = String.Join(',', final);
            return result;
        }

    }
}

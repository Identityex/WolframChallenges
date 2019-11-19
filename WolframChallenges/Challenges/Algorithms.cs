using System;
using System.Collections.Generic;
using System.Text;
using WolframChallenges.Shared;

namespace WolframChallenges.Challenges
{
    public class Algorithms
    {
        private readonly IUtilities _utilities;
        public Algorithms(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public long Exponentiation(long num, long exp, long result = 1)
        {
            if (exp == 0)
            {
                return result;
            }
            else if (exp % 2 == 0)
            {
                result = Exponentiation(num * num, exp / 2, result);
            }
            else
            {
                result = result * num;
                result = Exponentiation(num * num, (exp - 1) / 2, result);
            }
            return result;
        }

        public void KMPSearch(string pat, string txt)
        {
            int patLength = pat.Length;
            int txtLength = txt.Length;

            // create lps[] that will hold the longest prefix suffix values for pattern 
            int[] lps = new int[patLength];
            int j = 0; 

            // Preprocess the pattern (calculate lps[] array) 
            ComputeLPSArray(pat, patLength, lps);

            int i = 0; // index for txt[] 
            while (i < txtLength)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == patLength)
                {
                    Console.Write("Found pattern "
                                  + "at index " + (i - j));
                    j = lps[j - 1];
                }

                // mismatch after j matches 
                else if (i < txtLength && pat[j] != txt[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, 
                    // they will match anyway 
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }
        }

        private void ComputeLPSArray(string pat, int patLength, int[] lps)
        {
            // length of the previous longest prefix suffix 
            int len = 0;
            int i = 1;
            lps[0] = 0; // lps[0] is always 0 

            // the loop calculates lps[i] for i = 1 to patLength-1 
            while (i < patLength)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len]) 
                {
                    // This is tricky. Consider the example. 
                    // AAACAAAA and i = 7. The idea is similar 
                    // to search step. 
                    if (len != 0)
                    {
                        len = lps[len - 1];

                        // Also, note that we do not increment 
                        // i here 
                    }
                    else // if (len == 0) 
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}

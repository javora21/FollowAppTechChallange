using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortItOut
{
    class EarlierSymbolComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {

            if (s1.Equals(s2))
            {
                return 0;
            }
            //getting char array form every word
            char[] s1CharArray = s1.ToLower().ToCharArray();
            char[] s2CharArray = s2.ToLower().ToCharArray();
            return CompareCharArrays(s1CharArray, s2CharArray);
        }
        private int CompareCharArrays(char[] s1array, char[] s2array)
        {
            //empty string catching
            if (s1array.Length == 0)
            {
                return -1;
            }
            if(s2array.Length == 0)
            {
                return 1;
            }
            //earlier char form word
            char s1MinChar = s1array.Min();
            char s2MinChar = s2array.Min();
            if (s1MinChar == s2MinChar)
            {
                //if earlier chars are equal then compare one more time without them
                List<char> s1list = s1array.ToList();
                s1list.Remove(s1MinChar);
                char[] newArrayX = s1list.ToArray();

                List<char> s2list = s2array.ToList();
                s2list.Remove(s1MinChar);
                char[] newArrayY = s2list.ToArray();

                return CompareCharArrays(newArrayX, newArrayY);
            }
            if (s1MinChar < s2MinChar)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}

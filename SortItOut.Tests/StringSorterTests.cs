using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SortItOut.Tests
{
    [TestClass]
    public class StringSorterTests
    {
        [TestMethod]
        public void Sort_c_b_a_d_Resulted_a_b_c_d()
        {
            List<string> list = new List<string>
            {
                "c",
                "b",
                "a",
                "d"
            };
            List<string> sortedList = new List<string>
            {
                "a",
                "b",
                "c",
                "d"
            };
            StringSorter stringSorter = new StringSorter(list);
            list = stringSorter.Sort().ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }
        [TestMethod]
        public void Sort_ba_aa_bb_ab_Resulted_aa_ab_ba_bb()
        {
            List<string> list = new List<string>
            {
                "ba",
                "aa",
                "bb",
                "ab"
            };
            List<string> sortedList = new List<string>
            {
                "aa",
                "ab",
                "ba",
                "bb"
            };
            StringSorter stringSorter = new StringSorter(list);
            list = stringSorter.Sort().ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }
        [TestMethod]
        public void Sort_a_empty_Resulted_empty_a()
        {
            List<string> list = new List<string>
            {
                "a",
                ""
            };
            List<string> sortedList = new List<string>
            {
                "",
                "a"
            };
            StringSorter stringSorter = new StringSorter(list);
            list = stringSorter.Sort().ToList();
            CollectionAssert.AreEqual(list, sortedList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortItOut
{
    public class StringSorter
    {
        private IEnumerable<string> _list { get; set; }
        public StringSorter(IEnumerable<string> list)
        {
            _list = list;
        }
        public IEnumerable<string> Sort()
        {
            return _list.OrderBy(str => str, new EarlierSymbolComparer());//Sort list by specific comparer
        }
    }
}

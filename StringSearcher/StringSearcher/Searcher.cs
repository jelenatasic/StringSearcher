using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    interface Searcher
    {
        List<int> Search(String pattern, String text);
        void ClearIndexes();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class NaiveSearcher : Searcher
    {
        //lista pamti pozicije unutar text-a na kojima pocinje pattern
        List<int> start_indexex;    

        public NaiveSearcher()
        {
            start_indexex = new List<int>();
        }

        public List<int> Search(String pattern, String text)
        {
            if (text.Length < pattern.Length)
                return start_indexex;

            //brojac koji broji slova identicna u pattern-u i delu teksta koji se obradjuje
            int pattern_ptr;

            //text_ptr cuva poziciju unutar teksta do koje smo dosli sa pretrazivanjem
            for (int text_ptr = 0; text_ptr <= text.Length - pattern.Length; text_ptr++)        
            {
                pattern_ptr = 0;
                while (pattern_ptr < pattern.Length && pattern[pattern_ptr] == text[text_ptr + pattern_ptr])
                    pattern_ptr++;

                //uslov koji je ispunjen kada smo pronasli pattern unutar teksta na poziciji text_ptr
                if (pattern_ptr == pattern.Length)
                    start_indexex.Add(text_ptr);
            }
            return start_indexex;
        }

        public void ClearIndexes()
        {
            start_indexex.Clear();
        }
    }
}

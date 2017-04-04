using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class RabinKarpSearcher : Searcher
    {
        List<int> start_indexex;        //lista pamti pozicije unutar text-a na kojima pocinje pattern
        private int pattern_hash;
        private int text_hash;

        const int B = 257, M = 997;

        public RabinKarpSearcher()
        {
            start_indexex = new List<int>();
        }

        private int CalculateHash(String _string)
        {
            int b_to_power_m = 1;       // B^0
            int hash = _string[_string.Length - 1];     //_string[m-1] * B^0
                                                        //m = pattern.Length
            for (int i = 1; i < _string.Length; i++)
            {
                b_to_power_m = (b_to_power_m * B) % M;  //B^(i) % M
                int part_of_sum = (_string[_string.Length - i - 1] * b_to_power_m) % M;   //_string[m-i-1] * B^(i) % M
                hash = (hash + part_of_sum) % M;
            }
            return hash;
        }

        public List<int> Search(String pattern, String text)
        {
            if (text.Length < pattern.Length || pattern.Length == 0)
                return start_indexex;

            int b_to_power_m_mod_M = 1;                 //B^(m-1) % M - ova vrednost je potreba za racunanje svakog narednog hesa dela teksta
                                                        //m = pattern.Length
            for (int i = 1; i < pattern.Length; i++)
                b_to_power_m_mod_M = (b_to_power_m_mod_M * B) % M;


            pattern_hash = CalculateHash(pattern);
            
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (i == 0)
                    text_hash = CalculateHash(text.Substring(0, pattern.Length));       //inicijalno je hes potrebno izracunati za prvih m karaktera teksta
                else
                {
                    int hash_subtract = positive_mod(text_hash - (text[i - 1] * b_to_power_m_mod_M) % M, M);     //od stare vrednosti hesa oduzeti tezinu koju je doprinosilo 
                                                                                                                //slovo koje vise nije deo podstringa koji se posmatra
                                                                                                             //rezultat mora biti pozitivan
                    text_hash = (hash_subtract * B % M + text[i - 1 + pattern.Length]) % M;             //mnozenjem sa B se tezina kojom svako slovo ucestvuje dize za stepen vise
                }                                                                                       //dodaje se tezina slova koje se poslednje pojavilo u okviru podstringa

                if (pattern_hash == text_hash)
                {
                    if (CheckForMatch(pattern, text.Substring(i, pattern.Length)))          //potrebna je dodatna provera, karakter po karakter
                        start_indexex.Add(i);
                }
            }

            return start_indexex;
        }

        private int positive_mod(int number, int mod)
        {
            return (number % mod + mod) % mod;
        }

        private bool CheckForMatch(String pattern, String part_of_text)
        {
            int index = 0;
            while ((index < pattern.Length) && (pattern[index] == part_of_text[index]))
                index++;

            if (index == pattern.Length)
                return true;
            else
                return false;
        }

        public void ClearIndexes()
        {
            start_indexex.Clear();
        }
    }
}

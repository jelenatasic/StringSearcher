using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class KnuthMorrisPrattSearcher : Searcher
    {
        List<int> start_indexex;
        List<int> backward_transition_states;

        public KnuthMorrisPrattSearcher()
        {
            backward_transition_states = new List<int>();
            start_indexex = new List<int>();
        }

        private void InitializeBackwardStates(String pattern)
        {
            backward_transition_states.Add(0);      //duzina ovkira praznog stringa
            backward_transition_states.Add(0);      //duzina okvira prefiksa duzine 1

            for (int i = 2; i <= pattern.Length; i++)   //za prefiks pattern-a duzine i
            {
                int j = backward_transition_states[i - 1];      //duzina okvira prethodnog prefiksa

                while (true)
                {
                    if (pattern[i - 1] == pattern[j])             //slucaj kada je okvir za prefiks duzine i, veci od okvira za prefiksa duzine i-1
                    {
                        j++;
                        backward_transition_states.Add(j);
                        break;
                    }
                    if (j == 0)         //slucaj kada je okvir za prefiks duzine i prazna rec

                    {
                        backward_transition_states.Add(0);
                        break;
                    }
                    j = backward_transition_states[j];              //ukoliko okvir prefiksa duzine i nije veci od okvira za prefiksa duzine i-1
                                                                //i dalje postoji mogucnost da postoji okvir za prefiks duzine i koji je manji od okvira prefiksa duzine i-1
                                                //duzina sledeceg po velicini okvira prefiksa duzine i-1 nalazi se na poziciji backward_transition_states[j]
                                                    //u narednoj iteraciji se za taj okvir pkusava sa prosirenjem kako bi odgovarao okviru prefiksa duzine i
                }
            }
        }

        public List<int> Search(String pattern, String text)
        {
            if (text.Length < pattern.Length || pattern.Length == 0)
                return start_indexex;

            InitializeBackwardStates(pattern);

            int i = 0;      //pozicija narednog slova iz teksta za citanje
            int j = 0;      //stanje simuliranog automata
            while (i < text.Length)
            {
                if (text[i] == pattern[j])      //foreward transition function
                {
                    i++;
                    j++;
                    if (j == pattern.Length)     //prepoznat pattern
                    {
                        j = backward_transition_states[j];      //vracamo automat unazad tako da odgovara prepoznatom prefiksu koji je najveci okvir patterna //backward transition function
                        start_indexex.Add(i - pattern.Length);      //pozicija u okviru teksta gde smo nasli pattern
                    }
                }
                else
                    if (j > 0)          
                        j = backward_transition_states[j];          //backward transition function
                    else
                        i++;                    //backward transition function nije moguca, nije prepoznat ni jedan prefiks, prelazak na naredni deo teksta
            }
            return start_indexex;
        }


        public void ClearIndexes()
        {
            start_indexex.Clear();
            backward_transition_states.Clear();
        }
    }
}

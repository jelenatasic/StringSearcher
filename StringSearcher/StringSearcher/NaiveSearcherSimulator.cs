using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class NaiveSearcherSimulator : Simulator
    {
        int text_position, match_counter;


        public NaiveSearcherSimulator(RichTextBox pattern_textbox, RichTextBox text_textbox)
        {
            this.pattern_textbox = pattern_textbox;
            this.text_textbox = text_textbox;
            text_position = match_counter = 0;
        }

        public override void NextStep()
        {
            //ukloniti pozadinu slova iz predhodnog koraka
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, 0, text.Length);

            if (text_position <= text.Length - pattern.Length)
            {
                if (match_counter == pattern.Length)
                {
                    //pronasli smo pojavu sablona u okviru teksta, obojicemo taj tekst u crveno
                    SetFrontColor(text_textbox, Color.Red, text_position, pattern.Length);
                    match_counter = 0;
                    text_position++;
                    return;
                }

                if (pattern[match_counter] == text[text_position + match_counter])
                {
                    //slovo na odgovarajucoj poziciji u sablonu i tekstu su ista
                    //uvecavamo brojac koji cuva broj pronadjenih istih slova dela sablona i teksta
                    //za segmente sablona i teksta za koje znamo da su identicni bojimo njihovu pozadinu 
                    match_counter++;
                    SetBackColor(pattern_textbox, Color.Tan, 0, match_counter);
                    SetBackColor(text_textbox, Color.Tan, text_position, match_counter);
                }
                else
                {
                    //naisli smo na razliku izmedju dela teksta i sablona
                    //bojimo posmatrane segmente zajedno sa slovima koja su razlicita
                    SetBackColor(pattern_textbox, Color.Tan, 0, match_counter + 1);
                    SetBackColor(text_textbox, Color.Tan, text_position, match_counter + 1);
                    //postavljamo vrednosti za naredni korak
                    match_counter = 0;
                    text_position++;
                }
            }
        }

        public override void Reset()
        {
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, 0, text.Length);
            SetFrontColor(text_textbox, Color.Black, 0, text.Length);

            text_position = match_counter = 0;
            text = "";
            pattern = "";
        }

        public override void Prepare()
        {
            return;  //Naivni algoritam ne zahteva pripremu;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class RabinKarpSearcherSimulator : Simulator
    {
        //textBox-ovi koji prikazuju matematicki izraz za racunanje hesa
        private RichTextBox pattern_hash_expression_textbox;
        private RichTextBox text_hash_expression_textbox;

        //textBox-ovi koji prikazuju vradnost hesa sablona i dela teksta
        private TextBox pattern_hash_textbox;
        private TextBox text_hash_textbox;

        const int B = 257, M = 997;

        int text_counter;
        int match_counter;

        private int pattern_hash;
        private int text_hash;

        //string koji cuva matematicki izraz kako smo izracunali hes
        private string hash_text;

        public RabinKarpSearcherSimulator(RichTextBox pattern_textbox, 
                                             RichTextBox text_textbox, 
                                             RichTextBox pattern_hash_expression_textbox,
                                             RichTextBox text_hash_expression_textbox, 
                                             TextBox pattern_hash_textbox, 
                                             TextBox text_hash_textbox,
                                             Label message_label)
        {
            this.pattern_textbox = pattern_textbox;
            this.pattern_hash_textbox = pattern_hash_textbox;
            this.pattern_hash_expression_textbox = pattern_hash_expression_textbox;

            this.text_textbox = text_textbox;
            this.text_hash_textbox = text_hash_textbox;
            this.text_hash_expression_textbox = text_hash_expression_textbox;

            this.message_label = message_label;
        }

        /// <summary>
        /// generisanje kotrljajuceg hesa za dati string
        /// generisanje stringa koji predstavlja matematicki izraz kako se generise hes za dati string
        /// </summary>
        private int CalculateHashSimulation(String s)
        {
            int b_to_power_m = 1;
            int hash = s[s.Length - 1];

            hash_text = s[s.Length - 1].ToString() + " * B^0 % M";

            for (int i = 1; i < s.Length; i++)
            {
                b_to_power_m = (b_to_power_m * B) % M;
                int part_of_sum = (s[s.Length - i - 1] * b_to_power_m) % M;
                hash = (hash + part_of_sum) % M;

                hash_text = s[s.Length - i - 1].ToString() + " * B^" + i.ToString() + " % M + " + hash_text;
            }
            return hash;
        }

        /// <summary>
        /// proprema se odnosi na racunanje hesa sablonan i hesa prvih pattern.Length slova teksta
        /// obelezavanje pattern.Length slova teksta i sablona
        /// </summary>
        public override void Prepare()
        {
            pattern_hash = CalculateHashSimulation(pattern);
            pattern_hash_textbox.Text = pattern_hash.ToString();
            SetText(pattern_hash_expression_textbox, hash_text);
            SetBackColor(pattern_textbox, Color.Tan, 0, pattern.Length);

            text_hash = CalculateHashSimulation(text.Substring(0, pattern.Length));
            text_hash_textbox.Text = text_hash.ToString();
            SetText(text_hash_expression_textbox, hash_text);
            SetBackColor(text_textbox, Color.Tan, text_counter, pattern.Length);

            SetMessage();
            
            text_counter = 0;
        }

        public override void NextStep()
        {
            //uslov za kraj pretrage
            if (text_counter > text.Length - pattern.Length)
                return;

            //uklanjanje obojene pozadine iz prethodne iteracije
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, text_counter, pattern.Length);

            if (pattern_hash != text_hash)
            {
                PatternMissmatch();
                SetMessage();
            }
            else
            {
                //ako je hes sablona i hes dela teksta isti, proveravamo slovo po slovo da li su identicni
                if (match_counter < pattern.Length)
                {
                    if (pattern[match_counter] == text[text_counter + match_counter])
                    {
                        //slovo sablona i dela teksta su identicna
                        //uvecavamo brojac izbrojanih istih slova
                        match_counter++;
                        //obelezavamo deo sablona i deo teksta za koje smo utvrdili da su isti
                        SetBackColor(pattern_textbox, Color.Tan, 0, match_counter);
                        SetBackColor(text_textbox, Color.Tan, text_counter, match_counter);
                        message_label.Text = "Pattern letter same as text letter!";
                    }
                    else
                    {
                        //deo teksta koji ima isti hes kao sablon, nije identican sablonu
                        match_counter = 0;
                        PatternMissmatch();
                        message_label.Text = "Letter missmatch.";
                        AddMessage();
                    }
                }
                else
                {
                    //detektovali smo pojavu sablona u ovkiru teksta, i taj deo teksta oznacavamo crvenim slovima
                    SetFrontColor(text_textbox, Color.Red, text_counter, pattern.Length);
                    //resetujemo brojac i prelazimo na ispitivanje preostalog teksta
                    match_counter = 0;
                    PatternMissmatch();
                    message_label.Text = "Match found!!!";
                    AddMessage();
                }
            }                                                            
        }

        private void PatternMissmatch()
        {
            text_counter++;
            if (text_counter <= text.Length - pattern.Length)
            {
                text_hash = CalculateHashSimulation(text.Substring(text_counter, pattern.Length));
                //postavljanje matematickog izraza za novoizracunati hes teksta i njegove vrednosti
                SetText(text_hash_expression_textbox, hash_text);
                text_hash_textbox.Text = text_hash.ToString();

                //obelezavanje patterna i dela teksta koji se posmatra
                SetBackColor(pattern_textbox, Color.Tan, 0, pattern.Length);
                SetBackColor(text_textbox, Color.Tan, text_counter, pattern.Length);
            }
        }

        private void SetMessage()
        {
                if (text_hash != pattern_hash)
                    message_label.Text = "Missmatch. Pattern hash and text hash are different.";
                else
                    message_label.Text = "Potential match!";
        }

        private void AddMessage()
        {
            if (text_hash != pattern_hash)
                message_label.Text += "\nMissmatch. Pattern hash and text hash are different.";
            else
                message_label.Text += "\nPotential match!";
        }

        public override void Reset()
        {
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, 0, text.Length);
            SetFrontColor(text_textbox, Color.Black, 0, text.Length);
            

            pattern_hash_expression_textbox.Text = "";
            text_hash_expression_textbox.Text = "";
            pattern_hash_textbox.Text = "";
            text_hash_textbox.Text = "";
            text = "";
            pattern = "";
            text_counter = match_counter = 0;
            hash_text = "";
            message_label.Text = "";
        }
    }
}
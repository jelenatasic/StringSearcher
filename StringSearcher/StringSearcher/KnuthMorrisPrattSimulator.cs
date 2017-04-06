using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    class KnuthMorrisPrattSimulator : Simulator
    {
        ListBox listbox_states;
        List<int> backward_transition_states;

        private bool generated_states;
        int generatetd_states_count;
        int current_state;
        int text_counter;

        public KnuthMorrisPrattSimulator(RichTextBox pattern_textbox, RichTextBox text_textbox, ListBox listbox_states, Label message_label)
        {
            this.pattern_textbox = pattern_textbox;
            this.text_textbox = text_textbox;
            this.listbox_states = listbox_states;
            this.message_label = message_label;

            backward_transition_states = new List<int>();
            generated_states = false;
            generatetd_states_count = 0;
            text_counter = current_state = 0;
        }

        public override void Reset()
        {
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, 0, text.Length);
            SetFrontColor(text_textbox, Color.Black, 0, text.Length);
            listbox_states.Items.Clear();
            backward_transition_states.Clear();
            text = pattern = "";
            text_counter = current_state = generatetd_states_count = 0;
            generated_states = false;
            message_label.Text = "";
        }
        public override void Prepare()
        {
            backward_transition_states.Add(0);
            backward_transition_states.Add(0);
            listbox_states.Items.Add("Current state: 0, next state: 0");
            listbox_states.Items.Add("Current state: 1, next state: 0");
            generatetd_states_count = 2;
            current_state = 0;
            message_label.Text = "Backward transition state generation.";
        }

        public override void NextStep()
        {
            SetBackColor(pattern_textbox, Color.White, 0, pattern.Length);
            SetBackColor(text_textbox, Color.White, 0, text.Length);

            if (!generated_states)
            {
                //simulacija generisanja BTF(backward_transition_function) stanja
                GenerateBackwardTransitionState();
                if (generatetd_states_count == pattern.Length + 1)
                    generated_states = true;
                message_label.Text = "Backward transition state generation.";
                return;
            }
            //nakon generisanja stanja sledi trazenje pattern-a u text-u
            else
            {
                if (text_counter < text.Length)
                {
                    if (current_state == pattern.Length)     
                    {
                        //prepoznat pattern u prethodnom koraku i vec je obojen u crveno
                        //sada odrediti novo stanje automata
                        message_label.Text = "Final state, Backward transition performed!";
                        current_state = backward_transition_states[current_state];
                        SelectState(current_state);
                        //obojiti prepoznati prefiks
                        if(current_state != 0)
                            SelectPartsOfPatternAndText(0, text_counter - current_state, current_state);
                        return;
                    }
                    if (text[text_counter] == pattern[current_state])      
                    {
                        //foreward transition function
                        message_label.Text = "Same letters! Forward transition.";
                        text_counter++;
                        current_state++;
                        //obelezavamo prepoznat prefiks
                        SelectPartsOfPatternAndText(0, text_counter - current_state, current_state);
                        SelectState(current_state);
                        if (current_state == pattern.Length)
                        {
                            //prepoznat pattern - obojiti slova dela teksta crveno
                            message_label.Text = "\nMatch Found!!!";
                            SetFrontColor(text_textbox, Color.Red, text_counter - pattern.Length, pattern.Length);
                        }
                        return;
                    }
                    if (current_state > 0)
                    {
                        //karakter pattern-a i text-a se razlikuju - backward transition function
                        current_state = backward_transition_states[current_state];
                        message_label.Text = "Trying to expand found prefix!";
                    }
                    SelectPartsOfPatternAndText(0, text_counter - current_state, current_state);
                    SelectState(current_state);
                    if (current_state == 0)
                    {
                        message_label.Text = "Letter missmatch!! State 0, read next text letter.";
                        text_counter++;
                    }
                }
            }
        }

        void SelectState(int current_state)
        {
            listbox_states.SetSelected(current_state, true);
        }

        void SelectPartsOfPatternAndText(int pattern_start_inedx, int text_start_index, int length)
        {
            if (length != 0)
            {
                SetBackColor(pattern_textbox, Color.Tan, pattern_start_inedx, length);
                SetBackColor(text_textbox, Color.Tan, text_start_index, length);
            }
            else
            {
                SetBackColor(pattern_textbox, Color.Tan, pattern_start_inedx, 1);
                SetBackColor(text_textbox, Color.Tan, text_start_index, 1);
            }
        }

        private void GenerateBackwardTransitionState()
        {
            //najveci okvir prethodno obradjenog prefiksa
            int current_best_border = backward_transition_states[generatetd_states_count - 1];

            while (true)    //odredjivanje duzine okvira za prefiks duzine generatetd_states_count
            {
                if (pattern[generatetd_states_count - 1] == pattern[current_best_border])
                {
                    current_best_border++;
                    backward_transition_states.Add(current_best_border);
                    break;
                }
                if (current_best_border == 0)
                {
                    backward_transition_states.Add(0);
                    break;
                }
                current_best_border = backward_transition_states[current_best_border];
            }

            //svetlo rozom pozadinom oznacavamo prefiks
            SetBackColor(pattern_textbox, Color.MistyRose, 0, generatetd_states_count);
            //ljubicastom bojom oznacavamo najveci okvir ovog prefiksa
            SetBackColor(pattern_textbox, Color.Plum, 0, backward_transition_states[generatetd_states_count]);
            SetBackColor(pattern_textbox, Color.Plum, generatetd_states_count - backward_transition_states[generatetd_states_count], backward_transition_states[generatetd_states_count]);

            listbox_states.Items.Add("Current state: "+ generatetd_states_count.ToString() +", next state: "+ backward_transition_states[generatetd_states_count].ToString());
            generatetd_states_count++;
        }
    }
}

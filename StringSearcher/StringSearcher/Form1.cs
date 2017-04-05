using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSearcher
{
    public partial class MainForm : Form
    {
        Searcher searcher;
        NaiveSearcher naive_searcher;
        RabinKarpSearcher rabin_karp_searcher;
        KnuthMorrisPrattSearcher knuth_morris_pratt_searcher;

        Simulator simulator;
        NaiveSearcherSimulator naive_simulator;
        RabinKarpSearcherSimulator rabin_karp_simulator;

        List<int> start_indexes;

        public MainForm()
        {
            //komponente
            InitializeComponent();
            button_SimulationStart.Visible = false;
            button_SimulationNextStep.Visible = false;
            button_SimulationRestart.Visible = false;

            //saercher-i
            naive_searcher = new NaiveSearcher();
            rabin_karp_searcher = new RabinKarpSearcher();
            knuth_morris_pratt_searcher = new KnuthMorrisPrattSearcher();

            //simulatori
            naive_simulator = new NaiveSearcherSimulator(textBox_Pattern, richTextBox_Text);
            rabin_karp_simulator = new RabinKarpSearcherSimulator(textBox_Pattern, richTextBox_Text, richTextBox_PatternHash, richTextBox_TextHash, textBox_PatternHash, textBox_TextHash);

            start_indexes = new List<int>();
        }

        private void SelectSeracher(bool naive, bool rabin_karp, bool knuth_morris_pratt)
        {
            if (naive)
                searcher = (Searcher)naive_searcher;
            else
                if (rabin_karp)
                    searcher = (Searcher)rabin_karp_searcher;
                else
                    searcher = (Searcher)knuth_morris_pratt_searcher;
        }

        private void SelectSimulator(bool naive, bool rabin_karp, bool knuth_morris_pratt)
        {
            if (naive)
                simulator = (Simulator) naive_simulator;
            else
                if (rabin_karp)
                    simulator = (Simulator)rabin_karp_simulator;
               //else
                    //simulator = (Simulator)knuth_morris_pratt_simulator;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SelectSeracher(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);

            start_indexes = searcher.Search(textBox_Pattern.Text, richTextBox_Text.Text);
            richTextBox_Text.Select(0, richTextBox_Text.Text.Length);
            richTextBox_Text.SelectionColor = Color.Black;
            richTextBox_Text.Select(0, 0);

            foreach (int index in start_indexes)
            {
                richTextBox_Text.Select(index, textBox_Pattern.Text.Length);
                richTextBox_Text.SelectionColor = Color.Red;
                richTextBox_Text.Select(0, 0);
            }

            string plural_or_not;
            if (start_indexes.Count == 1)
                plural_or_not = "";
            else
                plural_or_not = "es";
            label_Message.Text = "Found: " + start_indexes.Count.ToString() + " match"+plural_or_not;
            searcher.ClearIndexes();
            start_indexes.Clear();
        }

        /// <summary>
        ///     Otvara se file dialog u kome moze da se selektuje tekstualni dokument
        ///     tekstualni dokument se ucitava i sluzi kao tekst u kome se trazi pojavljivanje pattern-a
        /// </summary>
        private void button_LoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Filter = "text files| *.txt";

            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox_Text.Text = System.IO.File.ReadAllText(file_dialog.FileName);
            }

            richTextBox_Text.Select(0, richTextBox_Text.Text.Length);
            richTextBox_Text.SelectionColor = Color.Black;
        }

        private void button_SimulationStart_Click(object sender, EventArgs e)
        {
            if (textBox_Pattern.Text.Length > richTextBox_Text.Text.Length)
            {
                MessageBox.Show("Pattern must be shorter than text!!","Error");
                return;
            }

            textBox_Pattern.ReadOnly = true;
            richTextBox_Text.ReadOnly = true;
            simulator.SetPatternAndText();
            simulator.Prepare();

            button_SimulationStart.Visible = false;
            button_SimulationNextStep.Visible = true;
            button_SimulationRestart.Visible = true;

        }

        private void button_SimulationNextStep_Click(object sender, EventArgs e)
        {
            simulator.NextStep();
        }

        private void checkBox_Simulation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Simulation.Checked)
            {
                SelectSimulator(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);
                button_Search.Visible = false;
                button_SimulationStart.Visible = true;
                label_Message.Text = "Please enter pattern and text before starting the simulation";
            }
            else
            {
                button_Search.Visible = true;
                button_SimulationStart.Visible = false;
                label_Message.Visible = true;
                label_Message.Text = "";
            }
        }

        private void button_SimulationRestart_Click(object sender, EventArgs e)
        {
            button_SimulationStart.Visible = true;
            label_Message.Text = "Please enter pattern and text before starting the simulation";
            button_SimulationNextStep.Visible = false;
            button_SimulationRestart.Visible = false;

            textBox_Pattern.ReadOnly = false;
            richTextBox_Text.ReadOnly = false;

            simulator.Reset();
        }


        //u slucaju da se prilikom eventa pozivaju dva puta selekcija sim
        //mozda ipak samo ClickEvent

        private void radioButton_Naive_Search_CheckedChanged(object sender, EventArgs e)
        {
            SelectSimulator(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);
        }

        private void radioButton_Rabin_Karp_Search_CheckedChanged(object sender, EventArgs e)
        {
            SelectSimulator(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);
        }

        private void radioButton_Knuth_Morris_Pratt_Search_CheckedChanged(object sender, EventArgs e)
        {
            SelectSimulator(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);
        }
    }
}

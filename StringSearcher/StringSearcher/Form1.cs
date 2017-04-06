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
        NaiveSimulator naive_simulator;
        RabinKarpSearcherSimulator rabin_karp_simulator;
        KnuthMorrisPrattSimulator knuth_morris_pratt_simulator;

        List<int> start_indexes;

        public MainForm()
        {
            //komponente
            InitializeComponent();
            
            button_SimulationStart.Visible = false;
            button_SimulationNextStep.Visible = false;
            button_SimulationRestart.Visible = false;

            panel_RobinKarpSimulation.Visible = false;
            panel_KnuthMorrisPrattSimulation.Visible = false;
            

            //saercher-i
            naive_searcher = new NaiveSearcher();
            rabin_karp_searcher = new RabinKarpSearcher();
            knuth_morris_pratt_searcher = new KnuthMorrisPrattSearcher();

            //simulatori
            naive_simulator = new NaiveSimulator(textBox_Pattern, textBox_Text, label_RobinKarpSimulatoMessage);
            rabin_karp_simulator = new RabinKarpSearcherSimulator(textBox_Pattern, textBox_Text, richTextBox_PatternHash, richTextBox_TextHash, textBox_PatternHash, textBox_TextHash, label_RobinKarpSimulatoMessage);
            knuth_morris_pratt_simulator = new KnuthMorrisPrattSimulator(textBox_Pattern, textBox_Text, listBox_KMPStates, label_RobinKarpSimulatoMessage);

            //default-ni searcher i simulator;
            searcher = naive_searcher;
            simulator = naive_simulator;

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
               else
                    simulator = (Simulator)knuth_morris_pratt_simulator;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            if (textBox_Pattern.Text.Length > textBox_Text.Text.Length)
            {
                MessageBox.Show("Pattern must be shorter than text!!", "Error");
                return;
            }
            if (textBox_Pattern.Text.Length == 0 || textBox_Text.Text.Length == 0)
            {
                MessageBox.Show("Please enter pattern and text!!", "Error");
                return;
            }

            SelectSeracher(radioButton_Naive_Search.Checked, radioButton_Rabin_Karp_Search.Checked, radioButton_Knuth_Morris_Pratt_Search.Checked);

            start_indexes = searcher.Search(textBox_Pattern.Text, textBox_Text.Text);
            textBox_Text.Select(0, textBox_Text.Text.Length);
            textBox_Text.SelectionColor = Color.Black;

            foreach (int index in start_indexes)
            {
                textBox_Text.Select(index, textBox_Pattern.Text.Length);
                textBox_Text.SelectionColor = Color.Red;
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
                textBox_Text.Text = System.IO.File.ReadAllText(file_dialog.FileName);
            }

            textBox_Text.Select(0, textBox_Text.Text.Length);
            textBox_Text.SelectionColor = Color.Black;
        }


        private void button_SimulationStart_Click(object sender, EventArgs e)
        {
            if (textBox_Pattern.Text.Length > textBox_Text.Text.Length)
            {
                MessageBox.Show("Pattern must be shorter than text!!","Error");
                return;
            }
            if (textBox_Pattern.Text.Length == 0 || textBox_Text.Text.Length==0)
            {
                MessageBox.Show("Please enter pattern and text!!", "Error");
                return;
            }

            groupBox_AlgorithmSelection.Enabled = false;

            checkBox_Simulation.Enabled = false;

            button_SimulationStart.Visible = false;
            button_SimulationNextStep.Visible = true;
            button_SimulationRestart.Visible = true;

            button_SetBlackText.Visible = false;

            textBox_Pattern.ReadOnly = true;
            textBox_Text.ReadOnly = true;

            label_Message.Text = "Simulation running. To exit simulation mode, press Restart.";

            simulator.SetPatternAndText();
            simulator.Prepare();
        }

        private void button_SimulationRestart_Click(object sender, EventArgs e)
        {
            groupBox_AlgorithmSelection.Enabled = true;

            checkBox_Simulation.Enabled = true;

            button_SimulationStart.Visible = true;
            button_SimulationNextStep.Visible = false;
            button_SimulationRestart.Visible = false;

            button_SetBlackText.Visible = true;

            textBox_Pattern.ReadOnly = false;
            textBox_Text.ReadOnly = false;

            label_Message.Text = "Simulation terminated.";
            
            simulator.Reset();
        }

        private void button_SimulationNextStep_Click(object sender, EventArgs e)
        {
            simulator.NextStep();
        }

        private void checkBox_Simulation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Simulation.Checked)
            {
                textBox_Text.Select(0, textBox_Text.Text.Length);
                textBox_Text.SelectionColor = Color.Black;
                if (radioButton_Naive_Search.Checked)
                {
                    panel_KnuthMorrisPrattSimulation.Visible = false;
                    panel_RobinKarpSimulation.Visible = false;
                }
                else
                    if (radioButton_Rabin_Karp_Search.Checked)
                    {
                        panel_KnuthMorrisPrattSimulation.Visible = false;
                        panel_RobinKarpSimulation.Visible = true;
                    }
                    else
                    {
                        panel_KnuthMorrisPrattSimulation.Visible = true;
                        panel_RobinKarpSimulation.Visible = false;
                    }

                button_Search.Visible = false;
                button_SimulationStart.Visible = true;
                label_Message.Text = "Please enter pattern and text before starting the simulation. To start simulation press Start button.";
            }
            else
            {
                groupBox_AlgorithmSelection.Enabled = true;
                panel_KnuthMorrisPrattSimulation.Visible = false;
                panel_RobinKarpSimulation.Visible = false;

                button_Search.Visible = true;
                button_SimulationStart.Visible = false;

                label_Message.Text = "";
            }
        }


        private void radioButton_Naive_Search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Naive_Search.Checked)
            {
                SelectSimulator(true, false, false);
                if (checkBox_Simulation.Checked)
                {
                    panel_RobinKarpSimulation.Visible = false;
                    panel_KnuthMorrisPrattSimulation.Visible = false;
                }
            }
        }

        private void radioButton_Rabin_Karp_Search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Rabin_Karp_Search.Checked)
            {
                SelectSimulator(false, true, false);
                if (checkBox_Simulation.Checked)
                {
                    panel_KnuthMorrisPrattSimulation.Visible = false;
                    panel_RobinKarpSimulation.Visible = true;
                }
            }
        }

        private void radioButton_Knuth_Morris_Pratt_Search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Knuth_Morris_Pratt_Search.Checked)
            {
                SelectSimulator(false, false, true);
                if (checkBox_Simulation.Checked)
                {
                    panel_KnuthMorrisPrattSimulation.Visible = true;
                    panel_RobinKarpSimulation.Visible = false;
                }
            }
        }

        private void button_SetBlackText_Click(object sender, EventArgs e)
        {
            textBox_Text.Select(0, textBox_Text.Text.Length);
            textBox_Text.SelectionColor = Color.Black;
        }
    }
}

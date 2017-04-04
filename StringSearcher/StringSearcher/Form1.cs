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
        NaiveSearcher naive_searcher;
        RabinKarpSearcher rabin_karp_searcher;
        KnuthMorrisPrattSearcher knuth_morris_pratt_searcher;
        List<int> start_indexes;

        public MainForm()
        {
            InitializeComponent();
            naive_searcher = new NaiveSearcher();
            rabin_karp_searcher = new RabinKarpSearcher();
            knuth_morris_pratt_searcher = new KnuthMorrisPrattSearcher();
            start_indexes = new List<int>();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            //start_indexes = naive_searcher.Search(textBox_Pattern.Text, richTextBox_Text.Text);

           // start_indexes = rabin_karp_searcher.Search(textBox_Pattern.Text, richTextBox_Text.Text);

            start_indexes = knuth_morris_pratt_searcher.Search(textBox_Pattern.Text, richTextBox_Text.Text);

            richTextBox_Text.Select(0, richTextBox_Text.Text.Length);
            richTextBox_Text.SelectionColor = Color.Black;
            richTextBox_Text.Select(0, 0);

            foreach (int index in start_indexes)
            {
                richTextBox_Text.Select(index, textBox_Pattern.Text.Length);
                richTextBox_Text.SelectionColor = Color.Red;
                richTextBox_Text.Select(0, 0);
            }

            naive_searcher.ClearIndexes();
            start_indexes.Clear();
        }

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
    }
}

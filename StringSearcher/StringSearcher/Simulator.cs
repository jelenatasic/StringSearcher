using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearcher
{
    abstract class Simulator
    {
        protected RichTextBox pattern_textbox;
        protected RichTextBox text_textbox;
        protected String text;
        protected String pattern;

        protected void SetBackColor(RichTextBox textBox, Color color, int start_index, int end_index)
        {
            textBox.Select(start_index, end_index);
            textBox.SelectionBackColor = color;
        }

        protected void SetFrontColor(RichTextBox textBox, Color color, int start_index, int end_index)
        {
            textBox.Select(start_index, end_index);
            textBox.SelectionColor = color;
        }

        protected void SetText(RichTextBox textBox, String text)
        {
            textBox.Text = text;
        }

        public void SetPatternAndText()
        {
            text = text_textbox.Text;
            pattern = pattern_textbox.Text;
        }

        public abstract void Reset();
        public abstract void Prepare();
        public abstract void NextStep();
    }
}

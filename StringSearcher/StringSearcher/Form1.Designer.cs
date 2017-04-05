namespace StringSearcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Knuth_Morris_Pratt_Search = new System.Windows.Forms.RadioButton();
            this.radioButton_Rabin_Karp_Search = new System.Windows.Forms.RadioButton();
            this.radioButton_Naive_Search = new System.Windows.Forms.RadioButton();
            this.button_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_Text = new System.Windows.Forms.RichTextBox();
            this.button_LoadText = new System.Windows.Forms.Button();
            this.checkBox_Simulation = new System.Windows.Forms.CheckBox();
            this.button_SimulationStart = new System.Windows.Forms.Button();
            this.button_SimulationNextStep = new System.Windows.Forms.Button();
            this.button_SimulationRestart = new System.Windows.Forms.Button();
            this.textBox_Pattern = new System.Windows.Forms.RichTextBox();
            this.label_Message = new System.Windows.Forms.Label();
            this.panel_RobinKarpSimulation = new System.Windows.Forms.Panel();
            this.richTextBox_TextHash = new System.Windows.Forms.RichTextBox();
            this.richTextBox_PatternHash = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PatternHash = new System.Windows.Forms.TextBox();
            this.textBox_TextHash = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel_RobinKarpSimulation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pattern:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Knuth_Morris_Pratt_Search);
            this.groupBox1.Controls.Add(this.radioButton_Rabin_Karp_Search);
            this.groupBox1.Controls.Add(this.radioButton_Naive_Search);
            this.groupBox1.Location = new System.Drawing.Point(18, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm";
            // 
            // radioButton_Knuth_Morris_Pratt_Search
            // 
            this.radioButton_Knuth_Morris_Pratt_Search.AutoSize = true;
            this.radioButton_Knuth_Morris_Pratt_Search.Location = new System.Drawing.Point(6, 75);
            this.radioButton_Knuth_Morris_Pratt_Search.Name = "radioButton_Knuth_Morris_Pratt_Search";
            this.radioButton_Knuth_Morris_Pratt_Search.Size = new System.Drawing.Size(145, 21);
            this.radioButton_Knuth_Morris_Pratt_Search.TabIndex = 6;
            this.radioButton_Knuth_Morris_Pratt_Search.Text = "Knuth-Morris-Pratt";
            this.radioButton_Knuth_Morris_Pratt_Search.UseVisualStyleBackColor = true;
            this.radioButton_Knuth_Morris_Pratt_Search.CheckedChanged += new System.EventHandler(this.radioButton_Knuth_Morris_Pratt_Search_CheckedChanged);
            // 
            // radioButton_Rabin_Karp_Search
            // 
            this.radioButton_Rabin_Karp_Search.AutoSize = true;
            this.radioButton_Rabin_Karp_Search.Location = new System.Drawing.Point(6, 48);
            this.radioButton_Rabin_Karp_Search.Name = "radioButton_Rabin_Karp_Search";
            this.radioButton_Rabin_Karp_Search.Size = new System.Drawing.Size(101, 21);
            this.radioButton_Rabin_Karp_Search.TabIndex = 5;
            this.radioButton_Rabin_Karp_Search.Text = "Rabin-Karp";
            this.radioButton_Rabin_Karp_Search.UseVisualStyleBackColor = true;
            this.radioButton_Rabin_Karp_Search.CheckedChanged += new System.EventHandler(this.radioButton_Rabin_Karp_Search_CheckedChanged);
            // 
            // radioButton_Naive_Search
            // 
            this.radioButton_Naive_Search.AutoSize = true;
            this.radioButton_Naive_Search.Checked = true;
            this.radioButton_Naive_Search.Location = new System.Drawing.Point(6, 21);
            this.radioButton_Naive_Search.Name = "radioButton_Naive_Search";
            this.radioButton_Naive_Search.Size = new System.Drawing.Size(65, 21);
            this.radioButton_Naive_Search.TabIndex = 4;
            this.radioButton_Naive_Search.TabStop = true;
            this.radioButton_Naive_Search.Text = "Naive";
            this.radioButton_Naive_Search.UseVisualStyleBackColor = true;
            this.radioButton_Naive_Search.CheckedChanged += new System.EventHandler(this.radioButton_Naive_Search_CheckedChanged);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(137, 198);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(121, 27);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text:";
            // 
            // richTextBox_Text
            // 
            this.richTextBox_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox_Text.Location = new System.Drawing.Point(12, 304);
            this.richTextBox_Text.Name = "richTextBox_Text";
            this.richTextBox_Text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Text.Size = new System.Drawing.Size(1038, 454);
            this.richTextBox_Text.TabIndex = 2;
            this.richTextBox_Text.Text = "";
            // 
            // button_LoadText
            // 
            this.button_LoadText.Location = new System.Drawing.Point(929, 764);
            this.button_LoadText.Name = "button_LoadText";
            this.button_LoadText.Size = new System.Drawing.Size(121, 27);
            this.button_LoadText.TabIndex = 6;
            this.button_LoadText.Text = "Load Text";
            this.button_LoadText.UseVisualStyleBackColor = true;
            this.button_LoadText.Click += new System.EventHandler(this.button_LoadText_Click);
            // 
            // checkBox_Simulation
            // 
            this.checkBox_Simulation.AutoSize = true;
            this.checkBox_Simulation.Location = new System.Drawing.Point(320, 25);
            this.checkBox_Simulation.Name = "checkBox_Simulation";
            this.checkBox_Simulation.Size = new System.Drawing.Size(95, 21);
            this.checkBox_Simulation.TabIndex = 7;
            this.checkBox_Simulation.Text = "Simulation";
            this.checkBox_Simulation.UseVisualStyleBackColor = true;
            this.checkBox_Simulation.CheckedChanged += new System.EventHandler(this.checkBox_Simulation_CheckedChanged);
            // 
            // button_SimulationStart
            // 
            this.button_SimulationStart.Location = new System.Drawing.Point(314, 52);
            this.button_SimulationStart.Name = "button_SimulationStart";
            this.button_SimulationStart.Size = new System.Drawing.Size(135, 23);
            this.button_SimulationStart.TabIndex = 8;
            this.button_SimulationStart.Text = "Start";
            this.button_SimulationStart.UseVisualStyleBackColor = true;
            this.button_SimulationStart.Click += new System.EventHandler(this.button_SimulationStart_Click);
            // 
            // button_SimulationNextStep
            // 
            this.button_SimulationNextStep.Location = new System.Drawing.Point(498, 52);
            this.button_SimulationNextStep.Name = "button_SimulationNextStep";
            this.button_SimulationNextStep.Size = new System.Drawing.Size(135, 23);
            this.button_SimulationNextStep.TabIndex = 9;
            this.button_SimulationNextStep.Text = "Next Step";
            this.button_SimulationNextStep.UseVisualStyleBackColor = true;
            this.button_SimulationNextStep.Click += new System.EventHandler(this.button_SimulationNextStep_Click);
            // 
            // button_SimulationRestart
            // 
            this.button_SimulationRestart.Location = new System.Drawing.Point(696, 52);
            this.button_SimulationRestart.Name = "button_SimulationRestart";
            this.button_SimulationRestart.Size = new System.Drawing.Size(135, 23);
            this.button_SimulationRestart.TabIndex = 10;
            this.button_SimulationRestart.Text = "Restart";
            this.button_SimulationRestart.UseVisualStyleBackColor = true;
            this.button_SimulationRestart.Click += new System.EventHandler(this.button_SimulationRestart_Click);
            // 
            // textBox_Pattern
            // 
            this.textBox_Pattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Pattern.Location = new System.Drawing.Point(15, 164);
            this.textBox_Pattern.Multiline = false;
            this.textBox_Pattern.Name = "textBox_Pattern";
            this.textBox_Pattern.Size = new System.Drawing.Size(243, 28);
            this.textBox_Pattern.TabIndex = 1;
            this.textBox_Pattern.Text = "";
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(119, 251);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(0, 17);
            this.label_Message.TabIndex = 12;
            // 
            // panel_RobinKarpSimulation
            // 
            this.panel_RobinKarpSimulation.Controls.Add(this.textBox_TextHash);
            this.panel_RobinKarpSimulation.Controls.Add(this.textBox_PatternHash);
            this.panel_RobinKarpSimulation.Controls.Add(this.richTextBox_TextHash);
            this.panel_RobinKarpSimulation.Controls.Add(this.richTextBox_PatternHash);
            this.panel_RobinKarpSimulation.Controls.Add(this.label4);
            this.panel_RobinKarpSimulation.Controls.Add(this.label3);
            this.panel_RobinKarpSimulation.Location = new System.Drawing.Point(314, 93);
            this.panel_RobinKarpSimulation.Name = "panel_RobinKarpSimulation";
            this.panel_RobinKarpSimulation.Size = new System.Drawing.Size(736, 205);
            this.panel_RobinKarpSimulation.TabIndex = 15;
            // 
            // richTextBox_TextHash
            // 
            this.richTextBox_TextHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox_TextHash.Location = new System.Drawing.Point(6, 140);
            this.richTextBox_TextHash.Name = "richTextBox_TextHash";
            this.richTextBox_TextHash.Size = new System.Drawing.Size(727, 56);
            this.richTextBox_TextHash.TabIndex = 18;
            this.richTextBox_TextHash.Text = "";
            // 
            // richTextBox_PatternHash
            // 
            this.richTextBox_PatternHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox_PatternHash.Location = new System.Drawing.Point(3, 43);
            this.richTextBox_PatternHash.Name = "richTextBox_PatternHash";
            this.richTextBox_PatternHash.Size = new System.Drawing.Size(727, 56);
            this.richTextBox_PatternHash.TabIndex = 17;
            this.richTextBox_PatternHash.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "text substring hash:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "pattern hash:";
            // 
            // textBox_PatternHash
            // 
            this.textBox_PatternHash.Location = new System.Drawing.Point(184, 15);
            this.textBox_PatternHash.Name = "textBox_PatternHash";
            this.textBox_PatternHash.Size = new System.Drawing.Size(100, 22);
            this.textBox_PatternHash.TabIndex = 19;
            // 
            // textBox_TextHash
            // 
            this.textBox_TextHash.Location = new System.Drawing.Point(184, 112);
            this.textBox_TextHash.Name = "textBox_TextHash";
            this.textBox_TextHash.Size = new System.Drawing.Size(100, 22);
            this.textBox_TextHash.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 803);
            this.Controls.Add(this.panel_RobinKarpSimulation);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.textBox_Pattern);
            this.Controls.Add(this.button_SimulationRestart);
            this.Controls.Add(this.button_SimulationNextStep);
            this.Controls.Add(this.button_SimulationStart);
            this.Controls.Add(this.checkBox_Simulation);
            this.Controls.Add(this.button_LoadText);
            this.Controls.Add(this.richTextBox_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1080, 850);
            this.MinimumSize = new System.Drawing.Size(720, 850);
            this.Name = "MainForm";
            this.Text = "StringSearcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_RobinKarpSimulation.ResumeLayout(false);
            this.panel_RobinKarpSimulation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Knuth_Morris_Pratt_Search;
        private System.Windows.Forms.RadioButton radioButton_Rabin_Karp_Search;
        private System.Windows.Forms.RadioButton radioButton_Naive_Search;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_Text;
        private System.Windows.Forms.Button button_LoadText;
        private System.Windows.Forms.CheckBox checkBox_Simulation;
        private System.Windows.Forms.Button button_SimulationStart;
        private System.Windows.Forms.Button button_SimulationNextStep;
        private System.Windows.Forms.Button button_SimulationRestart;
        private System.Windows.Forms.RichTextBox textBox_Pattern;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Panel panel_RobinKarpSimulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_TextHash;
        private System.Windows.Forms.RichTextBox richTextBox_PatternHash;
        private System.Windows.Forms.TextBox textBox_TextHash;
        private System.Windows.Forms.TextBox textBox_PatternHash;
    }
}


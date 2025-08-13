namespace RaceTimingForm
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            updateTimer = new System.Windows.Forms.Timer(components);
            errorLabel = new Label();
            listBoxContextMenu = new ContextMenuStrip(components);
            removeTagToolStripMenuItem = new ToolStripMenuItem();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabRace = new TabPage();
            debugTextbox = new TextBox();
            addButton = new Button();
            timeInputTextBox = new TextBox();
            resultslistBox = new ListBox();
            resetButton = new Button();
            stopButton = new Button();
            startButton = new Button();
            tabConfigure = new TabPage();
            rawListBox = new ListBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            buttonWrite = new Button();
            textFirstNum = new TextBox();
            button1 = new Button();
            dataGridView = new DataGridView();
            colTag = new DataGridViewTextBoxColumn();
            colNumber = new DataGridViewTextBoxColumn();
            numericSensitivity = new NumericUpDown();
            numericPower = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            connectButton = new Button();
            listBoxContextMenu.SuspendLayout();
            tabControl1.SuspendLayout();
            tabRace.SuspendLayout();
            tabConfigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSensitivity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPower).BeginInit();
            SuspendLayout();
            // 
            // updateTimer
            // 
            updateTimer.Interval = 10;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // errorLabel
            // 
            errorLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(10, 296);
            errorLabel.Margin = new Padding(2, 0, 2, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(711, 41);
            errorLabel.TabIndex = 4;
            // 
            // listBoxContextMenu
            // 
            listBoxContextMenu.ImageScalingSize = new Size(24, 24);
            listBoxContextMenu.Items.AddRange(new ToolStripItem[] { removeTagToolStripMenuItem, clearAllToolStripMenuItem });
            listBoxContextMenu.Name = "listBoxContextMenu";
            listBoxContextMenu.Size = new Size(139, 48);
            // 
            // removeTagToolStripMenuItem
            // 
            removeTagToolStripMenuItem.Name = "removeTagToolStripMenuItem";
            removeTagToolStripMenuItem.Size = new Size(138, 22);
            removeTagToolStripMenuItem.Text = "Remove Tag";
            removeTagToolStripMenuItem.Click += removeTagToolStripMenuItem_Click;
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new Size(138, 22);
            clearAllToolStripMenuItem.Text = "Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabRace);
            tabControl1.Controls.Add(tabConfigure);
            tabControl1.Location = new Point(10, 7);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(709, 286);
            tabControl1.TabIndex = 14;
            // 
            // tabRace
            // 
            tabRace.Controls.Add(debugTextbox);
            tabRace.Controls.Add(addButton);
            tabRace.Controls.Add(timeInputTextBox);
            tabRace.Controls.Add(resultslistBox);
            tabRace.Controls.Add(resetButton);
            tabRace.Controls.Add(stopButton);
            tabRace.Controls.Add(startButton);
            tabRace.Location = new Point(4, 24);
            tabRace.Margin = new Padding(2);
            tabRace.Name = "tabRace";
            tabRace.Padding = new Padding(2);
            tabRace.Size = new Size(701, 258);
            tabRace.TabIndex = 0;
            tabRace.Text = "Race";
            tabRace.UseVisualStyleBackColor = true;
            // 
            // debugTextbox
            // 
            debugTextbox.Location = new Point(409, 205);
            debugTextbox.Margin = new Padding(2);
            debugTextbox.Name = "debugTextbox";
            debugTextbox.Size = new Size(238, 23);
            debugTextbox.TabIndex = 23;
            // 
            // addButton
            // 
            addButton.Location = new Point(363, 203);
            addButton.Margin = new Padding(2);
            addButton.Name = "addButton";
            addButton.Size = new Size(43, 20);
            addButton.TabIndex = 22;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // timeInputTextBox
            // 
            timeInputTextBox.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeInputTextBox.Location = new Point(104, 5);
            timeInputTextBox.Margin = new Padding(2);
            timeInputTextBox.Name = "timeInputTextBox";
            timeInputTextBox.Size = new Size(260, 45);
            timeInputTextBox.TabIndex = 16;
            timeInputTextBox.Text = "MM:SS";
            // 
            // resultslistBox
            // 
            resultslistBox.ContextMenuStrip = listBoxContextMenu;
            resultslistBox.FormattingEnabled = true;
            resultslistBox.ItemHeight = 15;
            resultslistBox.Location = new Point(410, 5);
            resultslistBox.Margin = new Padding(2);
            resultslistBox.Name = "resultslistBox";
            resultslistBox.SelectionMode = SelectionMode.MultiExtended;
            resultslistBox.Size = new Size(290, 184);
            resultslistBox.TabIndex = 15;
            // 
            // resetButton
            // 
            resetButton.Enabled = false;
            resetButton.Location = new Point(298, 61);
            resetButton.Margin = new Padding(2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(98, 55);
            resetButton.TabIndex = 14;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(195, 61);
            stopButton.Margin = new Padding(2);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(98, 55);
            stopButton.TabIndex = 13;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.Enabled = false;
            startButton.Location = new Point(92, 61);
            startButton.Margin = new Padding(2);
            startButton.Name = "startButton";
            startButton.Size = new Size(98, 55);
            startButton.TabIndex = 12;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // tabConfigure
            // 
            tabConfigure.Controls.Add(rawListBox);
            tabConfigure.Controls.Add(radioButton2);
            tabConfigure.Controls.Add(radioButton1);
            tabConfigure.Controls.Add(buttonWrite);
            tabConfigure.Controls.Add(textFirstNum);
            tabConfigure.Controls.Add(button1);
            tabConfigure.Controls.Add(dataGridView);
            tabConfigure.Controls.Add(numericSensitivity);
            tabConfigure.Controls.Add(numericPower);
            tabConfigure.Controls.Add(label2);
            tabConfigure.Controls.Add(label1);
            tabConfigure.Controls.Add(connectButton);
            tabConfigure.Location = new Point(4, 24);
            tabConfigure.Margin = new Padding(2);
            tabConfigure.Name = "tabConfigure";
            tabConfigure.Padding = new Padding(2);
            tabConfigure.Size = new Size(701, 258);
            tabConfigure.TabIndex = 1;
            tabConfigure.Text = "Configure";
            tabConfigure.UseVisualStyleBackColor = true;
            // 
            // rawListBox
            // 
            rawListBox.FormattingEnabled = true;
            rawListBox.ItemHeight = 15;
            rawListBox.Location = new Point(541, 7);
            rawListBox.Name = "rawListBox";
            rawListBox.Size = new Size(155, 184);
            rawListBox.TabIndex = 33;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(13, 72);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(96, 19);
            radioButton2.TabIndex = 32;
            radioButton2.Text = "Program Bibs";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(13, 47);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 19);
            radioButton1.TabIndex = 31;
            radioButton1.TabStop = true;
            radioButton1.Text = "Race";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonWrite
            // 
            buttonWrite.Location = new Point(584, 231);
            buttonWrite.Margin = new Padding(2);
            buttonWrite.Name = "buttonWrite";
            buttonWrite.Size = new Size(106, 20);
            buttonWrite.TabIndex = 30;
            buttonWrite.Text = "Write Numbers";
            buttonWrite.UseVisualStyleBackColor = true;
            buttonWrite.Click += buttonWrite_Click;
            // 
            // textFirstNum
            // 
            textFirstNum.Location = new Point(666, 195);
            textFirstNum.Margin = new Padding(2);
            textFirstNum.Name = "textFirstNum";
            textFirstNum.Size = new Size(44, 23);
            textFirstNum.TabIndex = 29;
            textFirstNum.Text = "1";
            // 
            // button1
            // 
            button1.Location = new Point(584, 194);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 20);
            button1.TabIndex = 28;
            button1.Text = "Fill From";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colTag, colNumber });
            dataGridView.Location = new Point(226, 4);
            dataGridView.Margin = new Padding(2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(310, 248);
            dataGridView.TabIndex = 27;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            // 
            // colTag
            // 
            colTag.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTag.HeaderText = "Tag";
            colTag.MinimumWidth = 8;
            colTag.Name = "colTag";
            colTag.ReadOnly = true;
            colTag.Width = 50;
            // 
            // colNumber
            // 
            colNumber.HeaderText = "Number";
            colNumber.MinimumWidth = 8;
            colNumber.Name = "colNumber";
            colNumber.Width = 150;
            // 
            // numericSensitivity
            // 
            numericSensitivity.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericSensitivity.Location = new Point(184, 20);
            numericSensitivity.Margin = new Padding(2);
            numericSensitivity.Maximum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numericSensitivity.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            numericSensitivity.Name = "numericSensitivity";
            numericSensitivity.Size = new Size(38, 23);
            numericSensitivity.TabIndex = 26;
            numericSensitivity.Value = new decimal(new int[] { 80, 0, 0, int.MinValue });
            // 
            // numericPower
            // 
            numericPower.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Location = new Point(104, 20);
            numericPower.Margin = new Padding(2);
            numericPower.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            numericPower.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Name = "numericPower";
            numericPower.Size = new Size(38, 23);
            numericPower.TabIndex = 25;
            numericPower.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, -1);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 24;
            label2.Text = "Sensitivity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, -1);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 23;
            label1.Text = "Power:";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(4, 4);
            connectButton.Margin = new Padding(2);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(78, 20);
            connectButton.TabIndex = 22;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 391);
            Controls.Add(tabControl1);
            Controls.Add(errorLabel);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Race Timer";
            FormClosing += Form1_FormClosing;
            listBoxContextMenu.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabRace.ResumeLayout(false);
            tabRace.PerformLayout();
            tabConfigure.ResumeLayout(false);
            tabConfigure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSensitivity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPower).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label errorLabel;
        private ContextMenuStrip listBoxContextMenu;
        private ToolStripMenuItem removeTagToolStripMenuItem;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabConfigure;
        private TabPage tabRace;
        private TextBox debugTextbox;
        private Button addButton;
        private TextBox timeInputTextBox;
        private ListBox resultslistBox;
        private Button resetButton;
        private Button stopButton;
        private Button startButton;
        private NumericUpDown numericSensitivity;
        private NumericUpDown numericPower;
        private Label label2;
        private Label label1;
        private Button connectButton;
        private DataGridView dataGridView;
        private TextBox textFirstNum;
        private Button button1;
        private Button buttonWrite;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ListBox rawListBox;
        private DataGridViewTextBoxColumn colTag;
        private DataGridViewTextBoxColumn colNumber;
    }
}


﻿namespace RaceTimingForm
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
            MELabel = new Label();
            resultsdataGrid = new DataGridView();
            timeCol = new DataGridViewTextBoxColumn();
            tagCol = new DataGridViewTextBoxColumn();
            debugTextbox = new TextBox();
            addButton = new Button();
            timeInputTextBox = new TextBox();
            resetButton = new Button();
            stopButton = new Button();
            startButton = new Button();
            tabConfigure = new TabPage();
            button2 = new Button();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            checkBeep = new CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)resultsdataGrid).BeginInit();
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
            errorLabel.Location = new Point(14, 309);
            errorLabel.Margin = new Padding(2, 0, 2, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(368, 451);
            errorLabel.TabIndex = 4;
            // 
            // listBoxContextMenu
            // 
            listBoxContextMenu.ImageScalingSize = new Size(24, 24);
            listBoxContextMenu.Items.AddRange(new ToolStripItem[] { removeTagToolStripMenuItem, clearAllToolStripMenuItem });
            listBoxContextMenu.Name = "listBoxContextMenu";
            listBoxContextMenu.Size = new Size(181, 68);
            // 
            // removeTagToolStripMenuItem
            // 
            removeTagToolStripMenuItem.Name = "removeTagToolStripMenuItem";
            removeTagToolStripMenuItem.Size = new Size(180, 32);
            removeTagToolStripMenuItem.Text = "Remove Tag";
            removeTagToolStripMenuItem.Click += removeTagToolStripMenuItem_Click;
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new Size(180, 32);
            clearAllToolStripMenuItem.Text = "Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabRace);
            tabControl1.Controls.Add(tabConfigure);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(14, 11);
            tabControl1.Margin = new Padding(2, 4, 2, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1074, 785);
            tabControl1.TabIndex = 14;
            // 
            // tabRace
            // 
            tabRace.Controls.Add(MELabel);
            tabRace.Controls.Add(resultsdataGrid);
            tabRace.Controls.Add(debugTextbox);
            tabRace.Controls.Add(addButton);
            tabRace.Controls.Add(timeInputTextBox);
            tabRace.Controls.Add(resetButton);
            tabRace.Controls.Add(stopButton);
            tabRace.Controls.Add(startButton);
            tabRace.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabRace.Location = new Point(4, 41);
            tabRace.Margin = new Padding(2, 4, 2, 4);
            tabRace.Name = "tabRace";
            tabRace.Padding = new Padding(2, 4, 2, 4);
            tabRace.Size = new Size(1066, 740);
            tabRace.TabIndex = 0;
            tabRace.Text = "Race";
            tabRace.UseVisualStyleBackColor = true;
            // 
            // MELabel
            // 
            MELabel.AutoSize = true;
            MELabel.Location = new Point(434, 226);
            MELabel.Margin = new Padding(4, 0, 4, 0);
            MELabel.Name = "MELabel";
            MELabel.Size = new Size(78, 32);
            MELabel.TabIndex = 26;
            MELabel.Text = "label3";
            // 
            // resultsdataGrid
            // 
            resultsdataGrid.AllowUserToAddRows = false;
            resultsdataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsdataGrid.Columns.AddRange(new DataGridViewColumn[] { timeCol, tagCol });
            resultsdataGrid.Location = new Point(586, 26);
            resultsdataGrid.Margin = new Padding(4, 4, 4, 4);
            resultsdataGrid.Name = "resultsdataGrid";
            resultsdataGrid.RowHeadersWidth = 51;
            resultsdataGrid.Size = new Size(414, 548);
            resultsdataGrid.TabIndex = 25;
            // 
            // timeCol
            // 
            timeCol.HeaderText = "Time";
            timeCol.MinimumWidth = 6;
            timeCol.Name = "timeCol";
            timeCol.Width = 125;
            // 
            // tagCol
            // 
            tagCol.HeaderText = "Tag";
            tagCol.MinimumWidth = 6;
            tagCol.Name = "tagCol";
            tagCol.Width = 125;
            // 
            // debugTextbox
            // 
            debugTextbox.Location = new Point(586, 596);
            debugTextbox.Margin = new Padding(2, 4, 2, 4);
            debugTextbox.Name = "debugTextbox";
            debugTextbox.Size = new Size(338, 39);
            debugTextbox.TabIndex = 23;
            // 
            // addButton
            // 
            addButton.Location = new Point(494, 594);
            addButton.Margin = new Padding(2, 4, 2, 4);
            addButton.Name = "addButton";
            addButton.Size = new Size(88, 45);
            addButton.TabIndex = 22;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // timeInputTextBox
            // 
            timeInputTextBox.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeInputTextBox.Location = new Point(149, 9);
            timeInputTextBox.Margin = new Padding(2, 4, 2, 4);
            timeInputTextBox.Name = "timeInputTextBox";
            timeInputTextBox.Size = new Size(370, 64);
            timeInputTextBox.TabIndex = 16;
            timeInputTextBox.Text = "MM:SS";
            // 
            // resetButton
            // 
            resetButton.Enabled = false;
            resetButton.Font = new Font("Segoe UI", 12F);
            resetButton.Location = new Point(426, 101);
            resetButton.Margin = new Padding(2, 4, 2, 4);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(140, 91);
            resetButton.TabIndex = 14;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Font = new Font("Segoe UI", 12F);
            stopButton.Location = new Point(279, 101);
            stopButton.Margin = new Padding(2, 4, 2, 4);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(140, 91);
            stopButton.TabIndex = 13;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 12F);
            startButton.Location = new Point(131, 101);
            startButton.Margin = new Padding(2, 4, 2, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(140, 91);
            startButton.TabIndex = 12;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // tabConfigure
            // 
            tabConfigure.Controls.Add(button2);
            tabConfigure.Controls.Add(checkBox2);
            tabConfigure.Controls.Add(checkBox1);
            tabConfigure.Controls.Add(checkBeep);
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
            tabConfigure.Location = new Point(4, 41);
            tabConfigure.Margin = new Padding(2, 4, 2, 4);
            tabConfigure.Name = "tabConfigure";
            tabConfigure.Padding = new Padding(2, 4, 2, 4);
            tabConfigure.Size = new Size(1066, 740);
            tabConfigure.TabIndex = 1;
            tabConfigure.Text = "Configure";
            tabConfigure.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(254, 205);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(108, 54);
            button2.TabIndex = 36;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(241, 154);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(97, 36);
            checkBox2.TabIndex = 35;
            checkBox2.Text = "Ant 2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(241, 101);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 36);
            checkBox1.TabIndex = 34;
            checkBox1.Text = "Ant 1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBeep
            // 
            checkBeep.AutoSize = true;
            checkBeep.Checked = true;
            checkBeep.CheckState = CheckState.Checked;
            checkBeep.Location = new Point(19, 159);
            checkBeep.Margin = new Padding(4, 4, 4, 4);
            checkBeep.Name = "checkBeep";
            checkBeep.Size = new Size(94, 36);
            checkBeep.TabIndex = 15;
            checkBeep.Text = "Beep";
            checkBeep.UseVisualStyleBackColor = true;
            // 
            // rawListBox
            // 
            rawListBox.FormattingEnabled = true;
            rawListBox.ItemHeight = 32;
            rawListBox.Location = new Point(828, 5);
            rawListBox.Margin = new Padding(4, 5, 4, 5);
            rawListBox.Name = "rawListBox";
            rawListBox.Size = new Size(220, 580);
            rawListBox.TabIndex = 33;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(19, 120);
            radioButton2.Margin = new Padding(4, 5, 4, 5);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(180, 36);
            radioButton2.TabIndex = 32;
            radioButton2.Text = "Program Bibs";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(19, 79);
            radioButton1.Margin = new Padding(4, 5, 4, 5);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(89, 36);
            radioButton1.TabIndex = 31;
            radioButton1.TabStop = true;
            radioButton1.Text = "Race";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // buttonWrite
            // 
            buttonWrite.Location = new Point(828, 675);
            buttonWrite.Margin = new Padding(2, 4, 2, 4);
            buttonWrite.Name = "buttonWrite";
            buttonWrite.Size = new Size(221, 55);
            buttonWrite.TabIndex = 30;
            buttonWrite.Text = "Write Numbers";
            buttonWrite.UseVisualStyleBackColor = true;
            buttonWrite.Click += buttonWrite_Click;
            // 
            // textFirstNum
            // 
            textFirstNum.Location = new Point(986, 621);
            textFirstNum.Margin = new Padding(2, 4, 2, 4);
            textFirstNum.Name = "textFirstNum";
            textFirstNum.Size = new Size(62, 39);
            textFirstNum.TabIndex = 29;
            textFirstNum.Text = "1";
            // 
            // button1
            // 
            button1.Location = new Point(828, 614);
            button1.Margin = new Padding(2, 4, 2, 4);
            button1.Name = "button1";
            button1.Size = new Size(126, 54);
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
            dataGridView.Location = new Point(368, 0);
            dataGridView.Margin = new Padding(2, 4, 2, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(442, 734);
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
            colTag.Width = 86;
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
            numericSensitivity.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numericSensitivity.Location = new Point(246, 34);
            numericSensitivity.Margin = new Padding(2, 4, 2, 4);
            numericSensitivity.Maximum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numericSensitivity.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            numericSensitivity.Name = "numericSensitivity";
            numericSensitivity.Size = new Size(70, 39);
            numericSensitivity.TabIndex = 26;
            numericSensitivity.Value = new decimal(new int[] { 55, 0, 0, int.MinValue });
            numericSensitivity.ValueChanged += numericSensitivity_ValueChanged;
            // 
            // numericPower
            // 
            numericPower.Location = new Point(149, 34);
            numericPower.Margin = new Padding(2, 4, 2, 4);
            numericPower.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericPower.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericPower.Name = "numericPower";
            numericPower.Size = new Size(78, 39);
            numericPower.TabIndex = 25;
            numericPower.Value = new decimal(new int[] { 16, 0, 0, 0 });
            numericPower.ValueChanged += numericPower_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, -1);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 32);
            label2.TabIndex = 24;
            label2.Text = "Sensitivity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, -1);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 23;
            label1.Text = "Power:";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(6, 6);
            connectButton.Margin = new Padding(2, 4, 2, 4);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(129, 64);
            connectButton.TabIndex = 22;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 804);
            Controls.Add(errorLabel);
            Controls.Add(tabControl1);
            Margin = new Padding(2, 4, 2, 4);
            Name = "Form1";
            Text = "Race Timer";
            FormClosing += Form1_FormClosing;
            listBoxContextMenu.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabRace.ResumeLayout(false);
            tabRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resultsdataGrid).EndInit();
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
        private CheckBox checkBeep;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button button2;
        private DataGridView resultsdataGrid;
        private DataGridViewTextBoxColumn timeCol;
        private DataGridViewTextBoxColumn tagCol;
        private Label MELabel;
    }
}

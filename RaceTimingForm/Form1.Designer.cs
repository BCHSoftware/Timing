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
            buttonWrite = new Button();
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
            errorLabel.Location = new Point(14, 451);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(1016, 68);
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
            tabControl1.Location = new Point(14, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1013, 477);
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
            tabRace.Location = new Point(4, 34);
            tabRace.Name = "tabRace";
            tabRace.Padding = new Padding(3);
            tabRace.Size = new Size(1005, 439);
            tabRace.TabIndex = 0;
            tabRace.Text = "Race";
            tabRace.UseVisualStyleBackColor = true;
            // 
            // debugTextbox
            // 
            debugTextbox.Location = new Point(584, 320);
            debugTextbox.Name = "debugTextbox";
            debugTextbox.Size = new Size(339, 31);
            debugTextbox.TabIndex = 23;
            // 
            // addButton
            // 
            addButton.Location = new Point(519, 317);
            addButton.Name = "addButton";
            addButton.Size = new Size(61, 34);
            addButton.TabIndex = 22;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // timeInputTextBox
            // 
            timeInputTextBox.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeInputTextBox.Location = new Point(149, 9);
            timeInputTextBox.Name = "timeInputTextBox";
            timeInputTextBox.Size = new Size(370, 64);
            timeInputTextBox.TabIndex = 16;
            timeInputTextBox.Text = "MM:SS";
            // 
            // resultslistBox
            // 
            resultslistBox.ContextMenuStrip = listBoxContextMenu;
            resultslistBox.FormattingEnabled = true;
            resultslistBox.ItemHeight = 25;
            resultslistBox.Location = new Point(586, 9);
            resultslistBox.Name = "resultslistBox";
            resultslistBox.SelectionMode = SelectionMode.MultiExtended;
            resultslistBox.Size = new Size(413, 304);
            resultslistBox.TabIndex = 15;
            // 
            // resetButton
            // 
            resetButton.Enabled = false;
            resetButton.Location = new Point(425, 101);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(140, 92);
            resetButton.TabIndex = 14;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(278, 101);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(140, 92);
            stopButton.TabIndex = 13;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.Enabled = false;
            startButton.Location = new Point(132, 101);
            startButton.Name = "startButton";
            startButton.Size = new Size(140, 92);
            startButton.TabIndex = 12;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // tabConfigure
            // 
            tabConfigure.Controls.Add(buttonWrite);
            tabConfigure.Controls.Add(textFirstNum);
            tabConfigure.Controls.Add(button1);
            tabConfigure.Controls.Add(dataGridView);
            tabConfigure.Controls.Add(numericSensitivity);
            tabConfigure.Controls.Add(numericPower);
            tabConfigure.Controls.Add(label2);
            tabConfigure.Controls.Add(label1);
            tabConfigure.Controls.Add(connectButton);
            tabConfigure.Location = new Point(4, 34);
            tabConfigure.Name = "tabConfigure";
            tabConfigure.Padding = new Padding(3);
            tabConfigure.Size = new Size(1005, 439);
            tabConfigure.TabIndex = 1;
            tabConfigure.Text = "Configure";
            tabConfigure.UseVisualStyleBackColor = true;
            // 
            // textFirstNum
            // 
            textFirstNum.Location = new Point(938, 40);
            textFirstNum.Name = "textFirstNum";
            textFirstNum.Size = new Size(61, 31);
            textFirstNum.TabIndex = 29;
            textFirstNum.Text = "1";
            // 
            // button1
            // 
            button1.Location = new Point(821, 39);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 28;
            button1.Text = "Fill From";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { colTag, colNumber });
            dataGridView.Location = new Point(451, 6);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(364, 413);
            dataGridView.TabIndex = 27;
            // 
            // colTag
            // 
            colTag.HeaderText = "Tag";
            colTag.MinimumWidth = 8;
            colTag.Name = "colTag";
            colTag.ReadOnly = true;
            colTag.Width = 150;
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
            numericSensitivity.Location = new Point(263, 34);
            numericSensitivity.Maximum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numericSensitivity.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            numericSensitivity.Name = "numericSensitivity";
            numericSensitivity.Size = new Size(54, 31);
            numericSensitivity.TabIndex = 26;
            numericSensitivity.Value = new decimal(new int[] { 80, 0, 0, int.MinValue });
            // 
            // numericPower
            // 
            numericPower.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Location = new Point(149, 34);
            numericPower.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            numericPower.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Name = "numericPower";
            numericPower.Size = new Size(54, 31);
            numericPower.TabIndex = 25;
            numericPower.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, -2);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 24;
            label2.Text = "Sensitivity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, -2);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 23;
            label1.Text = "Power:";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(6, 6);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(111, 33);
            connectButton.TabIndex = 22;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // buttonWrite
            // 
            buttonWrite.Location = new Point(834, 385);
            buttonWrite.Name = "buttonWrite";
            buttonWrite.Size = new Size(152, 34);
            buttonWrite.TabIndex = 30;
            buttonWrite.Text = "Write Numbers";
            buttonWrite.UseVisualStyleBackColor = true;
            buttonWrite.Click += buttonWrite_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1379, 652);
            Controls.Add(tabControl1);
            Controls.Add(errorLabel);
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
        private DataGridViewTextBoxColumn colTag;
        private DataGridViewTextBoxColumn colNumber;
        private Button buttonWrite;
    }
}

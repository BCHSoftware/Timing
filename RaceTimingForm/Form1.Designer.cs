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
            startButton = new Button();
            stopButton = new Button();
            resetButton = new Button();
            updateTimer = new System.Windows.Forms.Timer(components);
            errorLabel = new Label();
            resultslistBox = new ListBox();
            listBoxContextMenu = new ContextMenuStrip(components);
            removeTagToolStripMenuItem = new ToolStripMenuItem();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            timeInputTextBox = new TextBox();
            connectButton = new Button();
            label1 = new Label();
            label2 = new Label();
            numericPower = new NumericUpDown();
            numericSensitivity = new NumericUpDown();
            listBoxContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSensitivity).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Enabled = false;
            startButton.Location = new Point(157, 180);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(140, 91);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(303, 180);
            stopButton.Margin = new Padding(3, 4, 3, 4);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(140, 91);
            stopButton.TabIndex = 2;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // resetButton
            // 
            resetButton.Enabled = false;
            resetButton.Location = new Point(450, 180);
            resetButton.Margin = new Padding(3, 4, 3, 4);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(140, 91);
            resetButton.TabIndex = 3;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
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
            errorLabel.Location = new Point(12, 484);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(1016, 69);
            errorLabel.TabIndex = 4;
            // 
            // resultslistBox
            // 
            resultslistBox.ContextMenuStrip = listBoxContextMenu;
            resultslistBox.FormattingEnabled = true;
            resultslistBox.ItemHeight = 25;
            resultslistBox.Location = new Point(612, 12);
            resultslistBox.Name = "resultslistBox";
            resultslistBox.SelectionMode = SelectionMode.MultiExtended;
            resultslistBox.Size = new Size(412, 379);
            resultslistBox.TabIndex = 5;
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
            // timeInputTextBox
            // 
            timeInputTextBox.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeInputTextBox.Location = new Point(174, 89);
            timeInputTextBox.Name = "timeInputTextBox";
            timeInputTextBox.Size = new Size(370, 64);
            timeInputTextBox.TabIndex = 6;
            timeInputTextBox.Text = "MM:SS";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(30, 375);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(112, 34);
            connectButton.TabIndex = 7;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 366);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 8;
            label1.Text = "Power:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 366);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 9;
            label2.Text = "Sensitivity:";
            // 
            // numericPower
            // 
            numericPower.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Location = new Point(173, 404);
            numericPower.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            numericPower.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericPower.Name = "numericPower";
            numericPower.Size = new Size(55, 31);
            numericPower.TabIndex = 10;
            numericPower.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numericSensitivity
            // 
            numericSensitivity.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            numericSensitivity.Location = new Point(287, 404);
            numericSensitivity.Maximum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numericSensitivity.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            numericSensitivity.Name = "numericSensitivity";
            numericSensitivity.Size = new Size(55, 31);
            numericSensitivity.TabIndex = 11;
            numericSensitivity.Value = new decimal(new int[] { 80, 0, 0, int.MinValue });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 562);
            Controls.Add(numericSensitivity);
            Controls.Add(numericPower);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(connectButton);
            Controls.Add(timeInputTextBox);
            Controls.Add(resultslistBox);
            Controls.Add(errorLabel);
            Controls.Add(resetButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Race Timer";
            FormClosing += Form1_FormClosing;
            listBoxContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericPower).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSensitivity).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label errorLabel;
        private ListBox resultslistBox;
        private ContextMenuStrip listBoxContextMenu;
        private ToolStripMenuItem removeTagToolStripMenuItem;
        private TextBox timeInputTextBox;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private Button connectButton;
        private Label label1;
        private Label label2;
        private NumericUpDown numericPower;
        private NumericUpDown numericSensitivity;
    }
}

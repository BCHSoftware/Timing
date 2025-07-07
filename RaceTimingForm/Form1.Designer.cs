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
            timeInputTextBox = new TextBox();
            clearAllToolStripMenuItem = new ToolStripMenuItem();
            listBoxContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // startButton
            // 
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
            errorLabel.Location = new Point(48, 350);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(807, 69);
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
            resultslistBox.Size = new Size(412, 504);
            resultslistBox.TabIndex = 5;
            // 
            // listBoxContextMenu
            // 
            listBoxContextMenu.ImageScalingSize = new Size(24, 24);
            listBoxContextMenu.Items.AddRange(new ToolStripItem[] { removeTagToolStripMenuItem, clearAllToolStripMenuItem });
            listBoxContextMenu.Name = "listBoxContextMenu";
            listBoxContextMenu.Size = new Size(241, 101);
            // 
            // removeTagToolStripMenuItem
            // 
            removeTagToolStripMenuItem.Name = "removeTagToolStripMenuItem";
            removeTagToolStripMenuItem.Size = new Size(240, 32);
            removeTagToolStripMenuItem.Text = "Remove Tag";
            removeTagToolStripMenuItem.Click += removeTagToolStripMenuItem_Click;
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
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new Size(240, 32);
            clearAllToolStripMenuItem.Text = "Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 562);
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
    }
}

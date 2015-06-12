namespace BingOhm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.listBoxCalled = new System.Windows.Forms.ListBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.trackBarRevealTime = new System.Windows.Forms.TrackBar();
            this.labelRevealTime = new System.Windows.Forms.Label();
            this.labelRevealTimeIndicator = new System.Windows.Forms.Label();
            this.radioButtonSortOrder = new System.Windows.Forms.RadioButton();
            this.radioButtonSortValue = new System.Windows.Forms.RadioButton();
            this.textBoxCheckValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTolerance = new System.Windows.Forms.ComboBox();
            this.labelRemainingResistors = new System.Windows.Forms.Label();
            this.comboBoxOColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxGColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxNColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxIColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxBColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxSeriesSelector = new System.Windows.Forms.ComboBox();
            this.buttonCheckValue = new System.Windows.Forms.Button();
            this.timerReveal = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRevealTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(853, 640);
            this.pictureBoxDisplay.TabIndex = 0;
            this.pictureBoxDisplay.TabStop = false;
            this.pictureBoxDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDisplay_Paint);
            // 
            // listBoxCalled
            // 
            this.listBoxCalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCalled.FormattingEnabled = true;
            this.listBoxCalled.ItemHeight = 20;
            this.listBoxCalled.Location = new System.Drawing.Point(873, 149);
            this.listBoxCalled.Name = "listBoxCalled";
            this.listBoxCalled.Size = new System.Drawing.Size(546, 484);
            this.listBoxCalled.TabIndex = 1;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(6, 18);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(81, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(93, 18);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(81, 23);
            this.buttonNewGame.TabIndex = 3;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // trackBarRevealTime
            // 
            this.trackBarRevealTime.Location = new System.Drawing.Point(253, 17);
            this.trackBarRevealTime.Maximum = 30;
            this.trackBarRevealTime.Name = "trackBarRevealTime";
            this.trackBarRevealTime.Size = new System.Drawing.Size(256, 45);
            this.trackBarRevealTime.TabIndex = 4;
            this.trackBarRevealTime.Scroll += new System.EventHandler(this.trackBarRevealTime_Scroll);
            // 
            // labelRevealTime
            // 
            this.labelRevealTime.AutoSize = true;
            this.labelRevealTime.Location = new System.Drawing.Point(180, 17);
            this.labelRevealTime.Name = "labelRevealTime";
            this.labelRevealTime.Size = new System.Drawing.Size(67, 13);
            this.labelRevealTime.TabIndex = 5;
            this.labelRevealTime.Text = "Reveal Time";
            // 
            // labelRevealTimeIndicator
            // 
            this.labelRevealTimeIndicator.AutoSize = true;
            this.labelRevealTimeIndicator.Location = new System.Drawing.Point(512, 18);
            this.labelRevealTimeIndicator.Name = "labelRevealTimeIndicator";
            this.labelRevealTimeIndicator.Size = new System.Drawing.Size(33, 13);
            this.labelRevealTimeIndicator.TabIndex = 6;
            this.labelRevealTimeIndicator.Text = "0 sec";
            // 
            // radioButtonSortOrder
            // 
            this.radioButtonSortOrder.AutoSize = true;
            this.radioButtonSortOrder.Checked = true;
            this.radioButtonSortOrder.Location = new System.Drawing.Point(873, 126);
            this.radioButtonSortOrder.Name = "radioButtonSortOrder";
            this.radioButtonSortOrder.Size = new System.Drawing.Size(88, 17);
            this.radioButtonSortOrder.TabIndex = 9;
            this.radioButtonSortOrder.TabStop = true;
            this.radioButtonSortOrder.Text = "Sort By Order";
            this.radioButtonSortOrder.UseVisualStyleBackColor = true;
            this.radioButtonSortOrder.CheckedChanged += new System.EventHandler(this.radioButtonSortOrder_CheckedChanged);
            // 
            // radioButtonSortValue
            // 
            this.radioButtonSortValue.AutoSize = true;
            this.radioButtonSortValue.Location = new System.Drawing.Point(967, 126);
            this.radioButtonSortValue.Name = "radioButtonSortValue";
            this.radioButtonSortValue.Size = new System.Drawing.Size(89, 17);
            this.radioButtonSortValue.TabIndex = 10;
            this.radioButtonSortValue.Text = "Sort By Value";
            this.radioButtonSortValue.UseVisualStyleBackColor = true;
            this.radioButtonSortValue.CheckedChanged += new System.EventHandler(this.radioButtonSortValue_CheckedChanged);
            // 
            // textBoxCheckValue
            // 
            this.textBoxCheckValue.Location = new System.Drawing.Point(1156, 123);
            this.textBoxCheckValue.Name = "textBoxCheckValue";
            this.textBoxCheckValue.Size = new System.Drawing.Size(181, 20);
            this.textBoxCheckValue.TabIndex = 11;
            this.textBoxCheckValue.Text = "Check For Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTolerance);
            this.groupBox1.Controls.Add(this.labelRemainingResistors);
            this.groupBox1.Controls.Add(this.comboBoxOColumn);
            this.groupBox1.Controls.Add(this.comboBoxGColumn);
            this.groupBox1.Controls.Add(this.comboBoxNColumn);
            this.groupBox1.Controls.Add(this.comboBoxIColumn);
            this.groupBox1.Controls.Add(this.comboBoxBColumn);
            this.groupBox1.Controls.Add(this.comboBoxSeriesSelector);
            this.groupBox1.Controls.Add(this.labelRevealTime);
            this.groupBox1.Controls.Add(this.trackBarRevealTime);
            this.groupBox1.Controls.Add(this.buttonNewGame);
            this.groupBox1.Controls.Add(this.buttonNext);
            this.groupBox1.Controls.Add(this.labelRevealTimeIndicator);
            this.groupBox1.Location = new System.Drawing.Point(868, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 103);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Controls";
            // 
            // comboBoxTolerance
            // 
            this.comboBoxTolerance.FormattingEnabled = true;
            this.comboBoxTolerance.Location = new System.Drawing.Point(136, 47);
            this.comboBoxTolerance.Name = "comboBoxTolerance";
            this.comboBoxTolerance.Size = new System.Drawing.Size(111, 21);
            this.comboBoxTolerance.TabIndex = 14;
            this.comboBoxTolerance.Text = "Tolerance";
            this.comboBoxTolerance.SelectedIndexChanged += new System.EventHandler(this.comboBoxTolerance_SelectedIndexChanged);
            // 
            // labelRemainingResistors
            // 
            this.labelRemainingResistors.AutoSize = true;
            this.labelRemainingResistors.Location = new System.Drawing.Point(253, 56);
            this.labelRemainingResistors.Name = "labelRemainingResistors";
            this.labelRemainingResistors.Size = new System.Drawing.Size(112, 13);
            this.labelRemainingResistors.TabIndex = 13;
            this.labelRemainingResistors.Text = "0 Resistors Remaining";
            // 
            // comboBoxOColumn
            // 
            this.comboBoxOColumn.FormattingEnabled = true;
            this.comboBoxOColumn.Location = new System.Drawing.Point(419, 76);
            this.comboBoxOColumn.Name = "comboBoxOColumn";
            this.comboBoxOColumn.Size = new System.Drawing.Size(97, 21);
            this.comboBoxOColumn.TabIndex = 12;
            this.comboBoxOColumn.Text = "O Multiplier";
            this.comboBoxOColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxOColumn_SelectedIndexChanged);
            // 
            // comboBoxGColumn
            // 
            this.comboBoxGColumn.FormattingEnabled = true;
            this.comboBoxGColumn.Location = new System.Drawing.Point(316, 76);
            this.comboBoxGColumn.Name = "comboBoxGColumn";
            this.comboBoxGColumn.Size = new System.Drawing.Size(97, 21);
            this.comboBoxGColumn.TabIndex = 11;
            this.comboBoxGColumn.Text = "G Multiplier";
            this.comboBoxGColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxGColumn_SelectedIndexChanged);
            // 
            // comboBoxNColumn
            // 
            this.comboBoxNColumn.FormattingEnabled = true;
            this.comboBoxNColumn.Location = new System.Drawing.Point(213, 76);
            this.comboBoxNColumn.Name = "comboBoxNColumn";
            this.comboBoxNColumn.Size = new System.Drawing.Size(97, 21);
            this.comboBoxNColumn.TabIndex = 10;
            this.comboBoxNColumn.Text = "N Multiplier";
            this.comboBoxNColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxNColumn_SelectedIndexChanged);
            // 
            // comboBoxIColumn
            // 
            this.comboBoxIColumn.FormattingEnabled = true;
            this.comboBoxIColumn.Location = new System.Drawing.Point(110, 76);
            this.comboBoxIColumn.Name = "comboBoxIColumn";
            this.comboBoxIColumn.Size = new System.Drawing.Size(97, 21);
            this.comboBoxIColumn.TabIndex = 9;
            this.comboBoxIColumn.Text = "I Multiplier";
            this.comboBoxIColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxIColumn_SelectedIndexChanged);
            // 
            // comboBoxBColumn
            // 
            this.comboBoxBColumn.FormattingEnabled = true;
            this.comboBoxBColumn.Location = new System.Drawing.Point(7, 76);
            this.comboBoxBColumn.Name = "comboBoxBColumn";
            this.comboBoxBColumn.Size = new System.Drawing.Size(97, 21);
            this.comboBoxBColumn.TabIndex = 8;
            this.comboBoxBColumn.Text = "B Multiplier";
            this.comboBoxBColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxBColumn_SelectedIndexChanged);
            // 
            // comboBoxSeriesSelector
            // 
            this.comboBoxSeriesSelector.FormattingEnabled = true;
            this.comboBoxSeriesSelector.Location = new System.Drawing.Point(7, 48);
            this.comboBoxSeriesSelector.Name = "comboBoxSeriesSelector";
            this.comboBoxSeriesSelector.Size = new System.Drawing.Size(123, 21);
            this.comboBoxSeriesSelector.TabIndex = 7;
            this.comboBoxSeriesSelector.Text = "Series";
            this.comboBoxSeriesSelector.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeriesSelector_SelectedIndexChanged);
            // 
            // buttonCheckValue
            // 
            this.buttonCheckValue.Location = new System.Drawing.Point(1344, 121);
            this.buttonCheckValue.Name = "buttonCheckValue";
            this.buttonCheckValue.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckValue.TabIndex = 13;
            this.buttonCheckValue.Text = "Check!";
            this.buttonCheckValue.UseVisualStyleBackColor = true;
            this.buttonCheckValue.Click += new System.EventHandler(this.buttonCheckValue_Click);
            // 
            // timerReveal
            // 
            this.timerReveal.Interval = 1000;
            this.timerReveal.Tick += new System.EventHandler(this.timerReveal_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 640);
            this.Controls.Add(this.buttonCheckValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxCheckValue);
            this.Controls.Add(this.radioButtonSortValue);
            this.Controls.Add(this.radioButtonSortOrder);
            this.Controls.Add(this.listBoxCalled);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Bing-Ohm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRevealTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.ListBox listBoxCalled;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.TrackBar trackBarRevealTime;
        private System.Windows.Forms.Label labelRevealTime;
        private System.Windows.Forms.Label labelRevealTimeIndicator;
        private System.Windows.Forms.RadioButton radioButtonSortOrder;
        private System.Windows.Forms.RadioButton radioButtonSortValue;
        private System.Windows.Forms.TextBox textBoxCheckValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRemainingResistors;
        private System.Windows.Forms.ComboBox comboBoxOColumn;
        private System.Windows.Forms.ComboBox comboBoxGColumn;
        private System.Windows.Forms.ComboBox comboBoxNColumn;
        private System.Windows.Forms.ComboBox comboBoxIColumn;
        private System.Windows.Forms.ComboBox comboBoxBColumn;
        private System.Windows.Forms.ComboBox comboBoxSeriesSelector;
        private System.Windows.Forms.ComboBox comboBoxTolerance;
        private System.Windows.Forms.Button buttonCheckValue;
        private System.Windows.Forms.Timer timerReveal;
    }
}


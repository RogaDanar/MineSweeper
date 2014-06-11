namespace MineSweeper
{
    partial class Main
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblLastWorst = new System.Windows.Forms.Label();
            this.lblWorstValue = new System.Windows.Forms.Label();
            this.lblWorst = new System.Windows.Forms.Label();
            this.lblLastAvg = new System.Windows.Forms.Label();
            this.lblLastBest = new System.Windows.Forms.Label();
            this.btnFast = new System.Windows.Forms.Button();
            this.lblAvgValue = new System.Windows.Forms.Label();
            this.lblBestValue = new System.Windows.Forms.Label();
            this.lblGenValue = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.tbSweepers = new System.Windows.Forms.TextBox();
            this.tbMine = new System.Windows.Forms.TextBox();
            this.lblSweepers = new System.Windows.Forms.Label();
            this.lblMines = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTicks = new System.Windows.Forms.Label();
            this.lblPerturb = new System.Windows.Forms.Label();
            this.tbTicks = new System.Windows.Forms.TextBox();
            this.tbPerturb = new System.Windows.Forms.TextBox();
            this.lblCrossover = new System.Windows.Forms.Label();
            this.lblMutation = new System.Windows.Forms.Label();
            this.tbCrossover = new System.Windows.Forms.TextBox();
            this.tbMutation = new System.Windows.Forms.TextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.White;
            this.pbMain.Location = new System.Drawing.Point(-2, -1);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(400, 400);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(3, 0);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(59, 13);
            this.lblGeneration.TabIndex = 1;
            this.lblGeneration.Text = "Generation";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(6, 13);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(116, 23);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStopClick);
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.Controls.Add(this.lblLastWorst);
            this.pnlStats.Controls.Add(this.lblWorstValue);
            this.pnlStats.Controls.Add(this.lblWorst);
            this.pnlStats.Controls.Add(this.lblLastAvg);
            this.pnlStats.Controls.Add(this.lblLastBest);
            this.pnlStats.Controls.Add(this.btnFast);
            this.pnlStats.Controls.Add(this.lblAvgValue);
            this.pnlStats.Controls.Add(this.lblBestValue);
            this.pnlStats.Controls.Add(this.lblGenValue);
            this.pnlStats.Controls.Add(this.lblAvg);
            this.pnlStats.Controls.Add(this.lblBest);
            this.pnlStats.Controls.Add(this.lblGeneration);
            this.pnlStats.Location = new System.Drawing.Point(411, 410);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(130, 190);
            this.pnlStats.TabIndex = 29;
            // 
            // lblLastWorst
            // 
            this.lblLastWorst.AutoSize = true;
            this.lblLastWorst.Location = new System.Drawing.Point(62, 49);
            this.lblLastWorst.Name = "lblLastWorst";
            this.lblLastWorst.Size = new System.Drawing.Size(19, 13);
            this.lblLastWorst.TabIndex = 14;
            this.lblLastWorst.Text = "10";
            // 
            // lblWorstValue
            // 
            this.lblWorstValue.AutoSize = true;
            this.lblWorstValue.Location = new System.Drawing.Point(37, 49);
            this.lblWorstValue.Name = "lblWorstValue";
            this.lblWorstValue.Size = new System.Drawing.Size(19, 13);
            this.lblWorstValue.TabIndex = 13;
            this.lblWorstValue.Text = "10";
            // 
            // lblWorst
            // 
            this.lblWorst.AutoSize = true;
            this.lblWorst.ForeColor = System.Drawing.Color.Red;
            this.lblWorst.Location = new System.Drawing.Point(3, 49);
            this.lblWorst.Name = "lblWorst";
            this.lblWorst.Size = new System.Drawing.Size(35, 13);
            this.lblWorst.TabIndex = 12;
            this.lblWorst.Text = "Worst";
            // 
            // lblLastAvg
            // 
            this.lblLastAvg.AutoSize = true;
            this.lblLastAvg.Location = new System.Drawing.Point(62, 71);
            this.lblLastAvg.Name = "lblLastAvg";
            this.lblLastAvg.Size = new System.Drawing.Size(19, 13);
            this.lblLastAvg.TabIndex = 11;
            this.lblLastAvg.Text = "10";
            // 
            // lblLastBest
            // 
            this.lblLastBest.AutoSize = true;
            this.lblLastBest.Location = new System.Drawing.Point(62, 26);
            this.lblLastBest.Name = "lblLastBest";
            this.lblLastBest.Size = new System.Drawing.Size(19, 13);
            this.lblLastBest.TabIndex = 10;
            this.lblLastBest.Text = "10";
            // 
            // btnFast
            // 
            this.btnFast.Location = new System.Drawing.Point(6, 155);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(118, 23);
            this.btnFast.TabIndex = 15;
            this.btnFast.Text = "Fast";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFastClick);
            // 
            // lblAvgValue
            // 
            this.lblAvgValue.AutoSize = true;
            this.lblAvgValue.Location = new System.Drawing.Point(37, 71);
            this.lblAvgValue.Name = "lblAvgValue";
            this.lblAvgValue.Size = new System.Drawing.Size(19, 13);
            this.lblAvgValue.TabIndex = 8;
            this.lblAvgValue.Text = "10";
            // 
            // lblBestValue
            // 
            this.lblBestValue.AutoSize = true;
            this.lblBestValue.Location = new System.Drawing.Point(37, 26);
            this.lblBestValue.Name = "lblBestValue";
            this.lblBestValue.Size = new System.Drawing.Size(19, 13);
            this.lblBestValue.TabIndex = 7;
            this.lblBestValue.Text = "10";
            // 
            // lblGenValue
            // 
            this.lblGenValue.AutoSize = true;
            this.lblGenValue.Location = new System.Drawing.Point(62, 0);
            this.lblGenValue.Name = "lblGenValue";
            this.lblGenValue.Size = new System.Drawing.Size(19, 13);
            this.lblGenValue.TabIndex = 6;
            this.lblGenValue.Text = "10";
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(3, 71);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(29, 13);
            this.lblAvg.TabIndex = 5;
            this.lblAvg.Text = "Avg.";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.ForeColor = System.Drawing.Color.Blue;
            this.lblBest.Location = new System.Drawing.Point(3, 26);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(28, 13);
            this.lblBest.TabIndex = 4;
            this.lblBest.Text = "Best";
            // 
            // pbGraph
            // 
            this.pbGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbGraph.BackColor = System.Drawing.Color.White;
            this.pbGraph.Location = new System.Drawing.Point(-2, 410);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(400, 190);
            this.pbGraph.TabIndex = 5;
            this.pbGraph.TabStop = false;
            // 
            // tbSweepers
            // 
            this.tbSweepers.Location = new System.Drawing.Point(102, 320);
            this.tbSweepers.Name = "tbSweepers";
            this.tbSweepers.Size = new System.Drawing.Size(22, 20);
            this.tbSweepers.TabIndex = 16;
            this.tbSweepers.Text = "30";
            // 
            // tbMine
            // 
            this.tbMine.Location = new System.Drawing.Point(102, 342);
            this.tbMine.Name = "tbMine";
            this.tbMine.Size = new System.Drawing.Size(22, 20);
            this.tbMine.TabIndex = 17;
            this.tbMine.Text = "40";
            // 
            // lblSweepers
            // 
            this.lblSweepers.AutoSize = true;
            this.lblSweepers.Location = new System.Drawing.Point(11, 323);
            this.lblSweepers.Name = "lblSweepers";
            this.lblSweepers.Size = new System.Drawing.Size(54, 13);
            this.lblSweepers.TabIndex = 15;
            this.lblSweepers.Text = "Sweepers";
            // 
            // lblMines
            // 
            this.lblMines.AutoSize = true;
            this.lblMines.Location = new System.Drawing.Point(30, 345);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(35, 13);
            this.lblMines.TabIndex = 18;
            this.lblMines.Text = "Mines";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 368);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "(Re)set values";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnResetClick);
            // 
            // lblTicks
            // 
            this.lblTicks.AutoSize = true;
            this.lblTicks.Location = new System.Drawing.Point(32, 302);
            this.lblTicks.Name = "lblTicks";
            this.lblTicks.Size = new System.Drawing.Size(33, 13);
            this.lblTicks.TabIndex = 23;
            this.lblTicks.Text = "Ticks";
            // 
            // lblPerturb
            // 
            this.lblPerturb.AutoSize = true;
            this.lblPerturb.Location = new System.Drawing.Point(16, 280);
            this.lblPerturb.Name = "lblPerturb";
            this.lblPerturb.Size = new System.Drawing.Size(51, 13);
            this.lblPerturb.TabIndex = 20;
            this.lblPerturb.Text = "Max pert.";
            // 
            // tbTicks
            // 
            this.tbTicks.Location = new System.Drawing.Point(92, 299);
            this.tbTicks.Name = "tbTicks";
            this.tbTicks.Size = new System.Drawing.Size(32, 20);
            this.tbTicks.TabIndex = 22;
            this.tbTicks.Text = "2000";
            // 
            // tbPerturb
            // 
            this.tbPerturb.Location = new System.Drawing.Point(102, 277);
            this.tbPerturb.Name = "tbPerturb";
            this.tbPerturb.Size = new System.Drawing.Size(22, 20);
            this.tbPerturb.TabIndex = 21;
            this.tbPerturb.Text = "0.3";
            // 
            // lblCrossover
            // 
            this.lblCrossover.AutoSize = true;
            this.lblCrossover.Location = new System.Drawing.Point(8, 258);
            this.lblCrossover.Name = "lblCrossover";
            this.lblCrossover.Size = new System.Drawing.Size(57, 13);
            this.lblCrossover.TabIndex = 27;
            this.lblCrossover.Text = "Cross. rate";
            // 
            // lblMutation
            // 
            this.lblMutation.AutoSize = true;
            this.lblMutation.Location = new System.Drawing.Point(16, 236);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(49, 13);
            this.lblMutation.TabIndex = 24;
            this.lblMutation.Text = "Mut. rate";
            // 
            // tbCrossover
            // 
            this.tbCrossover.Location = new System.Drawing.Point(102, 255);
            this.tbCrossover.Name = "tbCrossover";
            this.tbCrossover.Size = new System.Drawing.Size(22, 20);
            this.tbCrossover.TabIndex = 26;
            this.tbCrossover.Text = "0.7";
            // 
            // tbMutation
            // 
            this.tbMutation.Location = new System.Drawing.Point(102, 233);
            this.tbMutation.Name = "tbMutation";
            this.tbMutation.Size = new System.Drawing.Size(22, 20);
            this.tbMutation.TabIndex = 25;
            this.tbMutation.Text = "0.1";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Controls.Add(this.lblHeight);
            this.pnlSettings.Controls.Add(this.lblWidth);
            this.pnlSettings.Controls.Add(this.tbHeight);
            this.pnlSettings.Controls.Add(this.tbWidth);
            this.pnlSettings.Controls.Add(this.btnStartStop);
            this.pnlSettings.Controls.Add(this.lblCrossover);
            this.pnlSettings.Controls.Add(this.tbSweepers);
            this.pnlSettings.Controls.Add(this.lblMutation);
            this.pnlSettings.Controls.Add(this.tbMine);
            this.pnlSettings.Controls.Add(this.tbCrossover);
            this.pnlSettings.Controls.Add(this.lblSweepers);
            this.pnlSettings.Controls.Add(this.tbMutation);
            this.pnlSettings.Controls.Add(this.lblMines);
            this.pnlSettings.Controls.Add(this.lblTicks);
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.lblPerturb);
            this.pnlSettings.Controls.Add(this.tbPerturb);
            this.pnlSettings.Controls.Add(this.tbTicks);
            this.pnlSettings.Location = new System.Drawing.Point(411, -1);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(130, 400);
            this.pnlSettings.TabIndex = 28;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(8, 197);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(66, 13);
            this.lblHeight.TabIndex = 31;
            this.lblHeight.Text = "Draw Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(11, 175);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(63, 13);
            this.lblWidth.TabIndex = 28;
            this.lblWidth.Text = "Draw Width";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(92, 194);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(32, 20);
            this.tbHeight.TabIndex = 30;
            this.tbHeight.Text = "400";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(92, 172);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(32, 20);
            this.tbWidth.TabIndex = 29;
            this.tbWidth.Text = "400";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(541, 600);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.pbGraph);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblLastAvg;
        private System.Windows.Forms.Label lblLastBest;
        private System.Windows.Forms.Label lblAvgValue;
        private System.Windows.Forms.Label lblBestValue;
        private System.Windows.Forms.Label lblGenValue;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label lblLastWorst;
        private System.Windows.Forms.Label lblWorstValue;
        private System.Windows.Forms.Label lblWorst;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.TextBox tbSweepers;
        private System.Windows.Forms.TextBox tbMine;
        private System.Windows.Forms.Label lblSweepers;
        private System.Windows.Forms.Label lblMines;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTicks;
        private System.Windows.Forms.Label lblPerturb;
        private System.Windows.Forms.TextBox tbTicks;
        private System.Windows.Forms.TextBox tbPerturb;
        private System.Windows.Forms.Label lblCrossover;
        private System.Windows.Forms.Label lblMutation;
        private System.Windows.Forms.TextBox tbCrossover;
        private System.Windows.Forms.TextBox tbMutation;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbWidth;

    }
}


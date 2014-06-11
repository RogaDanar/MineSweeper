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
            this.lblAvgValue = new System.Windows.Forms.Label();
            this.lblBestValue = new System.Windows.Forms.Label();
            this.lblGenValue = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.btnFast = new System.Windows.Forms.Button();
            this.pbGraph = new System.Windows.Forms.PictureBox();
            this.tbSweepers = new System.Windows.Forms.TextBox();
            this.tbMine = new System.Windows.Forms.TextBox();
            this.lblSweepers = new System.Windows.Forms.Label();
            this.lblMines = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).BeginInit();
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
            this.btnStartStop.Location = new System.Drawing.Point(404, 88);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(118, 23);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStopClick);
            // 
            // pnlStats
            // 
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
            this.pnlStats.Location = new System.Drawing.Point(404, 414);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(130, 190);
            this.pnlStats.TabIndex = 4;
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
            // btnFast
            // 
            this.btnFast.Location = new System.Drawing.Point(3, 155);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(118, 23);
            this.btnFast.TabIndex = 15;
            this.btnFast.Text = "Fast";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFastClick);
            // 
            // pbGraph
            // 
            this.pbGraph.BackColor = System.Drawing.Color.White;
            this.pbGraph.Location = new System.Drawing.Point(-2, 414);
            this.pbGraph.Name = "pbGraph";
            this.pbGraph.Size = new System.Drawing.Size(400, 190);
            this.pbGraph.TabIndex = 5;
            this.pbGraph.TabStop = false;
            // 
            // tbSweepers
            // 
            this.tbSweepers.Location = new System.Drawing.Point(495, 12);
            this.tbSweepers.Name = "tbSweepers";
            this.tbSweepers.Size = new System.Drawing.Size(27, 20);
            this.tbSweepers.TabIndex = 16;
            this.tbSweepers.Text = "30";
            // 
            // tbMine
            // 
            this.tbMine.Location = new System.Drawing.Point(495, 38);
            this.tbMine.Name = "tbMine";
            this.tbMine.Size = new System.Drawing.Size(27, 20);
            this.tbMine.TabIndex = 17;
            this.tbMine.Text = "40";
            // 
            // lblSweepers
            // 
            this.lblSweepers.AutoSize = true;
            this.lblSweepers.Location = new System.Drawing.Point(430, 15);
            this.lblSweepers.Name = "lblSweepers";
            this.lblSweepers.Size = new System.Drawing.Size(59, 13);
            this.lblSweepers.TabIndex = 15;
            this.lblSweepers.Text = "Sweeper #";
            // 
            // lblMines
            // 
            this.lblMines.AutoSize = true;
            this.lblMines.Location = new System.Drawing.Point(449, 41);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(40, 13);
            this.lblMines.TabIndex = 18;
            this.lblMines.Text = "Mine #";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(404, 64);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "(Re)set values";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnResetClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 604);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblMines);
            this.Controls.Add(this.lblSweepers);
            this.Controls.Add(this.tbMine);
            this.Controls.Add(this.tbSweepers);
            this.Controls.Add(this.pbGraph);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.btnStartStop);
            this.Name = "Main";
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
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
        private System.Windows.Forms.PictureBox pbGraph;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.TextBox tbSweepers;
        private System.Windows.Forms.TextBox tbMine;
        private System.Windows.Forms.Label lblSweepers;
        private System.Windows.Forms.Label lblMines;
        private System.Windows.Forms.Button btnReset;

    }
}


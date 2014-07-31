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
            this.pgMain = new MineSweeper.Controls.Playground();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.statsGeneration = new MineSweeper.Controls.Stats();
            this.btnFast = new System.Windows.Forms.Button();
            this.graphPopulation = new MineSweeper.Controls.Graph();
            this.pnlSettings = new MineSweeper.Controls.Settings();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pgMain)).BeginInit();
            this.statsGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgMain
            // 
            this.pgMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pgMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pgMain.Location = new System.Drawing.Point(12, 13);
            this.pgMain.Name = "pgMain";
            this.pgMain.Size = new System.Drawing.Size(400, 400);
            this.pgMain.TabIndex = 0;
            this.pgMain.TabStop = false;
            // 
            // btnStartStop
            // 
            this.btnStartStop.ForeColor = System.Drawing.Color.Black;
            this.btnStartStop.Location = new System.Drawing.Point(-1, -2);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(124, 25);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStopClick);
            // 
            // statsGeneration
            // 
            this.statsGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statsGeneration.Controls.Add(this.btnFast);
            this.statsGeneration.Location = new System.Drawing.Point(418, 426);
            this.statsGeneration.Name = "statsGeneration";
            this.statsGeneration.Size = new System.Drawing.Size(130, 204);
            this.statsGeneration.TabIndex = 29;
            // 
            // btnFast
            // 
            this.btnFast.ForeColor = System.Drawing.Color.Black;
            this.btnFast.Location = new System.Drawing.Point(-1, 180);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(124, 25);
            this.btnFast.TabIndex = 15;
            this.btnFast.Text = "Fast";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFastClick);
            // 
            // graphPopulation
            // 
            this.graphPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.graphPopulation.BackColor = System.Drawing.Color.Gainsboro;
            this.graphPopulation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPopulation.Location = new System.Drawing.Point(12, 425);
            this.graphPopulation.Name = "graphPopulation";
            this.graphPopulation.Size = new System.Drawing.Size(400, 204);
            this.graphPopulation.TabIndex = 5;
            this.graphPopulation.TabStop = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnStartStop);
            this.pnlSettings.Location = new System.Drawing.Point(418, 14);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(130, 400);
            this.pnlSettings.TabIndex = 28;
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(-1, 376);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 25);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "(Re)set values";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnResetClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(548, 642);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.statsGeneration);
            this.Controls.Add(this.pgMain);
            this.Controls.Add(this.graphPopulation);
            this.Font = new System.Drawing.Font("DengXian", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gold;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pgMain)).EndInit();
            this.statsGeneration.ResumeLayout(false);
            this.statsGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MineSweeper.Controls.Playground pgMain;
        private MineSweeper.Controls.Graph graphPopulation;
        private System.Windows.Forms.Button btnStartStop;
        private MineSweeper.Controls.Stats statsGeneration;
        private MineSweeper.Controls.Settings pnlSettings;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnReset;

    }
}


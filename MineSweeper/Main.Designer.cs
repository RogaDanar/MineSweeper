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
            this.graphPopulation = new MineSweeper.Controls.Graph();
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
            this.lblElites = new System.Windows.Forms.Label();
            this.tbElites = new System.Windows.Forms.TextBox();
            this.tbHiddenNeuron = new System.Windows.Forms.TextBox();
            this.lblHiddenNeuron = new System.Windows.Forms.Label();
            this.tbHiddenLayer = new System.Windows.Forms.TextBox();
            this.lblHiddenLayers = new System.Windows.Forms.Label();
            this.lblTitleField = new System.Windows.Forms.Label();
            this.lblTitleGenetics = new System.Windows.Forms.Label();
            this.lblTitleBrain = new System.Windows.Forms.Label();
            this.lblTitleUnits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMain.Location = new System.Drawing.Point(12, 13);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(400, 400);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.ForeColor = System.Drawing.Color.Black;
            this.lblGeneration.Location = new System.Drawing.Point(3, 2);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(73, 14);
            this.lblGeneration.TabIndex = 1;
            this.lblGeneration.Text = "Generation";
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
            this.pnlStats.Location = new System.Drawing.Point(418, 426);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(130, 204);
            this.pnlStats.TabIndex = 29;
            // 
            // lblLastWorst
            // 
            this.lblLastWorst.AutoSize = true;
            this.lblLastWorst.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastWorst.Location = new System.Drawing.Point(77, 76);
            this.lblLastWorst.Name = "lblLastWorst";
            this.lblLastWorst.Size = new System.Drawing.Size(22, 14);
            this.lblLastWorst.TabIndex = 14;
            this.lblLastWorst.Text = "(0)";
            // 
            // lblWorstValue
            // 
            this.lblWorstValue.AutoSize = true;
            this.lblWorstValue.ForeColor = System.Drawing.Color.Maroon;
            this.lblWorstValue.Location = new System.Drawing.Point(44, 76);
            this.lblWorstValue.Name = "lblWorstValue";
            this.lblWorstValue.Size = new System.Drawing.Size(14, 14);
            this.lblWorstValue.TabIndex = 13;
            this.lblWorstValue.Text = "0";
            // 
            // lblWorst
            // 
            this.lblWorst.AutoSize = true;
            this.lblWorst.ForeColor = System.Drawing.Color.Maroon;
            this.lblWorst.Location = new System.Drawing.Point(3, 76);
            this.lblWorst.Name = "lblWorst";
            this.lblWorst.Size = new System.Drawing.Size(43, 14);
            this.lblWorst.TabIndex = 12;
            this.lblWorst.Text = "Worst";
            // 
            // lblLastAvg
            // 
            this.lblLastAvg.AutoSize = true;
            this.lblLastAvg.ForeColor = System.Drawing.Color.Black;
            this.lblLastAvg.Location = new System.Drawing.Point(77, 51);
            this.lblLastAvg.Name = "lblLastAvg";
            this.lblLastAvg.Size = new System.Drawing.Size(22, 14);
            this.lblLastAvg.TabIndex = 11;
            this.lblLastAvg.Text = "(0)";
            // 
            // lblLastBest
            // 
            this.lblLastBest.AutoSize = true;
            this.lblLastBest.ForeColor = System.Drawing.Color.Blue;
            this.lblLastBest.Location = new System.Drawing.Point(77, 28);
            this.lblLastBest.Name = "lblLastBest";
            this.lblLastBest.Size = new System.Drawing.Size(22, 14);
            this.lblLastBest.TabIndex = 10;
            this.lblLastBest.Text = "(0)";
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
            // lblAvgValue
            // 
            this.lblAvgValue.AutoSize = true;
            this.lblAvgValue.ForeColor = System.Drawing.Color.Black;
            this.lblAvgValue.Location = new System.Drawing.Point(44, 51);
            this.lblAvgValue.Name = "lblAvgValue";
            this.lblAvgValue.Size = new System.Drawing.Size(14, 14);
            this.lblAvgValue.TabIndex = 8;
            this.lblAvgValue.Text = "0";
            // 
            // lblBestValue
            // 
            this.lblBestValue.AutoSize = true;
            this.lblBestValue.ForeColor = System.Drawing.Color.Blue;
            this.lblBestValue.Location = new System.Drawing.Point(44, 28);
            this.lblBestValue.Name = "lblBestValue";
            this.lblBestValue.Size = new System.Drawing.Size(14, 14);
            this.lblBestValue.TabIndex = 7;
            this.lblBestValue.Text = "0";
            // 
            // lblGenValue
            // 
            this.lblGenValue.AutoSize = true;
            this.lblGenValue.ForeColor = System.Drawing.Color.Black;
            this.lblGenValue.Location = new System.Drawing.Point(76, 2);
            this.lblGenValue.Name = "lblGenValue";
            this.lblGenValue.Size = new System.Drawing.Size(14, 14);
            this.lblGenValue.TabIndex = 6;
            this.lblGenValue.Text = "0";
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.ForeColor = System.Drawing.Color.Black;
            this.lblAvg.Location = new System.Drawing.Point(3, 51);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(34, 14);
            this.lblAvg.TabIndex = 5;
            this.lblAvg.Text = "Avg.";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.ForeColor = System.Drawing.Color.Blue;
            this.lblBest.Location = new System.Drawing.Point(3, 28);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(33, 14);
            this.lblBest.TabIndex = 4;
            this.lblBest.Text = "Best";
            // 
            // graphPopulation
            // 
            this.graphPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.graphPopulation.BackColor = System.Drawing.Color.Gainsboro;
            this.graphPopulation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPopulation.Location = new System.Drawing.Point(12, 425);
            this.graphPopulation.Name = "pbGraph";
            this.graphPopulation.Size = new System.Drawing.Size(400, 204);
            this.graphPopulation.TabIndex = 5;
            this.graphPopulation.TabStop = false;
            // 
            // tbSweepers
            // 
            this.tbSweepers.Location = new System.Drawing.Point(92, 323);
            this.tbSweepers.Name = "tbSweepers";
            this.tbSweepers.Size = new System.Drawing.Size(30, 21);
            this.tbSweepers.TabIndex = 16;
            this.tbSweepers.Text = "30";
            this.tbSweepers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMine
            // 
            this.tbMine.Location = new System.Drawing.Point(92, 348);
            this.tbMine.Name = "tbMine";
            this.tbMine.Size = new System.Drawing.Size(30, 21);
            this.tbMine.TabIndex = 17;
            this.tbMine.Text = "40";
            this.tbMine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSweepers
            // 
            this.lblSweepers.AutoSize = true;
            this.lblSweepers.Location = new System.Drawing.Point(9, 326);
            this.lblSweepers.Name = "lblSweepers";
            this.lblSweepers.Size = new System.Drawing.Size(63, 14);
            this.lblSweepers.TabIndex = 15;
            this.lblSweepers.Text = "Sweepers";
            // 
            // lblMines
            // 
            this.lblMines.AutoSize = true;
            this.lblMines.Location = new System.Drawing.Point(30, 351);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(42, 14);
            this.lblMines.TabIndex = 18;
            this.lblMines.Text = "Mines";
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
            // lblTicks
            // 
            this.lblTicks.AutoSize = true;
            this.lblTicks.Location = new System.Drawing.Point(37, 112);
            this.lblTicks.Name = "lblTicks";
            this.lblTicks.Size = new System.Drawing.Size(36, 14);
            this.lblTicks.TabIndex = 23;
            this.lblTicks.Text = "Ticks";
            // 
            // lblPerturb
            // 
            this.lblPerturb.AutoSize = true;
            this.lblPerturb.Location = new System.Drawing.Point(9, 184);
            this.lblPerturb.Name = "lblPerturb";
            this.lblPerturb.Size = new System.Drawing.Size(64, 14);
            this.lblPerturb.TabIndex = 20;
            this.lblPerturb.Text = "Max pert.";
            // 
            // tbTicks
            // 
            this.tbTicks.Location = new System.Drawing.Point(81, 109);
            this.tbTicks.Name = "tbTicks";
            this.tbTicks.Size = new System.Drawing.Size(42, 21);
            this.tbTicks.TabIndex = 22;
            this.tbTicks.Text = "2000";
            this.tbTicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPerturb
            // 
            this.tbPerturb.Location = new System.Drawing.Point(93, 181);
            this.tbPerturb.Name = "tbPerturb";
            this.tbPerturb.Size = new System.Drawing.Size(30, 21);
            this.tbPerturb.TabIndex = 21;
            this.tbPerturb.Text = "0.3";
            this.tbPerturb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCrossover
            // 
            this.lblCrossover.AutoSize = true;
            this.lblCrossover.Location = new System.Drawing.Point(1, 160);
            this.lblCrossover.Name = "lblCrossover";
            this.lblCrossover.Size = new System.Drawing.Size(72, 14);
            this.lblCrossover.TabIndex = 27;
            this.lblCrossover.Text = "Cross. rate";
            // 
            // lblMutation
            // 
            this.lblMutation.AutoSize = true;
            this.lblMutation.Location = new System.Drawing.Point(11, 136);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(62, 14);
            this.lblMutation.TabIndex = 24;
            this.lblMutation.Text = "Mut. rate";
            // 
            // tbCrossover
            // 
            this.tbCrossover.Location = new System.Drawing.Point(93, 157);
            this.tbCrossover.Name = "tbCrossover";
            this.tbCrossover.Size = new System.Drawing.Size(30, 21);
            this.tbCrossover.TabIndex = 26;
            this.tbCrossover.Text = "0.7";
            this.tbCrossover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMutation
            // 
            this.tbMutation.Location = new System.Drawing.Point(93, 133);
            this.tbMutation.Name = "tbMutation";
            this.tbMutation.Size = new System.Drawing.Size(30, 21);
            this.tbMutation.TabIndex = 25;
            this.tbMutation.Text = "0.1";
            this.tbMutation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.Controls.Add(this.lblTitleUnits);
            this.pnlSettings.Controls.Add(this.lblTitleBrain);
            this.pnlSettings.Controls.Add(this.lblTitleGenetics);
            this.pnlSettings.Controls.Add(this.lblTitleField);
            this.pnlSettings.Controls.Add(this.tbHiddenLayer);
            this.pnlSettings.Controls.Add(this.lblHiddenLayers);
            this.pnlSettings.Controls.Add(this.tbHiddenNeuron);
            this.pnlSettings.Controls.Add(this.lblHiddenNeuron);
            this.pnlSettings.Controls.Add(this.lblElites);
            this.pnlSettings.Controls.Add(this.tbElites);
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
            this.pnlSettings.Location = new System.Drawing.Point(418, 14);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(130, 400);
            this.pnlSettings.TabIndex = 28;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(26, 69);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(47, 14);
            this.lblHeight.TabIndex = 31;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(30, 44);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(43, 14);
            this.lblWidth.TabIndex = 28;
            this.lblWidth.Text = "Width";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(91, 66);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(32, 21);
            this.tbHeight.TabIndex = 30;
            this.tbHeight.Text = "400";
            this.tbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(91, 41);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(32, 21);
            this.tbWidth.TabIndex = 29;
            this.tbWidth.Text = "400";
            this.tbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblElites
            // 
            this.lblElites.AutoSize = true;
            this.lblElites.Location = new System.Drawing.Point(33, 208);
            this.lblElites.Name = "lblElites";
            this.lblElites.Size = new System.Drawing.Size(40, 14);
            this.lblElites.TabIndex = 32;
            this.lblElites.Text = "Elites";
            // 
            // tbElites
            // 
            this.tbElites.Location = new System.Drawing.Point(93, 205);
            this.tbElites.Name = "tbElites";
            this.tbElites.Size = new System.Drawing.Size(30, 21);
            this.tbElites.TabIndex = 33;
            this.tbElites.Text = "4";
            this.tbElites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbHiddenNeuron
            // 
            this.tbHiddenNeuron.Location = new System.Drawing.Point(93, 278);
            this.tbHiddenNeuron.Name = "tbHiddenNeuron";
            this.tbHiddenNeuron.Size = new System.Drawing.Size(30, 21);
            this.tbHiddenNeuron.TabIndex = 35;
            this.tbHiddenNeuron.Text = "6";
            this.tbHiddenNeuron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHiddenNeuron
            // 
            this.lblHiddenNeuron.AutoSize = true;
            this.lblHiddenNeuron.Location = new System.Drawing.Point(11, 281);
            this.lblHiddenNeuron.Name = "lblHiddenNeuron";
            this.lblHiddenNeuron.Size = new System.Drawing.Size(56, 14);
            this.lblHiddenNeuron.TabIndex = 34;
            this.lblHiddenNeuron.Text = "Neurons";
            // 
            // tbHiddenLayer
            // 
            this.tbHiddenLayer.Location = new System.Drawing.Point(93, 253);
            this.tbHiddenLayer.Name = "tbHiddenLayer";
            this.tbHiddenLayer.Size = new System.Drawing.Size(30, 21);
            this.tbHiddenLayer.TabIndex = 37;
            this.tbHiddenLayer.Text = "1";
            this.tbHiddenLayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHiddenLayers
            // 
            this.lblHiddenLayers.AutoSize = true;
            this.lblHiddenLayers.Location = new System.Drawing.Point(26, 256);
            this.lblHiddenLayers.Name = "lblHiddenLayers";
            this.lblHiddenLayers.Size = new System.Drawing.Size(44, 14);
            this.lblHiddenLayers.TabIndex = 36;
            this.lblHiddenLayers.Text = "Layers";
            // 
            // lblTitleField
            // 
            this.lblTitleField.AutoSize = true;
            this.lblTitleField.ForeColor = System.Drawing.Color.Black;
            this.lblTitleField.Location = new System.Drawing.Point(39, 26);
            this.lblTitleField.Name = "lblTitleField";
            this.lblTitleField.Size = new System.Drawing.Size(37, 14);
            this.lblTitleField.TabIndex = 38;
            this.lblTitleField.Text = "Field";
            // 
            // lblTitleGenetics
            // 
            this.lblTitleGenetics.AutoSize = true;
            this.lblTitleGenetics.ForeColor = System.Drawing.Color.Black;
            this.lblTitleGenetics.Location = new System.Drawing.Point(28, 90);
            this.lblTitleGenetics.Name = "lblTitleGenetics";
            this.lblTitleGenetics.Size = new System.Drawing.Size(58, 14);
            this.lblTitleGenetics.TabIndex = 39;
            this.lblTitleGenetics.Text = "Genetics";
            // 
            // lblTitleBrain
            // 
            this.lblTitleBrain.AutoSize = true;
            this.lblTitleBrain.ForeColor = System.Drawing.Color.Black;
            this.lblTitleBrain.Location = new System.Drawing.Point(16, 233);
            this.lblTitleBrain.Name = "lblTitleBrain";
            this.lblTitleBrain.Size = new System.Drawing.Size(92, 14);
            this.lblTitleBrain.TabIndex = 40;
            this.lblTitleBrain.Text = "Sweeper brain";
            // 
            // lblTitleUnits
            // 
            this.lblTitleUnits.AutoSize = true;
            this.lblTitleUnits.ForeColor = System.Drawing.Color.Black;
            this.lblTitleUnits.Location = new System.Drawing.Point(44, 303);
            this.lblTitleUnits.Name = "lblTitleUnits";
            this.lblTitleUnits.Size = new System.Drawing.Size(38, 14);
            this.lblTitleUnits.TabIndex = 41;
            this.lblTitleUnits.Text = "Units";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(548, 642);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.graphPopulation);
            this.Font = new System.Drawing.Font("DengXian", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gold;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private MineSweeper.Controls.Graph graphPopulation;
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
        private System.Windows.Forms.Label lblElites;
        private System.Windows.Forms.TextBox tbElites;
        private System.Windows.Forms.TextBox tbHiddenLayer;
        private System.Windows.Forms.Label lblHiddenLayers;
        private System.Windows.Forms.TextBox tbHiddenNeuron;
        private System.Windows.Forms.Label lblHiddenNeuron;
        private System.Windows.Forms.Label lblTitleUnits;
        private System.Windows.Forms.Label lblTitleBrain;
        private System.Windows.Forms.Label lblTitleGenetics;
        private System.Windows.Forms.Label lblTitleField;

    }
}


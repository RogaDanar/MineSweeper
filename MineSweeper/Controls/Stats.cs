namespace MineSweeper.Controls
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using MineSweeper.Specs;
    using NeuralNet.Genetics;

    public class Stats : Panel
    {
        private Label lblLastAvg;
        private Label lblLastBest;
        private Label lblAvgValue;
        private Label lblBestValue;
        private Label lblGenValue;
        private Label lblAvg;
        private Label lblBest;
        private Label lblLastWorst;
        private Label lblWorstValue;
        private Label lblWorst;
        private Label lblGeneration;

        private Color _worstColor;
        private Color _bestColor;
        private Color _neutralColor;

        public Stats()
        {
            lblLastWorst = new Label();
            lblWorstValue = new Label();
            lblWorst = new Label();
            lblLastAvg = new Label();
            lblLastBest = new Label();
            lblAvgValue = new Label();
            lblBestValue = new Label();
            lblGenValue = new Label();
            lblAvg = new Label();
            lblBest = new Label();
            lblGeneration = new Label();

            Controls.Add(lblLastWorst);
            Controls.Add(lblWorstValue);
            Controls.Add(lblWorst);
            Controls.Add(lblLastAvg);
            Controls.Add(lblLastBest);
            Controls.Add(lblAvgValue);
            Controls.Add(lblBestValue);
            Controls.Add(lblGenValue);
            Controls.Add(lblAvg);
            Controls.Add(lblBest);
            Controls.Add(lblGeneration);
        }

        private void setupLabels()
        {
            // 
            // lblLastWorst
            // 
            lblLastWorst.AutoSize = true;
            lblLastWorst.ForeColor = _worstColor;
            lblLastWorst.Location = new Point(77, 76);
            lblLastWorst.Name = "lblLastWorst";
            lblLastWorst.Size = new Size(22, 14);
            lblLastWorst.TabIndex = 14;
            lblLastWorst.Text = "(0)";
            // 
            // lblWorstValue
            // 
            lblWorstValue.AutoSize = true;
            lblWorstValue.ForeColor = _worstColor;
            lblWorstValue.Location = new Point(44, 76);
            lblWorstValue.Name = "lblWorstValue";
            lblWorstValue.Size = new Size(14, 14);
            lblWorstValue.TabIndex = 13;
            lblWorstValue.Text = "0";
            // 
            // lblWorst
            // 
            lblWorst.AutoSize = true;
            lblWorst.ForeColor = _worstColor;
            lblWorst.Location = new Point(3, 76);
            lblWorst.Name = "lblWorst";
            lblWorst.Size = new Size(43, 14);
            lblWorst.TabIndex = 12;
            lblWorst.Text = "Worst";
            // 
            // lblLastAvg
            // 
            lblLastAvg.AutoSize = true;
            lblLastAvg.ForeColor = _neutralColor;
            lblLastAvg.Location = new Point(77, 51);
            lblLastAvg.Name = "lblLastAvg";
            lblLastAvg.Size = new Size(22, 14);
            lblLastAvg.TabIndex = 11;
            lblLastAvg.Text = "(0)";
            // 
            // lblLastBest
            // 
            lblLastBest.AutoSize = true;
            lblLastBest.ForeColor = _bestColor;
            lblLastBest.Location = new Point(77, 28);
            lblLastBest.Name = "lblLastBest";
            lblLastBest.Size = new Size(22, 14);
            lblLastBest.TabIndex = 10;
            lblLastBest.Text = "(0)";
            // 
            // lblAvgValue
            // 
            lblAvgValue.AutoSize = true;
            lblAvgValue.ForeColor = _neutralColor;
            lblAvgValue.Location = new Point(44, 51);
            lblAvgValue.Name = "lblAvgValue";
            lblAvgValue.Size = new Size(14, 14);
            lblAvgValue.TabIndex = 8;
            lblAvgValue.Text = "0";
            // 
            // lblBestValue
            // 
            lblBestValue.AutoSize = true;
            lblBestValue.ForeColor = _bestColor;
            lblBestValue.Location = new Point(44, 28);
            lblBestValue.Name = "lblBestValue";
            lblBestValue.Size = new Size(14, 14);
            lblBestValue.TabIndex = 7;
            lblBestValue.Text = "0";
            // 
            // lblGenValue
            // 
            lblGenValue.AutoSize = true;
            lblGenValue.ForeColor = _neutralColor;
            lblGenValue.Location = new Point(76, 2);
            lblGenValue.Name = "lblGenValue";
            lblGenValue.Size = new Size(14, 14);
            lblGenValue.TabIndex = 6;
            lblGenValue.Text = "0";
            // 
            // lblAvg
            // 
            lblAvg.AutoSize = true;
            lblAvg.ForeColor = _neutralColor;
            lblAvg.Location = new Point(3, 51);
            lblAvg.Name = "lblAvg";
            lblAvg.Size = new Size(34, 14);
            lblAvg.TabIndex = 5;
            lblAvg.Text = "Avg.";
            // 
            // lblBest
            // 
            lblBest.AutoSize = true;
            lblBest.ForeColor = _bestColor;
            lblBest.Location = new Point(3, 28);
            lblBest.Name = "lblBest";
            lblBest.Size = new Size(33, 14);
            lblBest.TabIndex = 4;
            lblBest.Text = "Best";
            // 
            // lblGeneration
            // 
            lblGeneration.AutoSize = true;
            lblGeneration.ForeColor = _neutralColor;
            lblGeneration.Location = new Point(3, 2);
            lblGeneration.Name = "lblGeneration";
            lblGeneration.Size = new Size(73, 14);
            lblGeneration.TabIndex = 1;
            lblGeneration.Text = "Generation";
        }

        public void Reset(MineSweeperSettings settings)
        {
            _worstColor = settings.WorstColor;
            _bestColor = settings.BestColor;
            _neutralColor = settings.NeutralColor;
            setupLabels();
            lblAvgValue.Text = "0";
            lblWorstValue.Text = "0";
            lblBestValue.Text = "0";
            lblLastAvg.Text = "(0.00)";
            lblLastWorst.Text = "(0)";
            lblLastBest.Text = "(0)";
        }

        internal void Update(Population population)
        {
            lblGenValue.Text = population.Generation.ToString();
            lblBestValue.Text = population.FitnessStats.Best.ToString();
            lblWorstValue.Text = population.FitnessStats.Worst.ToString();
            lblAvgValue.Text = Math.Round(population.FitnessStats.Average, 2).ToString("0.00");

            lblLastBest.Text = string.Format("({0})", population.FitnessStats.PreviousGenerationsBest.LastOrDefault());
            lblLastWorst.Text = string.Format("({0})", population.FitnessStats.PreviousGenerationsWorst.LastOrDefault());
            lblLastAvg.Text = string.Format("({0:0.00})", Math.Round(population.FitnessStats.PreviousGenerationsAverage.LastOrDefault(), 2));
        }
    }
}

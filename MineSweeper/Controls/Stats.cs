namespace MineSweeper.Controls
{
    using NeuralNet.Genetics;
    using System;
    using System.Linq;
    using System.Windows.Forms;

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

            // 
            // lblLastWorst
            // 
            lblLastWorst.AutoSize = true;
            lblLastWorst.ForeColor = System.Drawing.Color.Maroon;
            lblLastWorst.Location = new System.Drawing.Point(77, 76);
            lblLastWorst.Name = "lblLastWorst";
            lblLastWorst.Size = new System.Drawing.Size(22, 14);
            lblLastWorst.TabIndex = 14;
            lblLastWorst.Text = "(0)";
            // 
            // lblWorstValue
            // 
            lblWorstValue.AutoSize = true;
            lblWorstValue.ForeColor = System.Drawing.Color.Maroon;
            lblWorstValue.Location = new System.Drawing.Point(44, 76);
            lblWorstValue.Name = "lblWorstValue";
            lblWorstValue.Size = new System.Drawing.Size(14, 14);
            lblWorstValue.TabIndex = 13;
            lblWorstValue.Text = "0";
            // 
            // lblWorst
            // 
            lblWorst.AutoSize = true;
            lblWorst.ForeColor = System.Drawing.Color.Maroon;
            lblWorst.Location = new System.Drawing.Point(3, 76);
            lblWorst.Name = "lblWorst";
            lblWorst.Size = new System.Drawing.Size(43, 14);
            lblWorst.TabIndex = 12;
            lblWorst.Text = "Worst";
            // 
            // lblLastAvg
            // 
            lblLastAvg.AutoSize = true;
            lblLastAvg.ForeColor = System.Drawing.Color.Black;
            lblLastAvg.Location = new System.Drawing.Point(77, 51);
            lblLastAvg.Name = "lblLastAvg";
            lblLastAvg.Size = new System.Drawing.Size(22, 14);
            lblLastAvg.TabIndex = 11;
            lblLastAvg.Text = "(0)";
            // 
            // lblLastBest
            // 
            lblLastBest.AutoSize = true;
            lblLastBest.ForeColor = System.Drawing.Color.Blue;
            lblLastBest.Location = new System.Drawing.Point(77, 28);
            lblLastBest.Name = "lblLastBest";
            lblLastBest.Size = new System.Drawing.Size(22, 14);
            lblLastBest.TabIndex = 10;
            lblLastBest.Text = "(0)";
            // 
            // lblAvgValue
            // 
            lblAvgValue.AutoSize = true;
            lblAvgValue.ForeColor = System.Drawing.Color.Black;
            lblAvgValue.Location = new System.Drawing.Point(44, 51);
            lblAvgValue.Name = "lblAvgValue";
            lblAvgValue.Size = new System.Drawing.Size(14, 14);
            lblAvgValue.TabIndex = 8;
            lblAvgValue.Text = "0";
            // 
            // lblBestValue
            // 
            lblBestValue.AutoSize = true;
            lblBestValue.ForeColor = System.Drawing.Color.Blue;
            lblBestValue.Location = new System.Drawing.Point(44, 28);
            lblBestValue.Name = "lblBestValue";
            lblBestValue.Size = new System.Drawing.Size(14, 14);
            lblBestValue.TabIndex = 7;
            lblBestValue.Text = "0";
            // 
            // lblGenValue
            // 
            lblGenValue.AutoSize = true;
            lblGenValue.ForeColor = System.Drawing.Color.Black;
            lblGenValue.Location = new System.Drawing.Point(76, 2);
            lblGenValue.Name = "lblGenValue";
            lblGenValue.Size = new System.Drawing.Size(14, 14);
            lblGenValue.TabIndex = 6;
            lblGenValue.Text = "0";
            // 
            // lblAvg
            // 
            lblAvg.AutoSize = true;
            lblAvg.ForeColor = System.Drawing.Color.Black;
            lblAvg.Location = new System.Drawing.Point(3, 51);
            lblAvg.Name = "lblAvg";
            lblAvg.Size = new System.Drawing.Size(34, 14);
            lblAvg.TabIndex = 5;
            lblAvg.Text = "Avg.";
            // 
            // lblBest
            // 
            lblBest.AutoSize = true;
            lblBest.ForeColor = System.Drawing.Color.Blue;
            lblBest.Location = new System.Drawing.Point(3, 28);
            lblBest.Name = "lblBest";
            lblBest.Size = new System.Drawing.Size(33, 14);
            lblBest.TabIndex = 4;
            lblBest.Text = "Best";
            // 
            // lblGeneration
            // 
            lblGeneration.AutoSize = true;
            lblGeneration.ForeColor = System.Drawing.Color.Black;
            lblGeneration.Location = new System.Drawing.Point(3, 2);
            lblGeneration.Name = "lblGeneration";
            lblGeneration.Size = new System.Drawing.Size(73, 14);
            lblGeneration.TabIndex = 1;
            lblGeneration.Text = "Generation";

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

        internal void Update(Population population)
        {
            lblGenValue.Text = population.Generation.ToString();
            lblBestValue.Text = population.BestFitness.ToString();
            lblWorstValue.Text = population.WorstFitness.ToString();
            lblAvgValue.Text = Math.Round(population.AverageFitness, 2).ToString("0.00");

            lblLastBest.Text = string.Format("({0})", population.PreviousGenerationBestFitness.LastOrDefault());
            lblLastWorst.Text = string.Format("({0})", population.PreviousGenerationWorstFitness.LastOrDefault());
            lblLastAvg.Text = string.Format("({0:0.00})", Math.Round(population.PreviousGenerationAverageFitness.LastOrDefault(), 2));
        }
    }
}

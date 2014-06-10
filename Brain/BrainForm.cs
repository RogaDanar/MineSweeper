namespace Brainspace
{
    using Brainspace.Helpers;
    using NeuralNet.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class BrainForm : Form
    {
        private readonly Rand _rand = Rand.Generator;

        public Brain brain { get; private set; }

        public BrainForm()
        {
            InitializeComponent();
            brain = new Brain();
        }

        private void btnShowClick(object sender, EventArgs e)
        {
            var inputs = new List<InputGoal> 
            { 
                Numbers.Zero(),
                Numbers.One(),
                Numbers.Two(),
                Numbers.Three(),
                Numbers.Four()
            };

            brain.Show(inputs);
            lblFitness.Text = brain.Fitness.ToString();
            brain.Tick();
        }

        private void btnZeroClick(object sender, EventArgs e)
        {
            var result = brain.Show(Numbers.Zero());
            brain.Tick();
            lblFitness.Text = brain.Fitness.ToString();
            lblResult.Text = string.Join(", ", result.Select(x => Math.Round(x, 1)));
        }
    }
}

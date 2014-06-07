namespace Brainspace
{
    using Brainspace.Helpers;
    using Brainspace.Models;
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

        private void btnZeroClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 0, 0, 0 });
            activate(Numbers.Zero());
        }

        private void btnOneClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 0, 0, 1 });
            activate(Numbers.One());
        }

        private void btnTwoClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 0, 1, 0 });
            activate(Numbers.Two());
        }

        private void btnThreeClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 0, 1, 1 });
            activate(Numbers.Three());
        }

        private void btnFourClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 1, 0, 0 });
            activate(Numbers.Four());
        }

        private void activate(IList<double> input)
        {
            var result = brain.Show(input);
            lblResult.Text = string.Join(", ", result.Select(x => Math.Round(x, 1)));
            lblFitness.Text = brain.Fitness.ToString();
            lblMature.Text = brain.Mature.ToString();
        }
    }
}

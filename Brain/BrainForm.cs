namespace Brainspace
{
    using Brainspace.Helpers;
    using Brainspace.Models;
    using System;
    using System.Collections.Generic;
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

        private void btnActivateClick(object sender, EventArgs e)
        {
            brain.Setup(new List<double> { 0, 0, 0 });
            var result = brain.Show(Numbers.Zero());
            lblResult.Text = string.Join(", ", result) + ": " + brain.Mature;
        }
    }
}

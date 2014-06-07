namespace Brainspace
{
    using Brainspace.Models;
    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Linq;

    public partial class BrainForm : Form
    {
        public Brain brain { get; private set; }

        public BrainForm()
        {
            InitializeComponent();
            var network = new FeedforwardNetwork(100, 5, 2, 50);
            brain = new Brain(network);
        }

        private void btnActivateClick(object sender, EventArgs e)
        {
            var result = brain.Show(Enumerable.Range(0, 100).ToDictionary(x => x, x => x));
            lblResult.Text = string.Join(", ", result.Select(x => x.Value.ToString()));
        }

        private void btnDeactivateClick(object sender, System.EventArgs e)
        {
            brain.Sleep();
        }
    }
}

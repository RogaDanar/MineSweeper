namespace Brainspace
{
    using Brainspace.Models;
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class BrainForm : Form
    {
        const int NUM_OF_NEURONS = 200;

        public Brain brain { get; private set; }

        public BrainForm()
        {
            InitializeComponent();
            var network = new FeedforwardNetwork(NUM_OF_NEURONS);
            brain = new Brain(network);
            brain.Tick += brainTick;
        }

        private void brainTick(object sender, EventArgs e)
        {
            ShowResult();
        }

        private void btnActivateClick(object sender, EventArgs e)
        {
            brain.Awaken();
        }

        private void btnDeactivateClick(object sender, System.EventArgs e)
        {
            brain.Sleep();
        }

        private void ShowResult()
        {
            var builder = new StringBuilder();
            foreach (var neuron in brain.Network.Neurons)
            {
                builder.Append(neuron.NeuroTransmitterLevels[NeuroTransmitter.Dopamine].ToString());
                builder.Append(",");
            }
            var result = builder.ToString().Trim(',');
            lblResult.Text += result + Environment.NewLine;
        }
    }
}

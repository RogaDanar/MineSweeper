namespace MineSweeper.Controls
{
    using System;
    using System.Windows.Forms;
    using MineSweeper.Specs;
    using MineSweeper.Utils;

    public class Settings : Panel
    {
        public event EventHandler<SpecEventArgs> SpecChanged = delegate { };

        private ComboBox cbSpec;
        private TextBox tbSweepers;
        private TextBox tbMine;
        private Label lblSweepers;
        private Label lblMines;
        private Label lblTicks;
        private Label lblPerturb;
        private TextBox tbTicks;
        private TextBox tbPerturb;
        private Label lblCrossover;
        private Label lblMutation;
        private TextBox tbCrossover;
        private TextBox tbMutation;
        private Label lblMaxSpeed;
        private Label lblMaxRotation;
        private TextBox tbMaxSpeed;
        private TextBox tbMaxRotation;
        private Label lblHeight;
        private Label lblWidth;
        private TextBox tbHeight;
        private TextBox tbWidth;
        private Label lblElites;
        private TextBox tbElites;
        private TextBox tbHiddenLayer;
        private Label lblHiddenLayers;
        private TextBox tbHiddenNeuron;
        private Label lblHiddenNeuron;
        private Label lblTitleUnits;
        private Label lblTitleBrain;
        private Label lblTitleGenetics;
        private Label lblTitleField;

        public Settings()
        {
            initializeComponents();
        }

        public void DisplayCurrentSettings(MineSweeperSettings settings)
        {
            tbMaxSpeed.Text = settings.MaxSpeed.ToString();
            tbMaxRotation.Text = settings.MaxRotation.ToString();
            tbWidth.Text = settings.DrawWidth.ToString();
            tbHeight.Text = settings.DrawHeight.ToString();
            tbMutation.Text = settings.MutationRate.ToString();
            tbCrossover.Text = settings.CrossoverRate.ToString();
            tbPerturb.Text = settings.MaxPerturbation.ToString();
            tbTicks.Text = settings.Ticks.ToString();
            tbMine.Text = settings.MineCount.ToString();
            tbSweepers.Text = settings.SweeperCount.ToString();
            tbElites.Text = settings.EliteCount.ToString();
            tbHiddenLayer.Text = settings.HiddenLayers.ToString();
            tbHiddenNeuron.Text = settings.HiddenLayerNeurons.ToString();

            this.ForeColor = settings.BestColor;
        }

        public MineSweeperSettings GetNewSettings(MineSweeperSettings settings)
        {
            settings.SweeperCount = getIntValue(tbSweepers, settings.SweeperCount);
            settings.MineCount = getIntValue(tbMine, settings.MineCount);
            settings.MutationRate = getDoubleValue(tbMutation, settings.MutationRate);
            settings.CrossoverRate = getDoubleValue(tbCrossover, settings.CrossoverRate);
            settings.MaxPerturbation = getDoubleValue(tbPerturb, settings.MaxPerturbation);
            settings.Ticks = getIntValue(tbTicks, settings.Ticks);
            settings.EliteCount = getIntValue(tbElites, settings.EliteCount);

            settings.HiddenLayers = getIntValue(tbHiddenLayer, settings.HiddenLayers);
            settings.HiddenLayerNeurons = getIntValue(tbHiddenNeuron, settings.HiddenLayerNeurons);

            settings.DrawWidth = getIntValue(tbWidth, settings.DrawWidth);
            settings.DrawHeight = getIntValue(tbHeight, settings.DrawHeight);

            settings.MaxSpeed = getDoubleValue(tbMaxSpeed, settings.MaxSpeed);
            settings.MaxRotation = getDoubleValue(tbMaxRotation, settings.MaxRotation);

            return settings;
        }

        public void EnableSpec()
        {
            cbSpec.Enabled = true;
        }

        public void DisableSpec()
        {
            cbSpec.Enabled = false;
        }

        private void cbSpecSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbSpec.SelectedItem.ToString();
            var spec = default(IMineSweeperSpec);
            switch (selected)
            {
                case "Mine":
                    spec = new MineSweeperSpec();
                    break;

                case "EliteMine":
                    spec = new EliteMineSweeperSpec();
                    break;

                case "Dodger":
                    spec = new MineSweeperHoleDodgerSpec();
                    break;

                case "Cluster":
                    spec = new ClusterSweeperSpec();
                    break;

                case "RNNTest":
                    spec = new RecurrentSpec();
                    break;

                default:
                    break;
            }
            var eventArgs = new SpecEventArgs(spec);
            SpecChanged.Raise<SpecEventArgs>(this, eventArgs);
        }

        private int getIntValue(TextBox textBox, int originalValue)
        {
            var value = originalValue;
            int.TryParse(textBox.Text, out value);
            return value;
        }

        private double getDoubleValue(TextBox textBox, double originalValue)
        {
            var value = originalValue;
            double.TryParse(textBox.Text, out value);
            return value;
        }

        private void initializeComponents()
        {
            cbSpec = new ComboBox();
            tbSweepers = new TextBox();
            tbMine = new TextBox();
            lblSweepers = new Label();
            lblMines = new Label();
            lblTicks = new Label();
            lblPerturb = new Label();
            tbTicks = new TextBox();
            tbPerturb = new TextBox();
            lblCrossover = new Label();
            lblMutation = new Label();
            tbCrossover = new TextBox();
            lblMaxSpeed = new Label();
            tbMaxSpeed = new TextBox();
            lblMaxRotation = new Label();
            tbMaxRotation = new TextBox();
            tbMutation = new TextBox();
            lblTitleUnits = new Label();
            lblTitleBrain = new Label();
            lblTitleGenetics = new Label();
            lblTitleField = new Label();
            tbHiddenLayer = new TextBox();
            lblHiddenLayers = new Label();
            tbHiddenNeuron = new TextBox();
            lblHiddenNeuron = new Label();
            lblElites = new Label();
            tbElites = new TextBox();
            lblHeight = new Label();
            lblWidth = new Label();
            tbHeight = new TextBox();
            tbWidth = new TextBox();

            //
            // cbSpec
            //
            this.cbSpec.FormattingEnabled = true;
            this.cbSpec.Items.AddRange(new object[] {
            "Mine",
            "EliteMine",
            "Cluster",
            "Dodger",
            "RNNTest"});
            this.cbSpec.Location = new System.Drawing.Point(4, 1);
            this.cbSpec.Name = "cbSpec";
            this.cbSpec.Size = new System.Drawing.Size(121, 22);
            this.cbSpec.TabIndex = 42;
            this.cbSpec.Text = "Mine";
            this.cbSpec.SelectedIndexChanged += new System.EventHandler(this.cbSpecSelectedIndexChanged);

            //
            // tbSweepers
            //
            this.tbSweepers.Location = new System.Drawing.Point(92, 323);
            this.tbSweepers.Name = "tbSweepers";
            this.tbSweepers.Size = new System.Drawing.Size(30, 19);
            this.tbSweepers.TabIndex = 16;
            this.tbSweepers.Text = "30";
            this.tbSweepers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // tbMine
            //
            this.tbMine.Location = new System.Drawing.Point(92, 348);
            this.tbMine.Name = "tbMine";
            this.tbMine.Size = new System.Drawing.Size(30, 19);
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
            this.tbTicks.Size = new System.Drawing.Size(42, 19);
            this.tbTicks.TabIndex = 22;
            this.tbTicks.Text = "2000";
            this.tbTicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // tbPerturb
            //
            this.tbPerturb.Location = new System.Drawing.Point(93, 181);
            this.tbPerturb.Name = "tbPerturb";
            this.tbPerturb.Size = new System.Drawing.Size(30, 19);
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
            this.tbCrossover.Size = new System.Drawing.Size(30, 19);
            this.tbCrossover.TabIndex = 26;
            this.tbCrossover.Text = "0.7";
            this.tbCrossover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // tbMutation
            //
            this.tbMutation.Location = new System.Drawing.Point(93, 133);
            this.tbMutation.Name = "tbMutation";
            this.tbMutation.Size = new System.Drawing.Size(30, 19);
            this.tbMutation.TabIndex = 25;
            this.tbMutation.Text = "0.1";
            this.tbMutation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbHiddenLayer
            //
            this.tbHiddenLayer.Location = new System.Drawing.Point(93, 253);
            this.tbHiddenLayer.Name = "tbHiddenLayer";
            this.tbHiddenLayer.Size = new System.Drawing.Size(30, 19);
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
            // tbHiddenNeuron
            //
            this.tbHiddenNeuron.Location = new System.Drawing.Point(93, 278);
            this.tbHiddenNeuron.Name = "tbHiddenNeuron";
            this.tbHiddenNeuron.Size = new System.Drawing.Size(30, 19);
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
            this.tbElites.Size = new System.Drawing.Size(30, 19);
            this.tbElites.TabIndex = 33;
            this.tbElites.Text = "4";
            this.tbElites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.tbHeight.Size = new System.Drawing.Size(32, 19);
            this.tbHeight.TabIndex = 30;
            this.tbHeight.Text = "520";
            this.tbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // tbWidth
            //
            this.tbWidth.Location = new System.Drawing.Point(91, 41);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(32, 19);
            this.tbWidth.TabIndex = 29;
            this.tbWidth.Text = "640";
            this.tbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            //
            // lblMaxSpeed
            //
            this.lblMaxSpeed.AutoSize = true;
            this.lblMaxSpeed.Location = new System.Drawing.Point(0, 376);
            this.lblMaxSpeed.Name = "lblMaxSpeed";
            this.lblMaxSpeed.Size = new System.Drawing.Size(47, 14);
            this.lblMaxSpeed.TabIndex = 31;
            this.lblMaxSpeed.Text = "Max Speed";
            //
            // lblMaxRotation
            //
            this.lblMaxRotation.AutoSize = true;
            this.lblMaxRotation.Location = new System.Drawing.Point(11, 401);
            this.lblMaxRotation.Name = "lblMaxRotation";
            this.lblMaxRotation.Size = new System.Drawing.Size(43, 14);
            this.lblMaxRotation.TabIndex = 28;
            this.lblMaxRotation.Text = "Max Rot.";
            //
            // tbMaxSpeed
            //
            this.tbMaxSpeed.Location = new System.Drawing.Point(91, 373);
            this.tbMaxSpeed.Name = "tbMaxSpeed";
            this.tbMaxSpeed.Size = new System.Drawing.Size(32, 19);
            this.tbMaxSpeed.TabIndex = 30;
            this.tbMaxSpeed.Text = "1.5";
            this.tbMaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // tbMaxRotation
            //
            this.tbMaxRotation.Location = new System.Drawing.Point(91, 398);
            this.tbMaxRotation.Name = "tbMaxRotation";
            this.tbMaxRotation.Size = new System.Drawing.Size(32, 19);
            this.tbMaxRotation.TabIndex = 29;
            this.tbMaxRotation.Text = "0.5";
            this.tbMaxRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            Controls.Add(lblTitleUnits);
            Controls.Add(lblTitleBrain);
            Controls.Add(lblTitleGenetics);
            Controls.Add(lblTitleField);
            Controls.Add(tbHiddenLayer);
            Controls.Add(lblHiddenLayers);
            Controls.Add(tbHiddenNeuron);
            Controls.Add(lblHiddenNeuron);
            Controls.Add(lblElites);
            Controls.Add(tbElites);
            Controls.Add(lblHeight);
            Controls.Add(lblWidth);
            Controls.Add(tbHeight);
            Controls.Add(tbWidth);
            Controls.Add(lblCrossover);
            Controls.Add(tbSweepers);
            Controls.Add(lblMutation);
            Controls.Add(tbMine);
            Controls.Add(tbCrossover);
            Controls.Add(lblSweepers);
            Controls.Add(tbMutation);
            Controls.Add(lblMines);
            Controls.Add(lblTicks);
            Controls.Add(lblPerturb);
            Controls.Add(tbPerturb);
            Controls.Add(tbTicks);
            Controls.Add(tbMaxSpeed);
            Controls.Add(lblMaxSpeed);
            Controls.Add(tbMaxRotation);
            Controls.Add(lblMaxRotation);
            Controls.Add(cbSpec);
        }
    }
}
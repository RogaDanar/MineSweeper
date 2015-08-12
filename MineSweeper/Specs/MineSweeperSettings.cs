namespace MineSweeper.Specs
{
    using System;
    using System.Drawing;
    using MineSweeper.Creatures;
    using NeuralNet.AppHelpers;

    public class MineSweeperSettings : EventArgs, IGeneticsSettings
    {
        public Color WorstColor = Color.FromArgb(170, 105, 57);
        public Color BestColor = Color.FromArgb(137, 122, 174);
        public Color NeutralColor = Color.Black;

        public float MineSize = 2;
        public float SweeperSize = 5;
        public float TouchDistance { get { return MineSize + SweeperSize; } }

        public int Ticks { get; set; }
        public int SweeperCount { get; set; }
        public int MineCount { get; set; }
        public bool ReplaceMine { get; set; }
        public int DrawWidth { get; set; }
        public int DrawHeight { get; set; }
        public bool Fast { get; set; }

        public double MaxSpeed { get; set; }
        public double MaxRotation { get; set; }

        // IGeneticSettings
        public double MutationRate { get; set; }

        public double CrossoverRate { get; set; }
        public double MaxPerturbation { get; set; }
        public int EliteCount { get; set; }

        public int HiddenLayers { get; set; }
        public int HiddenLayerNeurons { get; set; }

        public SweeperType SweeperType { get; set; }

        private MineSweeperSettings()
        {
        }

        public static MineSweeperSettings Sweeper()
        {
            var settings = new MineSweeperSettings
            {
                Ticks = 2000,
                SweeperCount = 30,
                MineCount = 40,
                ReplaceMine = true,
                DrawWidth = 640,
                DrawHeight = 520,
                Fast = false,

                MaxSpeed = 2,
                MaxRotation = 0.5,

                MutationRate = 0.1,
                CrossoverRate = 0.7,
                MaxPerturbation = 0.3,
                EliteCount = 4,

                HiddenLayers = 1,
                HiddenLayerNeurons = 6,

                SweeperType = SweeperType.Sweeper
            };

            return settings;
        }

        public static MineSweeperSettings EliteSweeper()
        {
            var settings = new MineSweeperSettings
            {
                Ticks = 3000,
                SweeperCount = 20,
                MineCount = 30,
                ReplaceMine = true,
                DrawWidth = 640,
                DrawHeight = 520,
                Fast = false,

                MaxSpeed = 1.5,
                MaxRotation = 0.5,

                MutationRate = 0.1,
                CrossoverRate = 0.7,
                MaxPerturbation = 0.3,
                EliteCount = 1,

                HiddenLayers = 1,
                HiddenLayerNeurons = 6,

                SweeperType = SweeperType.Sweeper
            };

            return settings;
        }

        public static MineSweeperSettings SweeperDodger()
        {
            var settings = new MineSweeperSettings
            {
                Ticks = 2000,
                SweeperCount = 20,
                MineCount = 40,
                ReplaceMine = true,
                DrawWidth = 640,
                DrawHeight = 520,
                Fast = false,

                MaxSpeed = 1,
                MaxRotation = 0.5,

                MutationRate = 0.1,
                CrossoverRate = 0.7,
                MaxPerturbation = 0.3,
                EliteCount = 4,

                HiddenLayers = 1,
                HiddenLayerNeurons = 8,

                SweeperType = SweeperType.SweeperDodger
            };

            return settings;
        }

        public static MineSweeperSettings ClusterSweeper()
        {
            var settings = new MineSweeperSettings
            {
                Ticks = 2000,
                SweeperCount = 30,
                MineCount = 40,
                ReplaceMine = true,
                DrawWidth = 640,
                DrawHeight = 520,
                Fast = false,

                MaxSpeed = 1.5,
                MaxRotation = 0.7,

                MutationRate = 0.1,
                CrossoverRate = 0.7,
                MaxPerturbation = 0.3,
                EliteCount = 4,

                HiddenLayers = 1,
                HiddenLayerNeurons = 16,

                SweeperType = SweeperType.ClusterSweeper
            };

            return settings;
        }
    }
}
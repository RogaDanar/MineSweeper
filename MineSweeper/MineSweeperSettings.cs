namespace MineSweeper
{
    using NeuralNet.AppHelpers;

    public class MineSweeperSettings : IGeneticsSettings, INetSettings
    {
        public float MineSize = 2;
        public float SweeperSize = 5;
        public int Ticks { get; set; }
        public int SweeperCount { get; set; }
        public int MineCount { get; set; }
        public int DrawWidth { get; set; }
        public int DrawHeight { get; set; }
        public bool Fast { get; set; }

        // IGeneticSettings
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public double MaxPerturbation { get; set; }
        public int EliteCount { get; set; }

        // INetSettings
        public int HiddenLayers { get; set; }
        public int HiddenLayerNeurons { get; set; }

        public SweeperType SweeperType { get; set; }

        private MineSweeperSettings()
        {
        }

        public static MineSweeperSettings Sweeper()
        {
            var settings = new MineSweeperSettings {
                Ticks = 2000,
                SweeperCount = 30,
                MineCount = 40,
                DrawWidth = 400,
                DrawHeight = 400,
                Fast = false,

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

        public static MineSweeperSettings SweeperDodger()
        {
            var settings = new MineSweeperSettings {
                Ticks = 2000,
                SweeperCount = 30,
                MineCount = 40,
                DrawWidth = 400,
                DrawHeight = 400,
                Fast = false,

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
    }
}

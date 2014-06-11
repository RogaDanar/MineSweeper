namespace MineSweeper
{
    public class Settings
    {
        public float MineSize = 2;
        public float SweeperSize = 5;

        public int SweeperCount { get; set; }
        public int MineCount { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public double MaxPerturbation { get; set; }
        public int Ticks { get; set; }
        public int EliteCount { get; set; }

        public int DrawWidth { get; set; }
        public int DrawHeight { get; set; }

        public int HiddenLayers { get; set; }
        public int HiddenLayerNeurons { get; set; }

        public Settings()
        {
            SweeperCount = 30;
            MineCount = 40;
            MutationRate = 0.1;
            CrossoverRate = 0.7;
            MaxPerturbation = 0.3;
            Ticks = 2000;
            EliteCount = 4;

            DrawWidth = 400;
            DrawHeight = 400;

            HiddenLayers = 1;
            HiddenLayerNeurons = 6;
        }

    }
}

namespace MineSweeper.Console
{
    using MineSweeper.Application.Specs;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var controller = new MineSweeperConsoleController(new MineSweeperSpec());
            controller.Start();
        }
    }
}
namespace MineSweeper
{
    using MineSweeper.Controllers;
    using MineSweeper.Specs;
    using System;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new MineSweeperGuiController(new MineSweeperSpec());
            controller.Start();
        }
    }
}

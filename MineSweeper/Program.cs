namespace MineSweeper
{
    using System;
    using System.Windows.Forms;
    using MineSweeper.Controllers;
    using MineSweeper.Specs;

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

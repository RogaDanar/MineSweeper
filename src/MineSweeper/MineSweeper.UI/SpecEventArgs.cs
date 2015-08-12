namespace MineSweeper.UI
{
    using System;
    using MineSweeper.Application.Specs;

    public class SpecEventArgs : EventArgs
    {
        public IMineSweeperSpec Spec { get; set; }

        public SpecEventArgs(IMineSweeperSpec spec)
        {
            Spec = spec;
        }
    }
}
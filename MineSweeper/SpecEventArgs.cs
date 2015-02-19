namespace MineSweeper
{
    using System;
    using MineSweeper.Specs;

    public class SpecEventArgs : EventArgs
    {
        public IMineSweeperSpec Spec { get; set; }

        public SpecEventArgs(IMineSweeperSpec spec)
        {
            Spec = spec;
        }
    }
}

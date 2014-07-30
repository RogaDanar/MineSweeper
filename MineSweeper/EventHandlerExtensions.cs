namespace MineSweeper
{
    using System;

    public static class EventHandlerExtensions
    {
        static public void RaiseEvent(this EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        static public void RaiseEvent<T>(this EventHandler<T> eventHandler, object sender, T e)
            where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }
    }
}

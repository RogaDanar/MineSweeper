namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;

    public class Neuron
    {
        private bool _fired;
        private const int _levelCap = 15;
        private const int _fireThreshold = 10;

        public int Id { get; private set; }

        public int Output
        {
            get {
                return _fired ? 1 : 0;
            }
        }

        public Dictionary<NeuroTransmitter, int> NeuroTransmitterLevels { get; private set; }

        public Neuron(int id)
        {
            Id = id;
            _fired = false;
            initializeNeuroTransmitters();
        }

        /// <summary>
        /// Call this method to activate the receptor, which may fire if a threshold is reached
        /// </summary>
        public void ActivateReceptor(NeuroTransmitter neurotransmitter, int concentration)
        {
            NeuroTransmitterLevels[neurotransmitter] += concentration;

            // Limit the level it can reach
            if (NeuroTransmitterLevels[neurotransmitter] > _levelCap)
            {
                NeuroTransmitterLevels[neurotransmitter] = _levelCap;
            }

            // Trigger a fire event if threshhold is reached 
            if (thresholdCrossed(neurotransmitter))
            {
                _fired = true;
            }
        }

        public void Tick()
        {
            declineTransmitterLevels();
            _fired = false;
        }

        private void initializeNeuroTransmitters()
        {
            NeuroTransmitterLevels = new Dictionary<NeuroTransmitter, int>();

            foreach (NeuroTransmitter transmitter in Enum.GetValues(typeof(NeuroTransmitter)))
            {
                NeuroTransmitterLevels.Add(transmitter, 0);
            }
        }

        private void declineTransmitterLevels()
        {
            foreach (NeuroTransmitter transmitter in Enum.GetValues(typeof(NeuroTransmitter)))
            {
                if (NeuroTransmitterLevels[transmitter] > 0)
                {
                    NeuroTransmitterLevels[transmitter]--;
                }
            }
        }

        private bool thresholdCrossed(NeuroTransmitter neurotransmitter)
        {
            return NeuroTransmitterLevels[neurotransmitter] > _fireThreshold && !_fired;
        }
    }
}

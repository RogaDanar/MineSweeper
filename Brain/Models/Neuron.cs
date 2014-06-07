namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;

    public class Neuron
    {
        private bool _fired;
        private const int _levelCap = 15;
        private const int _fireThreshold = 2;

        public Dictionary<NeuroTransmitter, int> NeuroTransmitterLevels { get; set; }

        public Neuron()
        {
            _fired = false;
            initializeNeuroTransmitters();
        }

        /// <summary>
        /// Call this method to activate the receptor, which may fire if a threshold is reached
        /// </summary>
        /// <param name="neurotransmitter"></param>
        /// <param name="concentration"></param>
        /// <returns></returns>
        public bool ActivateReceptor(NeuroTransmitter neurotransmitter, int concentration)
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
            return _fired;
        }

        public void Tick()
        {
            declineTransmitterLevels();
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

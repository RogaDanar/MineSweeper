namespace Brainspace.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface INeuralNet
    {
        Dictionary<int, int> Show(Dictionary<int, int> inputs);
    }
}

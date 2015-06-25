using AdaptiveUIDemo.Interfaces;
using System;

namespace AdaptiveUIDemo.Data
{
    public class DataPoint : IData
    {
        public string ControlName { get; set; }

        public DateTime TimeOfInteraction { get; set; }
    }
}

using AdaptiveUIDemo.Interfaces;
using System;

namespace AdaptiveUIDemo.Data
{
    public class DataPoint : IData
    {
        public DataPoint()
            : this(string.Empty)
        { }

        public DataPoint(string name)
        {
            ControlName = name;
            TimeOfInteraction = DateTime.Now;
        }

        public string ControlName { get; set; }

        public DateTime TimeOfInteraction { get; set; }
    }
}

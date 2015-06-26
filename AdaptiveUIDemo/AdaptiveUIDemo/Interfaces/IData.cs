using System;

namespace AdaptiveUIDemo.Interfaces
{
    /// <summary>
    /// Can be created each time the user interacts with the system
    /// </summary>
    public interface IData
    {
        string ControlName { get; set; }
        DateTime TimeOfInteraction { get; set; }
        /// <summary>
        /// This should be a normalized ranking between 0 and 1, where 1 is very important and 0 is not important.
        /// </summary>
        double Rank { get; set; }
    }
}

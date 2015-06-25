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
    }
}

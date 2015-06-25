using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;

namespace AdaptiveUIDemo.Interfaces
{
    public interface IDataPersistance
    {
        List<DataPoint> Data { get; set; }

        string UserName { get; set; }

        bool Active { get; set; }

        DateTime CreatedDate { get; set; }

    }
}

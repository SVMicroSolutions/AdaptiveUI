using System;
using System.Collections.Generic;

namespace AdaptiveUIDemo.Interfaces
{
    interface IDataPersistance
    {
        List<IData> Data { get; set; }

        string UserName { get; set; }

        bool Active { get; set; }

        DateTime CreatedDate { get; set; }

    }
}

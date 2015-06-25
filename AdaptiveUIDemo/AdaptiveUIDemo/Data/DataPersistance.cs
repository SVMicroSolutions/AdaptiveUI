using AdaptiveUIDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.Data
{
    class DataPersistance : IDataPersistance
    {
        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<IData> Data { get; set; }

        public string UserName { get; set; }

    }
}

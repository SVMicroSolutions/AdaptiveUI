using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.Interfaces
{
    public interface IPersistData
    {
        DataPersistance LoadData();

        void SaveData(DataPersistance data);
    }
}

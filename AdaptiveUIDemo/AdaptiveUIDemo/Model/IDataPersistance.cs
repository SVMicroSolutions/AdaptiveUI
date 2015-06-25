using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.Model
{
    interface IDataPersistance
    {
        void SaveData();
        void LoadData(); 
        
    }
}

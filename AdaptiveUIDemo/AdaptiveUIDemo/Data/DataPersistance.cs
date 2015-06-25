using AdaptiveUIDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.Data
{
    public class DataPersistance : IDataPersistance
    {
        public DataPersistance()
        {
            this.Data = new List<DataPoint>();
        }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<DataPoint> Data { get; set; }

        public string UserName { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            DataPersistance dp = obj as DataPersistance;
            if (dp == null)
            {
                return false;
            }

            if (Active == dp.Active && UserName == dp.UserName)
            {
                // TODO Need to check datapoints 
                return true;
            }
            else
            {
                return false;
            }

            
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

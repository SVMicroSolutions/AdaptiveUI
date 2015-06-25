using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdaptiveUIDemo.Data;
using System.Collections.Generic;
using AdaptiveUIDemo.Interfaces;

namespace AlgorithmTests
{
    [TestClass]
    public class PersistanceTest
    {
        [TestMethod]
        public void SaveAndLoadDataTest()
        {
            var dataPersistance = new DataPersistance
            {
                Active = true,
                CreatedDate = DateTime.Now,
                UserName = "Sean",
            };
            var data1 = new DataPoint { ControlName = "c1", TimeOfInteraction = DateTime.Now };
            var data2 = new DataPoint { ControlName = "c2", TimeOfInteraction = DateTime.Now };


            dataPersistance.Data.Add(data1);
            dataPersistance.Data.Add(data2);

            // Save the data 
            var persistData = new PersistData();
            persistData.SaveData(dataPersistance);

            // load the data
            var loadedData = persistData.LoadData("Sean");

            Assert.IsTrue(dataPersistance.Equals(loadedData), "Unable to save data correctly");
        }



    }
}

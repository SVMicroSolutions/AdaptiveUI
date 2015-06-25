using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using AdaptiveUIDemo.Interfaces;
using System.Collections.ObjectModel;

namespace AdaptiveUIDemo.ViewModel
{
	public class AdaptiveUIViewModel : BaseViewModel
	{
		#region Properties 
		private string appName = String.Empty;
        //private DumbAlgorithm _learner;
		private ICommand _btnClickVal;
		public ICommand BtnClick
		{
			get
			{
				return _btnClickVal;
			}
			set
			{
				_btnClickVal = value;
			}
		}        
        public ICommand LoadDataClick { get; set; }
        public ICommand SaveDataClick { get; set; }

        public List<string> Users { get; }

        public string CurrentUser { get; set; }

		public string AppName
		{
			get
			{
				return appName;
			}
			set
			{
				if (value != appName)
				{
					appName = value;
					RaisePropertyChanged();
				}
			}
		}

        public List<IAlgorithm> Algorithms{ get; set; }
        
        public IAlgorithm CurrentAlgo { get; set; }
         
        public ObservableCollection<Interfaces.IData> OrderedControls { get; }

        private List<IData> DataList { get; }
		#endregion

        #region PopulateAlgorthim(s)
        /// <summary>
        ///  Add your algorithm to this list to have it picked up.
        /// </summary>
        private void PopulateAlgorthims()
        {
            Algorithms = new List<IAlgorithm>();
            Algorithms.Add(new DumbAlgorithm());
            Algorithms.Add(new BoundedLearner());
            Algorithms.Add(new SeanAlgorithm());
            Algorithms.Add(new ForgetfulLearner());
            CurrentAlgo = Algorithms[0];
        }
        #endregion

		public AdaptiveUIViewModel()
		{
            AppName = "Adaptive UI Rocks!";
            PopulateAlgorthims();
			BtnClick = new CommandExecutor(new Action<object>(ExecuteBtnClick));
            Users = new List<string> { "Enrique", "Tom", "Sean", "Jay" };
            CurrentUser = Users[0];
            DataList = new List<IData>();
		    OrderedControls = new ObservableCollection<Interfaces.IData>
		    {
		        new DataPoint("Button 1"), new DataPoint("Button 2"), new DataPoint("Button 3"),
                new DataPoint("Button 4"), new DataPoint("Button 5"), new DataPoint("Button 6"),
                new DataPoint("Button 7"), new DataPoint("Button 8"), new DataPoint("Button 9")
            };
		    foreach (var c in OrderedControls)
		    {
                DataList.Add(c);
                foreach (var algo in Algorithms)
                {
                    algo.Learn(c);

                }
		    }

    
        }

		private void ExecuteBtnClick(object obj)
		{
			string param = (string)obj;
			if (string.Compare(param, "Go Button") == 0)
				ProcessGoButton();
			if (string.Compare(param, "Load Data") == 0)
				ExecuteLoadData();
			if (string.Compare(param, "Save Button") == 0)
				ExecuteSaveData();
			else
				ProcessNumberButton(param);
		}

        private void ExecuteLoadData()
        {
			PersistData loader = new PersistData();
			loader.LoadData(CurrentUser);
        }

        private void ExecuteSaveData()
        {

			DataPersistance persistanceData = new DataPersistance();
			persistanceData.UserName = CurrentUser;
            foreach (IData dta in DataList)
            {
                persistanceData.Data.Add((DataPoint)dta);
            }
			var persistData = new PersistData();
			persistData.SaveData(persistanceData);
        }
        private void ProcessGoButton()
		{
			System.Diagnostics.Debug.WriteLine("Go Button has been clicked.");
            var controls = CurrentAlgo.OrderControls();
            OrderedControls.Clear();
            foreach (var c in controls)
            {
                OrderedControls.Add(c);
            }
        }

		private void ProcessNumberButton(string param)
		{
			System.Diagnostics.Debug.WriteLine(string.Format("{0} has been clicked.", param));

            var dp = new DataPoint(param);
            CurrentAlgo.Learn(dp);
            DataList.Add(dp);
		}

	}
}

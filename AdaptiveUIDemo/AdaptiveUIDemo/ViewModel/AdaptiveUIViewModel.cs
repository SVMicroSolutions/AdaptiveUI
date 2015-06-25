using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AdaptiveUIDemo.ViewModel
{
	public class AdaptiveUIViewModel : BaseViewModel
	{
		#region Properties 
		private string appName = String.Empty;
        private DumbAlgorithm _learner;
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
		#endregion

		public AdaptiveUIViewModel()
		{
			_learner = new DumbAlgorithm();
			AppName = "Adaptive UI Rocks!";
			BtnClick = new CommandExecutor(new Action<object>(ExecuteBtnClick));
			Users = new List<string> { "Enrique", "Tom", "Sean", "Jay" };
			CurrentUser = Users[0];

			// pre load all the controls so when sorted we will have a complete list.
			for (int i = 1; i <= 9; i++)
			{
				var buttonName = string.Format("Button {0}", i);
				var dta = new DataPoint(buttonName);
				_learner.Learn(dta);
			}
			_sortedControlData = new List<Interfaces.IData>();
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
			if (_sortedControlData.Count == 0)
				ProcessGoButton();

			DataPersistance persistanceData = new DataPersistance();
			persistanceData.UserName = CurrentUser;
			foreach (Interfaces.IData dta in _sortedControlData)
				persistanceData.Data.Add((DataPoint)dta);

			var persistData = new PersistData();
			persistData.SaveData(persistanceData);
        }
        private void ProcessGoButton()
		{
			System.Diagnostics.Debug.WriteLine("Go Button has been clicked.");
			_sortedControlData = _learner.OrderControls();

            // TODO do something useful
        }

		private void ProcessNumberButton(string param)
		{
			System.Diagnostics.Debug.WriteLine(string.Format("{0} has been clicked.", param));

            _learner.Learn(new DataPoint (param));

			// TODO process the button information.
		}

		private List<Interfaces.IData> _sortedControlData;

	}
}

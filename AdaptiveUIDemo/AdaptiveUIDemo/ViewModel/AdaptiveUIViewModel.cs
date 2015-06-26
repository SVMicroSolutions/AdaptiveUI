using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.ViewModel
{
	// ReSharper disable once InconsistentNaming
	public class AdaptiveUIViewModel : BaseViewModel
	{
		#region Properties 

		public ICommand BtnClick { get; set; }

		public List<string> Users { get; }

		public string CurrentUser { get; set; }

		public string AppName
		{
			get { return _appName; }
			set
			{
				if (value != _appName)
				{
					_appName = value;
					RaisePropertyChanged();
				}
			}
		}

		public List<IAlgorithm> Algorithms { get; set; }

		public IAlgorithm CurrentAlgo { get; set; }

		public ObservableCollection<IData> OrderedControls { get; }

		private List<IData> DataList { get; }

		#endregion

		#region PopulateAlgorthim(s)

		/// <summary>
		///  Add your algorithm to this list to have it picked up.
		/// </summary>
		private void PopulateAlgorthims()
		{
			Algorithms = new List<IAlgorithm>
			{
				new DumbAlgorithm(),
				new BoundedLearner(),
				new SeanAlgorithm(),
				new ForgetfulLearner(),
				new TomAlgorithm() ,
                new TimeAlgorithm()
			};
			CurrentAlgo = Algorithms[0];
		}

		#endregion

		public AdaptiveUIViewModel()
		{
			AppName = "Adaptive UI Rocks!";
			PopulateAlgorthims();
			BtnClick = new CommandExecutor(ExecuteBtnClick);
			Users = new List<string> {"Enrique", "Tom", "Sean", "Jay"};
			CurrentUser = Users[0];
			DataList = new List<IData>();
			OrderedControls = new ObservableCollection<IData>
			{
				new DataPoint("Button 1"),
				new DataPoint("Button 2"),
				new DataPoint("Button 3"),
				new DataPoint("Button 4"),
				new DataPoint("Button 5"),
				new DataPoint("Button 6"),
				new DataPoint("Button 7"),
				new DataPoint("Button 8"),
				new DataPoint("Button 9")
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
			string param = (string) obj;
			if (String.CompareOrdinal(param, "Go Button") == 0)
				ProcessGoButton();
			else if (String.CompareOrdinal(param, "Load Data") == 0)
				ExecuteLoadData();
			else if (String.CompareOrdinal(param, "Save Button") == 0)
				ExecuteSaveData();
			else if (String.CompareOrdinal(param, "Reset Data") == 0)
				ExecuteResetData();
			else
				ProcessNumberButton(param);
		}

		private void ExecuteResetData()
		{
			// Reset the persisted data 
			DataList.Clear();
			OrderedControls.Clear();
			// Reset the algorithms 
			foreach (var algo in Algorithms)
			{
				algo.Reset();
			}
			//Add the Orginal Data list of controls to algorthim and save data
			PopulateUI();
		}

		// ReSharper disable once InconsistentNaming
		private void PopulateUI()
		{
			OrderedControls.Add(new DataPoint("Button 1"));
			OrderedControls.Add(new DataPoint("Button 2"));
			OrderedControls.Add(new DataPoint("Button 3"));
			OrderedControls.Add(new DataPoint("Button 4"));
			OrderedControls.Add(new DataPoint("Button 5"));
			OrderedControls.Add(new DataPoint("Button 6"));
			OrderedControls.Add(new DataPoint("Button 7"));
			OrderedControls.Add(new DataPoint("Button 8"));
			OrderedControls.Add(new DataPoint("Button 9"));

			foreach (var c in OrderedControls)
			{
				DataList.Add(c);
				foreach (var algo in Algorithms)
				{
					algo.Learn(c);

				}

			}
		}

		private void ExecuteLoadData()
		{
			Debug.WriteLine("Load Data has been clicked.");



			PersistData data = new PersistData();
			var loadedData = data.LoadData(CurrentUser);
			foreach (var c in loadedData.Data)
			{
				ProcessNumberButton(c.ControlName);
			}

		}

		private void ExecuteSaveData()
		{

			DataPersistance persistanceData = new DataPersistance
			{
				UserName = CurrentUser
			};
			foreach (IData dta in DataList)
			{
				persistanceData.Data.Add((DataPoint) dta);
			}
			var persistData = new PersistData();
			persistData.SaveData(persistanceData);
		}

		private void ProcessGoButton()
		{
			Debug.WriteLine("Go Button has been clicked.");
			var controls = CurrentAlgo.OrderControls();
			OrderedControls.Clear();
			foreach (var c in controls)
			{
				OrderedControls.Add(c);
			}
		}

		private void ProcessNumberButton(string param)
		{
			Debug.WriteLine(string.Format("{0} has been clicked.", param));

			var dp = new DataPoint(param);
			Algorithms.ForEach(x => x.Learn(dp));
			DataList.Add(dp);
		}

		private string _appName = string.Empty;


	}
}

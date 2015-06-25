using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdaptiveUIDemo.Interfaces;

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

        public ObservableCollection<IData> OrderedControls { get; }
		#endregion

		public AdaptiveUIViewModel()
		{
            _learner = new DumbAlgorithm();
            AppName = "Adaptive UI Rocks!";
			BtnClick = new CommandExecutor(new Action<object>(ExecuteBtnClick));
            LoadDataClick = new CommandExecutor(new Action<object>(ExecuteLoadData));
            SaveDataClick = new CommandExecutor(new Action<object>(ExecuteSaveData));
            Users = new List<string> { "Enrique", "Tom", "Sean", "Jay" };
            CurrentUser = Users[0];
		    OrderedControls = new ObservableCollection<IData>
		    {
		        new DataPoint("Button 1"), new DataPoint("Button 2"), new DataPoint("Button 3"),
                new DataPoint("Button 4"), new DataPoint("Button 5"), new DataPoint("Button 6"),
                new DataPoint("Button 7"), new DataPoint("Button 8"), new DataPoint("Button 9")
            };
		    foreach (var c in OrderedControls)
		    {
		        _learner.Learn(c);
		    }
		}

		private void ExecuteBtnClick(object obj)
		{
			string param = (string)obj;
			if (string.Compare(param, "Go Button") == 0)
				ProcessGoButton();
			else
				ProcessNumberButton(param);
		}

        private void ExecuteLoadData(object obj)
        {
            
        }

        private void ExecuteSaveData(object obj)
        {

        }
        private void ProcessGoButton()
		{
			System.Diagnostics.Debug.WriteLine("Go Button has been clicked.");
            var controls = _learner.OrderControls();
            OrderedControls.Clear();
            foreach (var c in controls)
            {
                OrderedControls.Add(c);
            }

            // TODO do something useful
        }

		private void ProcessNumberButton(string param)
		{
			System.Diagnostics.Debug.WriteLine(string.Format("{0} has been clicked.", param));

            _learner.Learn(new DataPoint (param));
            

			// TODO process the button information.
		}

	}
}

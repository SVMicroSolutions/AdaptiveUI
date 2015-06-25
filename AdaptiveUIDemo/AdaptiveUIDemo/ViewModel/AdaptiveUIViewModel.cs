using AdaptiveUIDemo.AdaptiveUIAlgorthims;
using AdaptiveUIDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

		private void ExecuteBtnClick(object obj)
		{
			string param = (string)obj;
			if (string.Compare(param, "Go Button") == 0)
				ProcessGoButton();
			else
				ProcessNumberButton(param);
		}

		private void ProcessGoButton()
		{
			System.Diagnostics.Debug.WriteLine("Go Button has been clicked.");
            _learner.OrderControls();

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

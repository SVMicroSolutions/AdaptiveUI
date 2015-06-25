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
        private ICommand m_GoBtn;
        public ICommand GoBtn
        {
            get
            { return m_GoBtn; }
            set
            {
                m_GoBtn = value;
            }

        }

       

        public string AppName
        {
            get
            {
                return this.appName;
            }
            set
            {
                if (value != this.appName)
                {
                    this.appName = value;
                    RaisePropertyChanged();
                }

            }
        }
        #endregion

        public AdaptiveUIViewModel()
        {
            this.AppName = "Adaptive UI Rocks!";
            GoBtn = new CommandExecutor(new Action<object>(GoExecute));

        }
        private void GoExecute(object obj)
        {
            System.Diagnostics.Debug.WriteLine("I have been clicked.");
        }
        
    }
}

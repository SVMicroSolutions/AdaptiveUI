using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveUIDemo.ViewModel
{
    public class AdaptiveUIViewModel : BaseViewModel
    {
        #region Properties 
        private string appName = String.Empty;

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

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuntRosiesBookkeeping.Views;
using System.ComponentModel;

namespace AuntRosiesBookkeeping.ViewModels
{
    
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private static int _tabIndex;

        public event PropertyChangedEventHandler PropertyChanged;

        //Handles the property changing
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public int tabIndex
        {
            get { return _tabIndex; }
            set
            {
                _tabIndex = value;
                OnPropertyChanged("ChangeIndex");
            }
        }

        /*public ReportsViewModel(int tab)
        {
            this.tabIndex = tab;
        }*/
        public ReportsViewModel()
        {
            
        }
    }
}

using System.ComponentModel;

namespace thepat.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyChangeProperty  

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion

        #region virtual methods

        public virtual void OnNavigatedTo(object navigationParameter = null)
        {
        }

        public virtual void OnNavigatedFrom()
        {
        }

        #endregion
    }
}

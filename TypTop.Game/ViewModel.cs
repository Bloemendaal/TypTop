using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TypTop.Game
***REMOVED***
    public class ViewModel : INotifyPropertyChanged
    ***REMOVED***
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        ***REMOVED***
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    ***REMOVED***
***REMOVED***
***REMOVED***
using AcquistionTool.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AcquistionTool.ViewModels
{
    public class BaseViewModels : INotifyPropertyChanged
    {
       // private readonly BaseSystem _baseSystem;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}

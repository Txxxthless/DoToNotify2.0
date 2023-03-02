using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using DoToNotify2._0.MVVM.View;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DoToNotify2._0.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private readonly ObservableCollection<ObjectiveViewModel> _objectives;
        public ObservableCollection<ObjectiveViewModel> Objectives => _objectives;
        public MainViewModel()
        {
            _objectives = new ObservableCollection<ObjectiveViewModel>();

            _objectives.Add(new ObjectiveViewModel(new Objective(DateTime.Now, "Cook")));
            _objectives.Add(new ObjectiveViewModel(new Objective(DateTime.Now, "How does it feel?")));
            _objectives.Add(new ObjectiveViewModel(new Objective(DateTime.Now, "Yer Blues")));
        }
    }
}

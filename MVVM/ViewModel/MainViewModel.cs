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

            _objectives.Add(new ObjectiveViewModel(new Objective(new DateTime(2023, 3, 4, 11, 11, 0), "Do stuff")));

            //Task.Run(Check);
        }

        public void Check()
        {
                while(true)
                {
                    int index = -1;

                    foreach (var o in _objectives)
                    {
                        if (o.DeadLine <= DateTime.Now)
                        {
                            index = _objectives.IndexOf(o);
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        _objectives.RemoveAt(index);
                    }
                }
        }
    }
}

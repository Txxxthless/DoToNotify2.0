using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using DoToNotify2._0.MVVM.View;
using System;
using System.Collections;
using System.Collections.Generic;
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

            _objectives.Add(new ObjectiveViewModel(new Objective(
                new DateTime(2023, 3, 5, 11, 27, 10), 
                "Do stuff")));

            _objectives.Add(new ObjectiveViewModel(new Objective(
                new DateTime(2023, 3, 5, 11, 27, 11),
                "Do stuff")));

            _objectives.Add(new ObjectiveViewModel(new Objective(
                new DateTime(2023, 3, 5, 11, 27, 12),
                "Do stuff")));

            Task.Run(Check);
        }

        public void Check()
        {
            List<int> indexes = new List<int>();

            while (true)
            {
                foreach (var o in _objectives)
                {
                    if (o.DeadLine <= DateTime.Now)
                    {
                        indexes.Add(_objectives.IndexOf(o));
                    }
                }

                if (indexes.Count > 0)
                {
                    //!!!!!!!!
                    foreach (int index in indexes)
                    {
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            _objectives.RemoveAt(index);
                        });
                    }
                }

                indexes.Clear();
            }
        }
    }
}

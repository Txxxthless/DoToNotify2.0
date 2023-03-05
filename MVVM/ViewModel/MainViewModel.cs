using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoToNotify2._0.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private string _description = "";
        private DateTime _deadLine = DateTime.Now;
        private int _hours = 12;
        private int _seconds = 0;
        private int _minutes = 0;


        private readonly ObservableCollection<ObjectiveViewModel> _objectives;
        public ObservableCollection<ObjectiveViewModel> Objectives => _objectives;
        

        public CommandObject CreateObjectiveCommand { get; }
        public string Description 
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public DateTime DeadLineDate
        {
            get
            {
                return _deadLine;
            }
            set
            {
                _deadLine = value;
                OnPropertyChanged();
            }
        }
        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                _hours = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        public int Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                _minutes = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                _seconds = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            _objectives = new ObservableCollection<ObjectiveViewModel>();
            
            CreateObjectiveCommand = new CreateObjectiveCommand(this);

            Task.Run(Check);
        }

        public void Check()
        {
            List<int> indexes = new List<int>();

            while (true)
            {
                try
                {
                    foreach (var o in _objectives)
                    {
                        if (o.DeadLine <= DateTime.Now)
                        {
                            indexes.Add(_objectives.IndexOf(o));
                        }
                    }
                } catch (Exception ex) { Console.WriteLine(ex); }

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

using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using System;

namespace DoToNotify2._0.MVVM.ViewModel
{
    internal class ObjectiveViewModel : ObservableObject
    {
        private Objective _objective;

        public string Description => _objective.Description;
        public DateTime DeadLine => _objective.DeadLine;

        public ObjectiveViewModel(Objective o)
        {
            _objective = o;
        }
    }
}

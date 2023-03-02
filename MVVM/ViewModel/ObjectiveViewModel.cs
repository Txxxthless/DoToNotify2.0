using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoToNotify2._0.MVVM.ViewModel
{
    internal class ObjectiveViewModel : ObservableObject
    {
        private Objective _objective;

        public string Description => _objective.Description;
        public string DeadLine => _objective.DeadLine.ToString();

        public ObjectiveViewModel(Objective o)
        {
            _objective = o;
        }
    }
}

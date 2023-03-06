using DoToNotify2._0.Core;
using DoToNotify2._0.MVVM.Model;
using System;
using System.Runtime.Serialization;

namespace DoToNotify2._0.MVVM.ViewModel
{
    [DataContract]
    internal class ObjectiveViewModel : ObservableObject
    {
        [DataMember]
        private Objective _objective;

        public string Description => _objective.Description;
        public DateTime DeadLine => _objective.DeadLine;

        public ObjectiveViewModel(Objective o)
        {
            _objective = o;
        }
    }
}

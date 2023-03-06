using System;
using System.Runtime.Serialization;

namespace DoToNotify2._0.MVVM.Model
{
    [DataContract]
    internal class Objective
    {
        [DataMember]
        private DateTime _deadLine;
        [DataMember]
        private string _description;

        public DateTime DeadLine => _deadLine;
        public string Description => _description;

        public Objective(DateTime date, string description)
        {
            _deadLine = date;
            _description = description;
        }
    }
}

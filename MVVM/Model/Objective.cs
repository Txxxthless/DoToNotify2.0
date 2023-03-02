using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoToNotify2._0.MVVM.Model
{
    internal class Objective
    {
        private DateTime _deadLine;
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

using DoToNotify2._0.MVVM.Model;
using DoToNotify2._0.MVVM.ViewModel;
using System;

namespace DoToNotify2._0.Core
{
    internal class CreateObjectiveCommand : CommandObject
    {
        private MainViewModel _bindedViewModel;
        public CreateObjectiveCommand(MainViewModel bindedViewModel)
        {
            _bindedViewModel = bindedViewModel;
        }

        public override void Execute(object? parameter)
        {
            DateTime deadline = new DateTime
                (
                _bindedViewModel.DeadLineDate.Year,
                _bindedViewModel.DeadLineDate.Month,
                _bindedViewModel.DeadLineDate.Day,
                _bindedViewModel.Hours,
                _bindedViewModel.Minutes,
                _bindedViewModel.Seconds
                );
            Objective o = new Objective(deadline, _bindedViewModel.Description);
            _bindedViewModel.Objectives.Add(new ObjectiveViewModel(o));
        }
    }
}

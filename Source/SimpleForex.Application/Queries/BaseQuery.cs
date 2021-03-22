using System;
using SimpleForex.Core.Contracts.Queries;

namespace SimpleForex.Application.Queries
{
    public abstract class BaseQuery<TQuery, TResult> : IQuery<TQuery, TResult>
        where TQuery : class
        where TResult : class
    {
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;


        public BaseQuery(Func<bool> canExecute = null) =>
            _canExecute = canExecute;

        public bool CanExecute(object parameter) => RaiceCanExecute();

        public bool RaiceCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            var canExecute = _canExecute?.Invoke() ?? true;

            return canExecute;
        }

        public abstract TResult Execute(TQuery query);

        public void Execute(object parameter)
        {
            if (!(parameter is TQuery query))
                return;

            Execute(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Windows_Tool_Demo.Boilerplate
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _predicate;

        public DelegateCommand(Action<object> action, Predicate<object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            _action = action;
            _predicate = predicate;
        }

        /// <summary>
        /// Returns true if the action can be executed with the specified paramters
        /// </summary>
        /// <param name="parameters">parameters to check</param>
        /// <returns>true if the command can execute with the specified parameters, otherwise false</returns>
        public bool CanExecute(object parameters)
        {
            // if no predicate specified, always can execute
            if (_predicate == null)
            {
                return true;
            }
            else
            {
                return _predicate(parameters);
            }
        }

        /// <summary>
        /// executes the desired commands with the parameters paramters
        /// </summary>
        /// <param name="parameters">parameters to pass to the command</param>
        public void Execute(object parameters)
        {
            _action(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
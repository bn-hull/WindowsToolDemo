using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Tool_Demo.ViewModels
{
    public class ApplicationViewModel
    {
        private IEnumerable<INamedViewModel> _viewModels;
        private INamedViewModel _currentViewModel;

        public IEnumerable<INamedViewModel> ApplicationPages
        {
            get { return _viewModels; }
        }

        public INamedViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
        }

        public ApplicationViewModel(IEnumerable<INamedViewModel> viewModels)
        {
            _viewModels = viewModels;
            _currentViewModel = _viewModels.FirstOrDefault();
        }

        public void ChangeViewModel(INamedViewModel newViewModel)
        {
            // verify if view model exists
            if (!_viewModels.Contains(newViewModel))
            {
                throw new ArgumentOutOfRangeException();
            }

            _currentViewModel = newViewModel;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Tool_Demo.ViewModels;
using Xunit;

namespace Windows_Tools_Tests.ViewModelTests
{
    public class ApplicationViewModelTests
    {
        [Fact]
        public void StartsOnFirstviewModel()
        {
            NamedViewModelMock[] namedViewModels = new NamedViewModelMock[2]
            {
                new NamedViewModelMock("0"),
                new NamedViewModelMock("1")
            };

            var applicationVm = new ApplicationViewModel(namedViewModels);

            Assert.Same(namedViewModels[0], applicationVm.CurrentViewModel);
        }

        [Fact]
        public void ChangeViewModel()
        {
            NamedViewModelMock[] namedViewModels = new NamedViewModelMock[2]
            {
                new NamedViewModelMock("0"),
                new NamedViewModelMock("1")
            };

            var applicationVm = new ApplicationViewModel(namedViewModels);

            applicationVm.ChangeViewModel(namedViewModels[1]);

            Assert.Same(namedViewModels[1], applicationVm.CurrentViewModel);
        }

        [Fact]
        public void ChangeViewModelOnlyIfExists()
        {
            NamedViewModelMock[] namedViewModels = new NamedViewModelMock[2]
            {
                new NamedViewModelMock("0"),
                new NamedViewModelMock("1")
            };

            var applicationVm = new ApplicationViewModel(namedViewModels);

            NamedViewModelMock badViewModel = new NamedViewModelMock("2");

            Assert.Throws<ArgumentOutOfRangeException>(
                () => { applicationVm.ChangeViewModel(badViewModel); }
            );
        }
    }

    internal class NamedViewModelMock : INamedViewModel
    {
        private string _name;

        public string ViewModelName
        {
            get { return _name; }
        }

        public NamedViewModelMock(string name)
        {
            _name = name;
        }
    }
}
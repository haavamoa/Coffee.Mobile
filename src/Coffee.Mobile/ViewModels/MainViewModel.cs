using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffee.Mobile.Models;
using Coffee.Mobile.Services;
using Coffee.Mobile.Services.Abstractions;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;

namespace Coffee.Mobile.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICoffeeService m_coffeeService;
        private readonly Func<Method, MethodViewModel> m_methodViewModelFactory;
        private MethodViewModel? m_selectedMethod;
        private bool m_hasSelectedMethod;

        public MainViewModel(ICoffeeService coffeeService, Func<Method,MethodViewModel> methodViewModelFactory)
        {
            m_coffeeService = coffeeService;
            m_methodViewModelFactory = methodViewModelFactory;
            SelectMethodCommand = new Command<MethodViewModel>(method =>
            {
                SelectedMethod = method;
                HasSelectedMethod = true;
            });
        }

        public async Task Initialize()
        {
            var methods = await m_coffeeService.GetAvailableMethods();

            foreach (var methodName in methods)
            {
                var method = await m_coffeeService.GetMethod(methodName);

                Methods.Add(m_methodViewModelFactory.Invoke(method));
            }
        }

        public ObservableCollection<MethodViewModel> Methods { get; } = new ObservableCollection<MethodViewModel>();

        public MethodViewModel? SelectedMethod
        {
            get => m_selectedMethod;
            set => PropertyChanged.RaiseWhenSet(ref m_selectedMethod, value);
        }

        public Func<MethodViewModel> SelectedMethodFactory => () => SelectedMethod;

        public ICommand SelectMethodCommand { get; }

        public bool HasSelectedMethod
        {
            get => m_hasSelectedMethod;
            set => PropertyChanged.RaiseWhenSet(ref m_hasSelectedMethod, value);
        }

#nullable disable
        public event PropertyChangedEventHandler PropertyChanged;
    }
#nullable enable
}

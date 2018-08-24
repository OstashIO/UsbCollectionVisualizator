using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Interop;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RawHidReading;
using UsbVisualizator.Services;
using UsbVisualizator.Views;

namespace UsbVisualizator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IDataService DataService { get; }
        public Timer Timer { get; }

        public IUnityContainer Container { get; set; }

        public IEnumerable<object> Devices
        {
            get => _devices;
            set => SetProperty(ref _devices, value);
        }

        private IEnumerable<object> _devices = new List<object>();

        public MainWindowViewModel(IDataService dataService, IUnityContainer container)
        {
            DataService = dataService;

            Container = container;

            Timer = new Timer(Callback, null, 1000, 1000);
        }

        private void Callback(object state)
        {
            var process = Process.GetCurrentProcess();

            var handle = process.MainWindowHandle;

            var hid = Container.Resolve<IHID>(new ParameterOverride("windowHandle", handle));

            Devices = DataService.GetDevices(handle, hid);
        }
    }
}

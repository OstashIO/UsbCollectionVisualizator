using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using RawHidReading;
using UsbVisualizator.Services;

namespace UsbVisualizator
{
    public class ModelResolvingExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            // Сервисы
            Container.RegisterType<IDataService, DataService>(SetSingletonScope());

            // Модели
            Container.RegisterType<IHID, HID>();
        }

        private ContainerControlledLifetimeManager SetSingletonScope()
        {
            return new ContainerControlledLifetimeManager();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawHidReading;

namespace UsbVisualizator.Services
{
    public interface IDataService
    {
        IEnumerable<object> GetDevices(IntPtr windowHandle, IHID hid);
    }
}

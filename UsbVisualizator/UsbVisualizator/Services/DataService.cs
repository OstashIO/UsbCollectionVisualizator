using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawHidReading;

namespace UsbVisualizator.Services
{
    public class DataService : IDataService
    {
        private IHID _hid { get; set; }

        public IEnumerable<object> GetDevices(IntPtr windowHandle, IHID hid)
        {
            _hid = hid;

            return hid.ListDevices();
        }
    }
}

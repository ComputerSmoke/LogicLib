using Gas.Containers.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrideUtils;

namespace LogicLib.Devices.Input.Gauge
{
    internal class GaugeManager(int sleepTime) : Manager<Gauge>(sleepTime)
    {
        const int UpdateMs = 100;
        public static GaugeManager Manager = new(UpdateMs);
        protected override void ManageEntry(Gauge entry)
        {
            entry.UpdateGauge();
        }
    }
}

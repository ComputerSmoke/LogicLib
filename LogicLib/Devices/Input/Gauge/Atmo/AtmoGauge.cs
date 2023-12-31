using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Containers;

namespace LogicLib.Devices.Input.Gauge.Atmo
{
    public abstract class AtmoGauge : Gauge
    {
        protected override long Measure()
        {
            return Measure(Universe.Parent(physicsComponent));
        }
        //Take measure of atmo in container
        protected abstract long Measure(Container container);
    }
}

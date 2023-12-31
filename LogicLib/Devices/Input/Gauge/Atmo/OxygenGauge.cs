using Gas.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gas.Chemistry;

namespace LogicLib.Devices.Input.Gauge.Atmo
{
    public class OxygenGauge : AtmoGauge
    {
        protected override long Measure(Container container)
        {
            return (long)container.PartialPressure(MoleculeTable.Oxygen);
        }
    }
}

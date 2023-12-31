using Gas.Chemistry;
using Gas.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices.Input.Gauge.Atmo
{
    public class CarbonDioxideGauge : AtmoGauge
    {
        protected override long Measure(Container container)
        {
            return (long)container.PartialPressure(MoleculeTable.CarbonDioxide);
        }
    }
}

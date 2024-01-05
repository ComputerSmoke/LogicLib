using Gas.Containers.Transfers;
using LogicLib.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices.Output
{
    public class Valve : Device
    {
        Transfer Transfer => _transfer ??= Entity.Get<Transfer>();
        Transfer _transfer;

        public override void GateChange(Gate gate)
        {
            Transfer.Active = Gate.Truthy(gate.State);
        }
    }
}

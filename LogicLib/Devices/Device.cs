using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Engine;
using LogicLib.Gates;

namespace LogicLib.Devices
{
    public abstract class Device : StartupScript
    {
        public abstract void GateChange(Gate gate);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Engine;
using LogicLib.Gates;
using LogicLib.Gates.Solo;

namespace LogicLib.Devices
{
    public abstract class Device : StartupScript
    {
        protected List<BufferGate> inputs;

        public abstract void GateChange(Gate gate);
    }
}

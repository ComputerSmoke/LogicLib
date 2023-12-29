using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Solo
{
    public class BufferGate : SoloGate
    {
        protected override long ComputeNextState(long in1)
        {
            return in1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class DivisionGate : DuoGate
    {
        protected override long ComputeNextState(long in1, long in2)
        {
            return in1 / in2;
        }
    }
}

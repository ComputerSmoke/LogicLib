using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class XorGate : DuoGate
    {
        protected override bool ComputeNextState(bool in1, bool in2)
        {
            return in1 && !in2 || !in1 && in2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class MuxGate : Gate
    {
        //output second input if first is even (falsy), third otherwise.
        protected override long ComputeNextState(long[] inputs)
        {
            if(inputs.Length != 3)
                throw new ConnectorMiscountException("Mux gate must have 3 input connectors");
            return Truthy(inputs[0]) ? inputs[1] : inputs[2];
        }
    }
}

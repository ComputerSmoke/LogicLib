using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class ConstantGate : Gate
    {
        public long ConstantValue { get; set; }

        protected override long ComputeNextState(long[] inputs)
        {
            if (inputs.Length != 0)
                throw new ConnectorMiscountException("Constant gate must have 0 input connectors.");
            return ConstantValue;
        }
    }
}

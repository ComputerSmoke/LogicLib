using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Solo
{
    public abstract class SoloGate : Gate
    {
        protected override bool ComputeNextState(bool[] inputs)
        {
            if (inputs.Length != 1)
                throw new ConnectorMiscountException("Solo gate must have 1 input connector");
            return ComputeNextState(inputs[0]);
        }
        protected abstract bool ComputeNextState(bool in1);
    }
}

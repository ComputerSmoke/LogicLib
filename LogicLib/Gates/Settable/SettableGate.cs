using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Settable
{
    public class SettableGate : Gate
    {
        protected override long ComputeNextState(long[] inputs)
        {
            return NextState;
        }
        //Set state of gate. Should be called from output device
        public virtual void SetNextState(long state)
        {
            NextState = state;
            //TODO: when only update changed optimization implemented, mark this one as needing change
        }
    }
}

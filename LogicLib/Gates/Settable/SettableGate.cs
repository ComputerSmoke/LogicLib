using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Settable
{
    public class SettableGate : Gate
    {
        protected override bool ComputeNextState(bool[] inputs)
        {
            return NextState;
        }
        //Set state of gate. Should be called from output device
        public virtual void SetNextState(bool state)
        {
            NextState = state;
            Ticker.UpdateGate(this);
        }
    }
}

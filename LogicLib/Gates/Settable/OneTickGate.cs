using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Settable
{
    public class OneTickGate : SettableGate
    {
        //Update gate, but queue a disable update if set to true.
        public override void UpdateState()
        {
            base.UpdateState();
            if(State)
                SetNextState(false);
        }
    }
}

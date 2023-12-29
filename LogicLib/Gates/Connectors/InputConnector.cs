using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;

namespace LogicLib.Gates.Connectors
{
    public class InputConnector : Connector
    {
        //Connect and tick gate.
        public override bool Connect(Connector connector)
        {
            if (!base.Connect(connector))
                return false;
            Tick();
            return true;
        }
        public override void Tick()
        {
            Ticker.UpdateGate(gate);
        }
        public override long Read()
        {
            if (Connected == null)
                return 0;
            return Connected.Read();
        }
    }
}

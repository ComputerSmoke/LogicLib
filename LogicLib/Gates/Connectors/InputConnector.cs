using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;

namespace LogicLib.Gates.Connectors
{
    public class NullGateException(string msg) : Exception(msg);
    public class InputConnector : Connector
    {
        public int Channel { get; set; }
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
        public override void Start()
        {
            base.Start();
            if (gate == null)
                throw new NullGateException("Input connector must have gate in parent entity.");
        }
    }
}

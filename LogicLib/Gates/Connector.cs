using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class IncompatibleConnectorException(string msg) : Exception(msg) { }
    public class Connector : StartupScript
    {
        public bool IsInput { get; set; }
        Gate gate;
        Connector connected;
        public void Connect(Connector connector)
        {
            if (connector.IsInput == IsInput)
                throw new IncompatibleConnectorException("Can only connect input to output and output to input connectors.");
            connected = connector;
            if (IsInput)
                Tick();
        }
        public override void Start()
        {
            base.Start();
            gate = Entity.GetParent().Get<Gate>();
        }
        public void Tick()
        {
            if (IsInput)
                Ticker.UpdateGate(gate);
            else
                connected?.Tick();
        }
        public bool Read()
        {
            if (!IsInput)
                return gate.State;
            if (connected == null)
                return false;
            return connected.Read();
        }
    }
}

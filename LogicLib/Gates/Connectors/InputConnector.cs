using StrideUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;

namespace LogicLib.Gates.Connectors
{
    public class NullGateException(string msg) : Exception(msg);
    public class InvalidSchemaException(string msg) : Exception(msg);
    public class InputConnector : Connector
    {
        public int Channel { get; set; }
        public OutputConnector InitialConnector { get; set; }
        public override long Read()
        {
            if (Connected == null)
                return 0;
            return Connected.Read();
        }
        public override void Start()
        {
            base.Start();
            if (Gate == null)
                throw new NullGateException("Input connector must have gate in parent entity.");
            if(InitialConnector != null)
            {
                if (InitialConnector.Connected != null)
                    throw new InvalidSchemaException("Cannot initialize two input connectors connected to the same output connector.");
                Connect(InitialConnector);
            }
        }
    }
}

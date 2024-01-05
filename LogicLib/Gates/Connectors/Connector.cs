using Stride.Engine;
using StrideUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Connectors
{
    public class IncompatibleConnectorException(string msg) : Exception(msg) { }
    public abstract class Connector : StartupScript
    {
        protected Gate Gate => _gate ??= Entity.GetParent().GetNotNull<Gate>();
        Gate _gate;
        public Connector Connected { get; protected set; }
        //Connect to another connector. Returns false if already connected, true otherwise.
        public virtual bool Connect(Connector connector) {
            if (connector is InputConnector == this is InputConnector)
                throw new IncompatibleConnectorException("Can only connect input to output connectors.");
            if (Connected == connector)
                return false;
            Disconnect();
            Connected = connector;
            connector.Connect(this);
            return true;
        }
        public virtual void Disconnect()
        {
            if (Connected == null)
                return;
            Connector temp = Connected;
            Connected = null;
            temp.Disconnect();
        }
        public abstract long Read();
    }
}

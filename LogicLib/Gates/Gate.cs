using Stride.Engine;
using LogicLib.Devices;
using LogicLib.Gates.Connectors;

namespace LogicLib.Gates
{
    public abstract class Gate : StartupScript
    {
        protected readonly List<InputConnector> inputs = [];
        protected readonly List<OutputConnector> outputs = [];
        public long State { get; protected set; }
        protected long NextState { get; set; }
        private List<Device> devices;
        bool hadFirstRun;
        public override void Start()
        {
            base.Start();
            if (Entity.GetParent() == null)
                devices = [];
            else
                devices = new(Entity.GetParent().GetAll<Device>());
            FindConnectors();
            Ticker.UpdateGate(this);
        }
        private void FindConnectors()
        {
            List<Connector> connectors = Entity.FindAllInChild<Connector>();
            foreach (Connector connector in connectors) {
                if (connector is InputConnector inputConnector)
                    inputs.Add(inputConnector);
                else
                    outputs.Add((OutputConnector)connector);
            }
        }
        //Update next state of gate based on State of inputs, which it will go to when UpdateState called
        public void UpdateNextState()
        {
            long[] inputVals = new long[inputs.Count];
            for (int i = 0; i < inputs.Count; i++)
                inputVals[i] = inputs[i].Read();
            NextState = ComputeNextState(inputVals);
        }
        //Update gate based on previously computed next state. Tell connected gates to update next tick if state changed.
        public virtual void UpdateState()
        {
            if (hadFirstRun && State == NextState)
                return;
            hadFirstRun = true;
            State = NextState;
            foreach (Connector connector in outputs)
                connector.Tick();
            foreach (Device device in devices)
                device.GateChange(this);
        }
        //Logic of gate
        protected abstract long ComputeNextState(long[] inputs);
    }
}

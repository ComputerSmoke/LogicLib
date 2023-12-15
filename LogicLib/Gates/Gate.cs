using Stride.Engine;
using LogicLib.Devices;

namespace LogicLib.Gates
{
    public abstract class Gate : StartupScript
    {
        protected readonly List<Connector> inputs = [];
        protected readonly List<Connector> outputs = [];
        public bool State { get; private set; }
        bool NextState { get; set; }
        private List<Device> devices;
        bool hadFirstRun;
        public override void Start()
        {
            base.Start();
            devices = new(Entity.GetAll<Device>());
            FindConnectors();
            Ticker.UpdateGate(this);
        }
        private void FindConnectors()
        {
            List<Connector> connectors = Entity.FindAllInChild<Connector>();
            foreach (Connector connector in connectors) {
                if (connector.IsInput)
                    inputs.Add(connector);
                else
                    outputs.Add(connector);
            }
        }
        //Update next state of gate based on State of inputs, which it will go to when UpdateState called
        public void UpdateNextState()
        {
            bool[] inputVals = new bool[inputs.Count];
            for (int i = 0; i < inputs.Count; i++)
                inputVals[i] = inputs[i].Read();
            NextState = ComputeNextState(inputVals);
        }
        //Update gate based on previously computed next state. Tell connected gates to update next tick if state changed.
        public void UpdateState()
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
        protected abstract bool ComputeNextState(bool[] inputs);
    }
}

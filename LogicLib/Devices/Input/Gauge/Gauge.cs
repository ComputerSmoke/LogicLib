using LogicLib.Gates;
using LogicLib.Gates.Settable;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrideUtils;

namespace LogicLib.Devices.Input.Gauge
{
    public abstract class Gauge : Device
    {
        protected SettableGate Output => _output ??= Entity.FindInChild<SettableGate>();
        SettableGate _output;
        protected PhysicsComponent PhysicsComponent => _physicsComponent ??= Entity.GetNotNull<PhysicsComponent>();
        PhysicsComponent _physicsComponent;
        public override void Start()
        {
            base.Start();
            GaugeManager.Manager.Register(this);
        }
        public void UpdateGauge()
        {
            long measurement = Measure();
            Output.SetNextState(measurement);
        }
        //Measure whatever the gauge is measuring
        protected abstract long Measure();
        public override void GateChange(Gate gate) {}
    }
}

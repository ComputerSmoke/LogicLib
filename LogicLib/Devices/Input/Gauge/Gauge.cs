using LogicLib.Gates;
using LogicLib.Gates.Settable;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices.Input.Gauge
{
    public abstract class Gauge : Device
    {
        protected SettableGate output;
        public int UpdateMs = 100;
        protected PhysicsComponent physicsComponent;
        public override async Task Execute()
        {
            output = Entity.FindInChild<SettableGate>();
            physicsComponent = Entity.Get<PhysicsComponent>();
            await UpdateLoop();
        }
        private async Task UpdateLoop()
        {
            await Script.NextFrame();
            while(Game.IsRunning)
            {
                output.SetNextState(Measure());
                await Task.Delay(UpdateMs);
            }
        }
        //Measure whatever the gauge is measuring
        protected abstract long Measure();
        public override void GateChange(Gate gate) {}
    }
}

using LogicLib.Gates;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using LogicLib.Gates.Solo;

namespace LogicLib.Devices.Output
{
    public class IndicatorDevice : Device
    {
        private LightComponent lightComponent;
        public override Task Execute()
        {
            lightComponent = Entity.FindInChild<LightComponent>();
            return Task.CompletedTask;
        }
        public override void GateChange(Gate gate)
        {
            var color = (gate.State & 1) == 1 ? new Color3(0, 255, 0) : new Color3(255, 0, 0);
            lightComponent.SetColor(color);
        }
    }
}

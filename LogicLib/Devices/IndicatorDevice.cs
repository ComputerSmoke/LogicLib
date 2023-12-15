using LogicLib.Gates;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;

namespace LogicLib.Devices
{
    public class IndicatorDevice : Device
    {
        private Gate gate;
        private LightComponent lightComponent;
        public override void Start()
        {
            base.Start();
            gate = Entity.Get<Gate>();
            lightComponent = Entity.FindInChild<LightComponent>();
        }
        public override void GateChange(Gate gate)
        {
            var color = gate.State ? new Color3(0, 255, 0) : new Color3(255, 0, 0);
            lightComponent.SetColor(color);
        }
    }
}

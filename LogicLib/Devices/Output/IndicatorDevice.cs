using LogicLib.Gates;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using LogicLib.Gates.Solo;
using StrideUtils;

namespace LogicLib.Devices.Output
{
    public class IndicatorDevice : Device
    {
        LightComponent LightComponent => _lightComponent ??= Entity.FindInChild<LightComponent>();
        LightComponent _lightComponent;
        public override void GateChange(Gate gate)
        {
            var color = Gate.Truthy(gate.State) ? new Color3(0, 255, 0) : new Color3(255, 0, 0);
            LightComponent.SetColor(color);
        }
    }
}

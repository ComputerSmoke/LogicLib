using LogicLib.Gates.Solo;
using LogicLib.Gates;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrideUtils;
using Stride.Core.Mathematics;

namespace LogicLib.Devices.Output
{
    public class Gauge : Device
    {
        private ReverseBoneBinding boneBinding;
        public override void Start()
        {
            base.Start();
            boneBinding = new("Needle", Entity.Get<ModelComponent>().Skeleton);
        }
        public override void GateChange(Gate gate)
        {
            float angle = (float)Math.Max(0, Math.Min(180, Math.PI * gate.State / 180));
            Quaternion rotation = Quaternion.RotationAxis(Vector3.UnitY, angle);
            boneBinding.Rotate(rotation);
        }
    }
}

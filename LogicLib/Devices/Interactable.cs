using LogicLib.Gates;
using Stride.Animations;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices
{
    public abstract class Interactable : Device
    {
        protected AnimationComponent animations;
        public override void Start()
        {
            base.Start();
            animations = Entity.Get<AnimationComponent>();
        }
        public abstract void Interact();
    }
}

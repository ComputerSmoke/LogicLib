using LogicLib.Gates;
using Stride.Animations;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices.Input.Interactables
{
    public abstract class Interactable : Device
    {
        protected AnimationComponent animations;
        public override Task Execute()
        {
            animations = Entity.Get<AnimationComponent>();
            return Task.CompletedTask;
        }
        public abstract void Interact();
    }
}

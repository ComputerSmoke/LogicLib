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
        protected AnimationComponent Animations => _animations ??= Entity.Get<AnimationComponent>();
        AnimationComponent _animations;
        public abstract void Interact();
    }
}

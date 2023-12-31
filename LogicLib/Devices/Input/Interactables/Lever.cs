using LogicLib.Gates.Settable;
using LogicLib.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Vulkan;
using Stride.Animations;

namespace LogicLib.Devices.Input.Interactables
{
    public class Lever : Interactable
    {
        private SettableGate output;
        private bool down;
        private PlayingAnimation animation;
        public override Task Execute()
        {
            base.Execute();
            output = Entity.FindInChild<SettableGate>();
            animation = animations.Play("interact");
            animation.TimeFactor = 0f;
            animation.RepeatMode = AnimationRepeatMode.PlayOnceHold;
            return Task.CompletedTask;
        }

        public override void GateChange(Gate gate) { }

        public override void Interact()
        {
            down = !down;
            output.SetNextState(down ? -1 : 0);
            if (down)
                animation.TimeFactor = 1f;
            else
                animation.TimeFactor = -1f;
        }
    }
}

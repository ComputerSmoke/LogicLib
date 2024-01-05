using LogicLib.Gates.Settable;
using LogicLib.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Vulkan;
using Stride.Animations;
using StrideUtils;

namespace LogicLib.Devices.Input.Interactables
{
    public class Lever : Interactable
    {
        SettableGate Output => _output ??= Entity.FindInChild<SettableGate>();
        SettableGate _output;
        bool down;
        PlayingAnimation animation;
        public override void Start()
        {
            base.Start();
            animation = Animations.Play("interact");
            animation.TimeFactor = 0f;
            animation.RepeatMode = AnimationRepeatMode.PlayOnceHold;
        }

        public override void GateChange(Gate gate) { }

        public override void Interact()
        {
            down = !down;
            Output.SetNextState(down ? -1 : 0);
            if (down)
                animation.TimeFactor = 1f;
            else
                animation.TimeFactor = -1f;
        }
    }
}

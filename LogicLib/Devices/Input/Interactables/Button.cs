using LogicLib.Gates;
using LogicLib.Gates.Settable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Animations;
using StrideUtils;

namespace LogicLib.Devices.Input.Interactables
{
    public class Button : Interactable
    {
        OneTickGate Output => _output ??= Entity.FindInChild<OneTickGate>();
        OneTickGate _output;
        public override void GateChange(Gate gate) { }

        public override void Interact()
        {
            Output.SetNextState(-1);
            var animation = Animations.Play("interact");
            animation.RepeatMode = AnimationRepeatMode.PlayOnce;
            animation.TimeFactor = 5f;
        }
    }
}

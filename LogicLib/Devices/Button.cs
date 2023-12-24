using LogicLib.Gates;
using LogicLib.Gates.Settable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Animations;

namespace LogicLib.Devices
{
    public class Button : Interactable
    {
        private OneTickGate output;
        public override void Start()
        {
            base.Start();
            output = Entity.FindInChild<OneTickGate>();
        }

        public override void GateChange(Gate gate) {}

        public override void Interact()
        {
            output.SetNextState(true);
            var animation = animations.Play("interact");
            animation.RepeatMode = AnimationRepeatMode.PlayOnce;
            animation.TimeFactor = 5f;
        }
    }
}

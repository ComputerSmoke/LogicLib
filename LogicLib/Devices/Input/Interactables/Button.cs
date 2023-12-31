using LogicLib.Gates;
using LogicLib.Gates.Settable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Animations;

namespace LogicLib.Devices.Input.Interactables
{
    public class Button : Interactable
    {
        private OneTickGate output;
        public override Task Execute()
        {
            base.Execute();
            output = Entity.FindInChild<OneTickGate>();
            return Task.CompletedTask;
        }

        public override void GateChange(Gate gate) { }

        public override void Interact()
        {
            output.SetNextState(-1);
            var animation = animations.Play("interact");
            animation.RepeatMode = AnimationRepeatMode.PlayOnce;
            animation.TimeFactor = 5f;
        }
    }
}

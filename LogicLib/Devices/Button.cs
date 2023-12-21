using LogicLib.Gates;
using LogicLib.Gates.Settable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}

using LogicLib.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Devices
{
    public abstract class Interactable : Device
    {
        public abstract void Interact();
    }
}

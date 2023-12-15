﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates.Solo
{
    public class NotGate : SoloGate
    {
        protected override bool ComputeNextState(bool in1)
        {
            return !in1;
        }
    }
}
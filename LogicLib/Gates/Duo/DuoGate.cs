﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class ConnectorMiscountException(string msg) : Exception(msg) { }
    //logic gate with two inputs
    public abstract class DuoGate : Gate
    {
        protected override long ComputeNextState(long[] inputs)
        {
            if (inputs.Length != 2)
                throw new ConnectorMiscountException("Duo gate must have 2 input connectors.");
            return ComputeNextState(inputs[0], inputs[1]);
        }
        protected abstract long ComputeNextState(long in1, long in2);
    }
}

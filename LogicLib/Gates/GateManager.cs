using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrideUtils;
using System.Collections;

namespace LogicLib.Gates
{
    internal class GateManager(int sleepMs) : Manager<Gate>(sleepMs)
    {
        public const int DefaultTickDelay = 50;
        public static GateManager Manager = new(DefaultTickDelay);
        //Set next state of all entries, then change current states
        protected override void ManageEntries()
        {
            Queue<Gate> middleQueue = new();
            while (queue.TryDequeue(out Gate entry))
            {
                if (entry == null)
                    continue;
                entry.UpdateNextState();
                middleQueue.Enqueue(entry);
            }
            while(middleQueue.TryDequeue(out Gate entry))
            {
                entry.UpdateState();
                //TODO: optimize, only enqueue those whose inputs changed
                queue.Enqueue(entry);
            }
        }
        protected override void ManageEntry(Gate entry) {}
    }
}

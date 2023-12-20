﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public static class Ticker
    {
        static readonly Queue<Gate> newTicks = [];
        static readonly HashSet<Gate> toTick = [];
        static bool ticking;
        public static int TickDelay = 100;
        //Enqueue a gate to update at next tick
        public static void UpdateGate(Gate gate)
        {
            newTicks.Enqueue(gate);
            Tick();
        }
        //Tick all gates currently in tick queue, and enqueue gates which may be affected for next tick.
        private static async void Tick()
        {
            if (ticking)
                return;
            ticking = true;
            while (newTicks.Count > 0 || toTick.Count > 0)
            {
                await Task.Delay(TickDelay);
                while (newTicks.TryDequeue(out Gate gate))
                    toTick.Add(gate);
                foreach (Gate gate in toTick)
                    gate.UpdateNextState();
                foreach (Gate gate in toTick)
                    gate.UpdateState();
            }

            ticking = false;
        }
    }
}

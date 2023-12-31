using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public class TickerComponent : AsyncScript
    {

        Queue<Gate> newTicks;
        HashSet<Gate> toTick;
        public int TickDelay { get; set; } = 100;
        //Enqueue a gate to update at next tick
        public void UpdateGate(Gate gate)
        {
            newTicks.Enqueue(gate);
        }
        //Tick all gates currently in tick queue, and enqueue gates which may be affected for next tick.
        public override async Task Execute()
        {
            newTicks = [];
            toTick = [];
            Ticker.SetTicker(this);
            while (Game.IsRunning)
            {
                await Task.Delay(TickDelay);
                while (newTicks.TryDequeue(out Gate gate))
                    toTick.Add(gate);
                foreach (Gate gate in toTick)
                    gate.UpdateNextState();
                foreach (Gate gate in toTick)
                    gate.UpdateState();
            }
        }
    }
}

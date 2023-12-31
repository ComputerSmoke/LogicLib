using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Gates
{
    public static class Ticker
    {
        static TickerComponent tickerComponent;
        static Queue<Gate> awaitingInit = [];
        //Enqueue a gate to update at next tick
        public static void UpdateGate(Gate gate)
        {
            if(tickerComponent != null)
                tickerComponent.UpdateGate(gate);
            else
                awaitingInit.Enqueue(gate);
        }
        public static void SetTicker(TickerComponent ticker)
        {
            tickerComponent = ticker;
            while(awaitingInit.TryDequeue(out Gate gate))
                ticker.UpdateGate(gate);
        }
    }
}

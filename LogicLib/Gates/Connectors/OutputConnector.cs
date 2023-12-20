using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;
using Stride.Particles.Components;
using Stride.Engine;
using Stride.Core.Mathematics;
using System.Runtime.InteropServices;
using Stride.Particles.Initializers;

namespace LogicLib.Gates.Connectors
{
    public class MissingSubcomponentException(string msg) : Exception(msg);
    public class OutputConnector : Connector
    {
        private ParticleSystemComponent particleSystem;
        public override void Start()
        {
            base.Start();
            particleSystem = Entity.Get<ParticleSystemComponent>();
        }
        //Connect and set particle path indicating connection
        public override bool Connect(Connector connector)
        {
            if(!base.Connect(connector))
                return false;
            particleSystem.Enabled = true;
            Arc().Target = connector.Entity.Transform;
            particleSystem.Color = GetColor();
            return true;
        }
        private InitialPositionArc Arc()
        {
            foreach(ParticleInitializer init in particleSystem.ParticleSystem.Emitters[0].Initializers)
            {
                if (init is InitialPositionArc arc)
                    return arc;
            }
            throw new MissingSubcomponentException("Output connector must have arc to reposition.");
        }
        private Color4 GetColor()
        {
            return Read() ? new Color4(0, 1, 0) : new Color4(1, 0, 0);
        }
        public override void Disconnect()
        {
            base.Disconnect();
            particleSystem.Enabled = false;
        }
        public override void Tick()
        {
            Connected?.Tick();
            particleSystem.Color = GetColor();
        }
        public override bool Read()
        {
            return gate.State;
        }
    }
}

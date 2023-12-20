using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Engine;
using Stride.Input;
using Stride.Core.Mathematics;
using Stride.Rendering.ProceduralModels;
using Silk.NET.OpenXR;
using LogicLib.Gates.Connectors;

namespace Logic
{
    public class ConnectionTool : StartupScript
    {
        private Connector selected;
        public void Click(Connector connector)
        {
            if (connector == selected)
                Select(null);
            else if (selected == null || connector is InputConnector == selected is InputConnector)
                Select(connector);
            else if (selected.Connected != connector)
                Connect(connector);
            else
                Disconnect(connector);
        }
        //Disconnect selected from connector
        private void Disconnect(Connector connector)
        {
            selected.Disconnect();
            Release();
        }
        //Connect connector to selected connector
        private void Connect(Connector connector)
        {
            selected.Connect(connector);
            Release();
        }
        //Unselect selected connector
        private void Release()
        {
            if (selected == null)
                return;
            //TODO: revert color to normal
            selected = null;
        }
        //Select connector
        private void Select(Connector connector)
        {
            Release();
            if (connector == null)
                return;
            //TODO: color selected
            selected = connector;
        }
    }
}

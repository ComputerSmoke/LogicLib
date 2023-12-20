using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;
using Stride.Physics;
using LogicLib.Gates.Connectors;

namespace Logic
{
    public class ConnectionCaster : SyncScript
    {
        private ConnectionTool tool;
        private CameraComponent Camera;
        public override void Start()
        {
            base.Start();
            tool = Entity.Get<ConnectionTool>();
            Camera = Entity.Get<CameraComponent>();
        }
        public override void Update()
        {
            if (!Input.Mouse.IsButtonPressed(MouseButton.Left))
                return;
            var simulation = SceneSystem.SceneInstance.GetProcessor<PhysicsProcessor>()?.Simulation;
            var (res, dir) = ScreenPositionToWorldPositionRaycast(Input.Mouse.Position, Camera, simulation);
            if (!res.Succeeded)
                return;

            var connectors = res.Collider.Entity.GetAll<Connector>();
            if (!connectors.Any())
                return;
            var enumerator = connectors.GetEnumerator();
            enumerator.MoveNext();
            Connector connector = enumerator.Current;
            tool.Click(connector);
        }
        public static (HitResult, Vector3) ScreenPositionToWorldPositionRaycast(Vector2 screenPos, CameraComponent camera, Simulation simulation)
        {
            Matrix invViewProj = Matrix.Invert(camera.ViewProjectionMatrix);

            // Reconstruct the projection-space position in the (-1, +1) range.
            //    Don't forget that Y is down in screen coordinates, but up in projection space
            Vector3 sPos;
            sPos.X = screenPos.X * 2f - 1f;
            sPos.Y = 1f - screenPos.Y * 2f;

            // Compute the near (start) point for the raycast
            // It's assumed to have the same projection space (x,y) coordinates and z = 0 (lying on the near plane)
            // We need to unproject it to world space
            sPos.Z = 0f;
            var vectorNear = Vector3.Transform(sPos, invViewProj);
            vectorNear /= vectorNear.W;

            // Compute the far (end) point for the raycast
            // It's assumed to have the same projection space (x,y) coordinates and z = 1 (lying on the far plane)
            // We need to unproject it to world space
            sPos.Z = 1f;
            var vectorFar = Vector3.Transform(sPos, invViewProj);
            vectorFar /= vectorFar.W;

            // Raycast from the point on the near plane to the point on the far plane and get the collision result
            var result = simulation.Raycast(vectorNear.XYZ(), vectorFar.XYZ(), hitTriggers: true);
            var dir = vectorFar.XYZ() - vectorNear.XYZ();
            dir.Normalize();
            return (result, dir);
        }
    }
}

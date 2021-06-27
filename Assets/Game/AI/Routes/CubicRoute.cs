
namespace SpaceShooterProject.AI.Movements
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CubicRoute : Route
    {
        public override Vector2 CalculateBezierCurve(float t)
        {
            Vector2 position = Mathf.Pow((1 - t), 3) * controlPoints[0].position +
                3 * Mathf.Pow((1 - t), 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;

            return position;
        }

        protected override void DrawGizmosLine()
        {
            DrawCubicGizmosLine();
        }

        protected override bool IsPointsSet()
        {
            return controlPoints.Length == 4;
        }
    }
}


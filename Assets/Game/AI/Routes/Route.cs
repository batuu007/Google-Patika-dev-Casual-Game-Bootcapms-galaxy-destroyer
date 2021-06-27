namespace SpaceShooterProject.AI.Movements
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Route : MonoBehaviour
    {
        [SerializeField]
        protected Transform[] controlPoints;

        [SerializeField]
        private bool showLines;

        [SerializeField]
        private bool showPath;

        private Vector2 gizmosPosition;

        public abstract Vector2 CalculateBezierCurve(float t);

        protected abstract void DrawGizmosLine();

        protected abstract bool IsPointsSet();

        private void OnDrawGizmos()
        {

            if (IsPointsSet())
            {
                for (float t = 0; t <= 1; t += 0.05f)
                {
                    gizmosPosition = CalculateBezierCurve(t);

                    if (showPath) Gizmos.DrawSphere(gizmosPosition, 10f);
                }

                if (showLines) DrawGizmosLine();
            }


        }

        protected void DrawLinearGizmosLine()
        {
            if (controlPoints.Length == 2)
            {
                Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
                new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));
            }
            else
            {
                Debug.LogError("Wrong draw gizmos line function. ");
            }

        }

        protected void DrawQuadraticGizmosLine()
        {
            if (controlPoints.Length == 3)
            {
                Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
                new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

                Gizmos.DrawLine(new Vector2(controlPoints[1].position.x, controlPoints[1].position.y),
                new Vector2(controlPoints[2].position.x, controlPoints[2].position.y));
            }
            else
            {
                Debug.LogError("Wrong draw gizmos line function. ");
            }

        }

        protected void DrawCubicGizmosLine()
        {
            if (controlPoints.Length == 4)
            {
                Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
                new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

                Gizmos.DrawLine(new Vector2(controlPoints[1].position.x, controlPoints[1].position.y),
                new Vector2(controlPoints[2].position.x, controlPoints[2].position.y));

                Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
                new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
            }
            else
            {
                Debug.LogError("Wrong draw gizmos line function. ");
            }

        }

        public void AddControlPoint(Transform newPoint)
        {
            controlPoints[controlPoints.Length] = newPoint;
        }
    }

}


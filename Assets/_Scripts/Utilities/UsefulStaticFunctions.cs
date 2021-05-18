using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class UsefulStaticFunctions
    {
        public static Transform GetClosestEnemy(Vector2 position,Transform[] enemies)
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;     
            foreach (Transform t in enemies)
            {
                float dist = Vector2.Distance(t.position, position);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        public static Transform GetClosestEnemy(Vector2 position, List<Transform> enemies)
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            foreach (Transform t in enemies)
            {
                float dist = Vector2.Distance(t.position, position);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        public static Transform GetClosestEnemy(Vector2 position, Collider2D[] enemies)
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            foreach (Collider2D t in enemies)
            {
                float dist = Vector2.Distance(t.transform.position, position);
                if (dist < minDist)
                {
                    tMin = t.transform;
                    minDist = dist;
                }
            }
            return tMin;
        }


    }
}

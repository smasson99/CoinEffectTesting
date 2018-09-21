using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathPositionUtils
{
    public static Vector3 GetInRangePosition(Vector3 currentPosition, Vector3 limits)
    {
        if (IsOutOfLimits(currentPosition, limits))
        {
            return new Vector3(Mathf.Clamp(currentPosition.x, -limits.x, limits.x), 
                Mathf.Clamp(currentPosition.y, -limits.y, limits.y), 
                Mathf.Clamp(currentPosition.z, -limits.z, limits.z));
        }

        return currentPosition;
    }

    public static bool IsOutOfLimits(Vector3 currentPosition, Vector3 limits)
    {
        return currentPosition.x >= limits.x ||
               currentPosition.x <= -limits.x ||
               currentPosition.y >= limits.y ||
               currentPosition.y <= -limits.y ||
               currentPosition.z >= limits.z ||
               currentPosition.z <= -limits.z;
    }

    public static bool IsNearLimits(Vector3 currentPosition, Vector3 limits, float nearDistance)
    {
        return -limits.x + nearDistance >= currentPosition.x ||
               limits.x - nearDistance <= currentPosition.x ||
               -limits.y + nearDistance >= currentPosition.y ||
               limits.y - nearDistance <= currentPosition.y ||
               -limits.z + nearDistance >= currentPosition.z ||
               limits.z - nearDistance <= currentPosition.z;
    }

    public static Vector3 Generate3DPointInLimits(Vector3 currentPosition, Vector3 limits)
    {
        Vector3 randomPoint = new Vector3(Random.Range(-limits.x, limits.x),
            Random.Range(-limits.y, limits.y),
            Random.Range(-limits.z, limits.z));
        
        while (randomPoint == currentPosition)
        {
            randomPoint = new Vector3(Random.Range(-limits.x, limits.x),
                Random.Range(-limits.y, limits.y),
                Random.Range(-limits.z, limits.z));
        }
        
        return randomPoint;
    }
    
    public static Vector3 Generate3DPointInLimits(Vector3 limits)
    {
        return new Vector3(Random.Range(-limits.x, limits.x),
            Random.Range(-limits.y, limits.y),
            Random.Range(-limits.z, limits.z));
    }

    public static bool IsNearTarget(Vector3 currentPosition, Vector3 targetPosition, float radius)
    {
        Vector3 distanceVector3 = targetPosition - currentPosition;
        return distanceVector3.magnitude <= radius;
    }
}
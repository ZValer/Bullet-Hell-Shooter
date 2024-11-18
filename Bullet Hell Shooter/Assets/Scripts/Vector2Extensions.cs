using UnityEngine;

public static class Vector2Extensions
{

    // Gira un vector en cierto número de grados
    public static Vector2 Rotate(this Vector2 originalVector, float rotateAngleInDegrees)
    {
        Quaternion rotation = Quaternion.AngleAxis(rotateAngleInDegrees, Vector3.forward);
        return rotation * originalVector;
    }
}

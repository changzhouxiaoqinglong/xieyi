
using UnityEngine;

public static class VectorExtension
{
    public static CustVect3 ToCustVect3(this Vector3 vect3)
    {
        return new CustVect3(vect3.x, vect3.y, vect3.z);
    }
}

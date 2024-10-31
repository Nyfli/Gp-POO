using System;
using UnityEngine;

public struct MyVector3
{
    public void Awake()
    {
        MyVector3 a = new MyVector3(1, 2, 3);
        MyVector3 b = new MyVector3(4, 5, 6);
        MyVector3 c = a + b;
        Debug.Log("c = " + c.X + " " + c.Y + " " + c.Z);
    }

    private float _x;
    private float _y;
    private float _z;

    // Propriétés pour accéder aux valeurs de x, y et z
    public float X
    {
        get { return _x; }
        set { _x = value; }
    }

    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public float Z
    {
        get { return _z; }
        set { _z = value; }
    }

    // calculer la Magnitude et la SqrtMagnitude
    public float Magnitude
    {
        get { return Mathf.Sqrt(_x * _x + _y * _y + _z * _z); }
    }

    public float SqrtMagnitude
    {
        get { return _x * _x + _y * _y + _z * _z; }
    }

    public float SqrtMagnitudeOpti
    {
        get { return _x * _x + _y * _y + _z * _z; }
    }

    public void Normalize()
    {
        float magnitude = Magnitude;
        if (magnitude > 0)
        {
            _x /= magnitude;
            _y /= magnitude;
            _z /= magnitude;
        }
    }

    // Surcharge opérateur + additionner CustomVector3
    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a._x + b._x, a._y + b._y, a._z + b._z);
    }

    public static MyVector3 operator *(MyVector3 a, float b)
    {
        return new MyVector3(a._x * b, a._y * b, a._z * b);
    }

    public MyVector3(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

}

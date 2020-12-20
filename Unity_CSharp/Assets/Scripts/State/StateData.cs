using System;
using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    [Serializable]
    public sealed class StateData
    {
        public string Name;
        public Vector3Serializable Position;
        public BonusSerializable[] Bonuses;
    }

    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Serializable(float valX, float valY, float valZ)
        {
            X = valX;
            Y = valY;
            Z = valZ;
        }

        public static implicit operator Vector3(Vector3Serializable val)
        {
            return new Vector3(val.X, val.Y, val.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 val)
        {
            return new Vector3Serializable(val.x, val.y, val.z);
        }

        public override string ToString()
        {
            return $"(X = {X} Y = {Y} Z = {Z})";
        }
    }

    [Serializable]
    public struct BonusSerializable
    {
        public Vector3Serializable position;
        public int instanceID;
        public string type;
    }
}
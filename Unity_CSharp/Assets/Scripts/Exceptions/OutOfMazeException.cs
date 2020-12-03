using System;
using UnityEngine;

namespace GeekbrainsUnityCSharp
{
    public class OutOfMazeException : Exception
    {
        public Vector3 Position { get; }

        public OutOfMazeException(Vector3 position) : base($"How is it possible?? Player position {position.ToString()} is out of Maze!")
        {
            Position = position;
        }


    }
}
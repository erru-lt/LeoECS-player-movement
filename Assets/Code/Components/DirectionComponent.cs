using System;
using UnityEngine;

namespace Assets.Code.Components
{
    [Serializable]
    public struct DirectionComponent
    {
        [HideInInspector] public Vector2 Axis;
    }
}
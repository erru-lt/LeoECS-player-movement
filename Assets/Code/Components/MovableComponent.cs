using System;
using UnityEngine;

namespace Assets.Code.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public float MoveSpeed;
    }
}
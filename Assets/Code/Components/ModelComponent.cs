using System;
using UnityEngine;

namespace Assets.Code.Components
{
    [Serializable]
    public struct ModelComponent
    {
        public Transform ModelTransform;
        public Animator ModelAnimator;
    }
}
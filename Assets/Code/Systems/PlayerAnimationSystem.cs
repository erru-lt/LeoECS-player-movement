using Assets.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private static readonly int RunningHash = Animator.StringToHash("Running");

        private readonly EcsFilter<ModelComponent, MovableComponent> _animationFilter;

        public void Run()
        {
            foreach (int entityIndex in _animationFilter)
            {
                ref ModelComponent modelComponent = ref _animationFilter.Get1(entityIndex);
                ref MovableComponent movableComponent = ref _animationFilter.Get2(entityIndex);

                ref Animator animator = ref modelComponent.ModelAnimator;
                ref CharacterController characterController = ref movableComponent.CharacterController;

                animator.SetFloat(RunningHash, characterController.velocity.magnitude);
            }
        }
    }
}
using Assets.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, ModelComponent, DirectionComponent, CameraComponent> _movableFilter = null;

        public void Run()
        {
            foreach (int entityIndex in _movableFilter)
            {
                ref MovableComponent movableComponent = ref _movableFilter.Get1(entityIndex);
                ref ModelComponent modelComponent = ref _movableFilter.Get2(entityIndex);
                ref DirectionComponent directionComponent = ref _movableFilter.Get3(entityIndex);
                ref CameraComponent cameraComponent = ref _movableFilter.Get4(entityIndex);

                ref CharacterController characterController = ref movableComponent.CharacterController;
                ref float moveSpeed = ref movableComponent.MoveSpeed;

                ref Transform transform = ref modelComponent.ModelTransform;

                ref Vector2 axis = ref directionComponent.Axis;

                ref Camera camera = ref cameraComponent.FollowCamera;

                Move(characterController, transform, moveSpeed, axis, camera);
            }
        }

        private void Move(CharacterController characterController, Transform transform, float moveSpeed, Vector2 axis, Camera camera)
        {
            Vector3 movementVector = Vector3.zero;

            if (axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = camera.transform.TransformDirection(axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            characterController.Move(moveSpeed * Time.deltaTime * movementVector);
        }
    }
}
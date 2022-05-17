using Assets.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DirectionComponent> _directionFilter = null;
        private Vector2 Axis;

        public void Run()
        {
            GetAxis();

            foreach (int entityIndex in _directionFilter)
            {
                ref DirectionComponent directionComponent = ref _directionFilter.Get1(entityIndex);
                directionComponent.Axis = Axis;
            }
        }

        private void GetAxis() => 
            Axis = new Vector2(
                SimpleInput.GetAxis(JoystickAxis.Horizontal),
                SimpleInput.GetAxis(JoystickAxis.Vertical));
    }
}
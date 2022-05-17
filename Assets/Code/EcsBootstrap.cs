using Assets.Code.Systems;
using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class EcsBootstrap : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddSystems();

        _systems.Init();
    }

    private void AddSystems()
    {
        _systems.Add(new PlayerInputSystem()).
            Add(new PlayerMovementSystem()).
            Add(new PlayerAnimationSystem());
    }

    private void Update() => 
        _systems.Run();

    private void OnDestroy()
    {
        if (_systems == null) return;

        _systems.Destroy();
        _systems = null;

        _world.Destroy();
        _world = null;
    }
}

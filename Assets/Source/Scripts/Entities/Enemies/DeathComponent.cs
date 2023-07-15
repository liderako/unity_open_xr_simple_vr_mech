using System;
using Source.Scripts.Core.Interfaces;
using Source.Scripts.Entities.Enemies.Interfaces;
using UnityEngine;

namespace Source.Scripts.Entities.Enemies
{
    public class DeathComponent : BaseComponent, IDeathComponent
    {
        public event Action<Vector3> Death;

        public void CallDeath(Vector3 hitPosition)
        {
            Death?.Invoke(hitPosition);
        }
    }
}
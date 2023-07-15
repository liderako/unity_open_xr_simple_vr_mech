using Source.Scripts.Entities.Enemies.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Scripts.Entities.Enemies
{
    public class OnCollisionEnterDeathComponent : MonoBehaviour
    {
        [Inject] private IDeathComponent deathComponent;
        private const string TagWeapon = "Weapon";
        private void OnCollisionEnter(Collision other)
        {
            if (IsCorrectTarget(other))
            {
                deathComponent.CallDeath(other.contacts[0].point);
            }
        }

        private static bool IsCorrectTarget(Collision collision)
        {
            return collision.gameObject.CompareTag(TagWeapon);
        }
    }
}
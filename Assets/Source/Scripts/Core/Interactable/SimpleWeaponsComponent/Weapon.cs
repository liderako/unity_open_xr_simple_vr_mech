using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Source.Scripts.Core.Interactable
{
    public class Weapon : MonoBehaviour, IInteractableActivateListener
    {
        //TODO need create settings for different weapons
        
        [SerializeField] private GameObject bulletDemo;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float speed;
        
        public void Interact(ActivateEventArgs args)
        {
            GameObject bullet = GetBullet();
            bullet.transform.position = spawnPoint.position;
            bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        }

        public GameObject GetBullet()
        {
            return Instantiate(bulletDemo); // todo change logic for bullets on object pool or smth another
        }
    }
}
using Source.Scripts.ZXRCore.Avatar;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace ZXRCore.Interactable
{
    public class ZXRGrabInteractableTwoAttach : ZXRGrabInteractable
    {
        [field:SerializeField] public Transform LeftAttachTransform { get; set; }
        [field:SerializeField] public Transform RightAttachTransform { get; set; }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = LeftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = RightAttachTransform;
            }

            // if (args.interactorObject.transform.gameObject.TryGetComponent(out AvatarComponent avatarComponent))
            // {
            //     Debug.Log("test");
            // }
            base.OnSelectEntered(args);
        }
    }
}
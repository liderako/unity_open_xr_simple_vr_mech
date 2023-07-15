using Source.Scripts.Core.Interfaces;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Source.Scripts.ZXRCore.Avatar
{
    public class GrabHandPoseComponent : BaseComponent
    {
        public HandDataComponent rightHandPose;
        
        private XRGrabInteractable grabInteractable;
        private Vector3 startHandPosition;
        private Vector3 endHandPosition;
        private Quaternion startHandRotation;
        private Quaternion endHandRotation;

        private Quaternion[] startFingerRotations;
        private Quaternion[] endFingerRotations;
        
        private void Start()
        {
            InitComponentInGameObject(out grabInteractable);
            
            grabInteractable.selectEntered.AddListener(SetupPose);
            grabInteractable.selectExited.AddListener(UnSetupPose);
            rightHandPose.gameObject.SetActive(false);
        }

        private void SetupPose(BaseInteractionEventArgs args)
        {
            if (args.interactableObject is XRDirectInteractor)
            {
                HandDataComponent handDataComponent = args.interactorObject.transform.GetComponentInChildren<HandDataComponent>();
                handDataComponent.animator.enabled = false;
                SetHandDataValues(handDataComponent, rightHandPose);
                SetHandData(handDataComponent, endHandPosition, endHandRotation, endFingerRotations);
            }
        }

        private void UnSetupPose(BaseInteractionEventArgs args)
        {
            HandDataComponent handDataComponent = args.interactorObject.transform.GetComponentInChildren<HandDataComponent>();
            handDataComponent.animator.enabled = true;
            SetHandData(handDataComponent, startHandPosition, startHandRotation, startFingerRotations);
        }

        private void SetHandDataValues(HandDataComponent h1, HandDataComponent h2)
        {
            startHandPosition = new Vector3(
                h1.root.localPosition.x / h1.root.localScale.x,
                h1.root.localPosition.y / h1.root.localScale.y,
                h1.root.localPosition.z / h1.root.localScale.z);
            endHandPosition = new Vector3(
                h2.root.localPosition.x / h2.root.localScale.x,
                h2.root.localPosition.y / h2.root.localScale.y,
                h2.root.localPosition.z / h2.root.localScale.z);

            startHandRotation = h1.root.localRotation;
            endHandRotation = h2.root.localRotation;

            startFingerRotations = new Quaternion[h1.fingerBones.Length];
            endFingerRotations = new Quaternion[h1.fingerBones.Length];

            for (int i = 0; i <  h1.fingerBones.Length; i++)
            {
                startFingerRotations[i] = h1.fingerBones[i].localRotation;
                endFingerRotations[i] = h2.fingerBones[i].localRotation;
            }
        }

        private void SetHandData(HandDataComponent h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
        {
            h.root.localPosition = newPosition;
            h.root.localRotation = newRotation;
            for (int i = 0; i < h.fingerBones.Length; i++)
            {
                h.fingerBones[i].localRotation = newBonesRotation[i];
            }
        }
    }
}
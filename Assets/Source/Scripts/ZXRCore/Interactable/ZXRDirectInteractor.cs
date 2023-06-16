﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Zenject;

namespace ZXRCore.Interactable
{
    public class ZXRDirectInteractor : XRDirectInteractor
    {
        [Inject]
        private void InitializeInteractionManager(XRInteractionManager xrInteractionManager)
        {
            this.interactionManager = xrInteractionManager;
        }
    }
}
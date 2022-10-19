using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControlledCamera;
using Player;

public class AnimationSelfHide : MonoBehaviour
{
    public CameraControl cameraControl;
    public Movement playerMovement;

    void Hide()
    {
        gameObject.SetActive(false);
        cameraControl.StopShake();
        playerMovement.AllowRotation(true);
    }
}

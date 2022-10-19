using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace ControlledCamera
{
    public class CameraControl : MonoBehaviour
    {
        CinemachineVirtualCamera vcam;
        CinemachineBasicMultiChannelPerlin noiseComponent;

        public float shakeAmp;
        public float shakeFrequency;

        void Start()
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
            noiseComponent = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Shake()
        {
            noiseComponent.m_AmplitudeGain = shakeAmp;
            noiseComponent.m_FrequencyGain = shakeFrequency;
        }

        public void StopShake()
        {
            noiseComponent.m_AmplitudeGain = 0;
            noiseComponent.m_FrequencyGain = 0;
        }
    }
}

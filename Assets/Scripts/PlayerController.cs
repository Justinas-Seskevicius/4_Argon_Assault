using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("Meters per sec")] [SerializeField] float speed = 20f;
    [Tooltip("Movement range for X")] [SerializeField] float xRange = 3.8f;
    [Tooltip("Movement range for Y")] [SerializeField] float yRange = 2.25f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isAlive = true;

    void Update()
    {
        if(isAlive)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow =  yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawNexYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(rawNewXPos, rawNexYPos, transform.localPosition.z);
    }

    private void OnPlayerDeath()    // called by string-referene
    {
        transform.Find("ExplosionSFX").gameObject.SetActive(true);
        isAlive = false;
    }
}

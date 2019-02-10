using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("Meters per sec")] [SerializeField] float xSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = horizontalThrow * xSpeed * Time.deltaTime;
        Debug.Log(xOffsetThisFrame);
    }
}

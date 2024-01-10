using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] Camera charCam;
    [SerializeField] private float lockedPosition = 0f;

    private void Update()
    {
        Vector3 currentPosition = charCam.transform.position;

        currentPosition.x = lockedPosition;

        charCam.transform.position = currentPosition;
    }
}
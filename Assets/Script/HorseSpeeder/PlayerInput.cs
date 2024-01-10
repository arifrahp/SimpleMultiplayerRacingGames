using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;

    private HorseSpeeder horseSpeeder;

    private void Start()
    {
        horseSpeeder = GetComponent<HorseSpeeder>();
    }

    private void Update()
    {
        if (!horseSpeeder.isFinishLineReached && !horseSpeeder.isPhasing)
        {
            if (Input.GetKeyDown(upKey))
            {
                horseSpeeder.OnBoost();
            }

            if (Input.GetKeyDown(downKey))
            {
                horseSpeeder.OnBreak();
            }

            if (Input.GetKey(leftKey))
            {
                horseSpeeder.MoveLeft();
            }

            if (Input.GetKey(rightKey))
            {
                horseSpeeder.MoveRight();
            }

            if (Input.GetKeyUp(upKey))
            {
                horseSpeeder.ReleaseBoost();
            }
            
            if (Input.GetKeyUp(downKey))
            {
                horseSpeeder.ReleaseBrake();
            }
            
            if (Input.GetKeyUp(leftKey) || Input.GetKeyUp(rightKey))
            {
                horseSpeeder.ReleaseTurn();
            }
        }
    }
}
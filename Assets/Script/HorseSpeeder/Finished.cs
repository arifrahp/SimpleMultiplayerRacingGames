using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finished : MonoBehaviour
{
    [SerializeField] TMP_Text winText;
    private HorseSpeeder horseSpeeder;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {   
            winText.text = "Player 1 Win the Race!";
        }
        if (other.CompareTag("Player2"))
        {
            winText.text = "Player 2 Win the Race!";
        }
    }
}

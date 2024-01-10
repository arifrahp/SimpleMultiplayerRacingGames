using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public GameObject bull;
    public float speed;
    public PlayManager playManager;

    private void Update()
    {
        if (!playManager.isGameOver)
        {
            bull.transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}

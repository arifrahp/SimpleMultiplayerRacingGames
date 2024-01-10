using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HorseSpeeder : MonoBehaviour
{
    [SerializeField] GameObject horse;
    [SerializeField] Color originalColor;
    [SerializeField] AudioSource hitAudio;
    public AudioSource boostAudio;
    private float speed = 5f;
    private float speedOnTurn = 5f;
    public bool isPhasing = false;
    public bool isFinishLineReached = false;
    public bool isBoost = false;
    public bool isBrake = false;
    public bool isTurn = false;

    public ParticleSystem particleBoost;
    public UnityEvent boostParticle;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    private void Update()
    {
        if (!isPhasing && !isFinishLineReached)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void OnBoost()
    {
        isBrake = false;
        isBoost = true;
        if (!isTurn)
        {
            if(isBoost == true)
            {
                speed = 10;
                boostAudio.Play();
                particleBoost.Play();
            }
        }
    }

    public void OnBreak()
    {
        isBoost = false;
        isBrake = true;
        if(isBrake == true)
        {
            speed = 2;
        }
    }

    public void MoveLeft()
    {
        isTurn = true;
        if (!isBoost)
        {
            rb.velocity = new Vector3(-speedOnTurn, rb.velocity.y, 0f);
        }
    }

    public void MoveRight()
    {
        isTurn = true;
        if (!isBoost)
        {
            rb.velocity = new Vector3(speedOnTurn, rb.velocity.y, 0f);
        }
    }

    public void ReleaseBoost()
    {
        isBoost = false;
        speed = 5f;
        boostAudio.Stop();
        particleBoost.Stop();
    }
    public void ReleaseBrake()
    {
        isBrake = false;
        speed = 5f;
    }

    public void ReleaseTurn()
    {
        isTurn = false;
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bull"))
        {
            StartCoroutine(HitObject());
        }
        if (other.CompareTag("FinishLine"))
        {
            isFinishLineReached = true;
            boostAudio.Stop();
            PlayManager.Instance.GameOver();
        }
    }

    private IEnumerator HitObject()
    {
        isPhasing = true;
        hitAudio.Play();
        boostAudio.Stop();
        particleBoost.Stop();
        rb.velocity = Vector3.zero;
        LeanTween.color(horse, Color.red, 0.3f).setLoopCount(10);
        yield return new WaitForSeconds(3f);
        LeanTween.color(horse, originalColor, 0.3f);
        isBoost = false;
        isTurn = false;
        speed = 5f;

        isPhasing = false;  
    }
}

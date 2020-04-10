using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollisionSound : MonoBehaviour
{

    public AudioSource Source;
    private float RandomPitch;
    private float RandomVolume;
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        RandomPitch = Random.Range(0.5f, 1.5f);
        RandomVolume = Random.Range(0.2f, 1f);
        Source.pitch = RandomPitch;
        Source.volume = RandomVolume;
        Source.Play();
    }
}

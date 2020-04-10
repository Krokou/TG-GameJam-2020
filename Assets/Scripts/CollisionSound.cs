using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollisionSound : MonoBehaviour
{

    public AudioSource Source;
    private float RandomPitch;
    private float RandomVolume;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
        Source.mute = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartSoundDelay());
    }

    private void OnCollisionEnter(Collision collision)
    {
        RandomPitch = Random.Range(0.5f, 1.5f);
        RandomVolume = Random.Range(0.2f, 0.8f);
        Source.pitch = RandomPitch;
        Source.volume = RandomVolume;
        Source.Play();
    }

    private IEnumerator StartSoundDelay()
    {
        yield return new WaitForSeconds(1f);
        Source.mute = false;
    }
}

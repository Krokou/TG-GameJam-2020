using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundController : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    public float soundInterval = 2;
    public float intervalRandomOffsetMax = 0.5f;

    private float timeToNextSound;
    private float deltaTime = 0;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextSound = soundInterval + Random.Range(-intervalRandomOffsetMax, intervalRandomOffsetMax);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime > timeToNextSound)
        {
            playRandomSound();
            timeToNextSound = soundInterval + Random.Range(-intervalRandomOffsetMax, intervalRandomOffsetMax);
            deltaTime = 0;
        }
    }

    private void playRandomSound()
    {
        print(audioClips.Count);
        if (audioClips.Count != 0 && audioSource != null)
        {
            int index = Mathf.CeilToInt(Random.Range(0.0001f, audioClips.Count) - 1);
            audioSource.PlayOneShot(audioClips[index]);
        }
    }
}

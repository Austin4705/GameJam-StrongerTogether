using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundThenDie : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Sound(clip));
    }

    private IEnumerator Sound(AudioClip clip)
    {
        PlaySound();

        yield return new WaitForSeconds(clip.length+0.1f); //extra second added for buffer

        Destroy(gameObject);
    }

    private void PlaySound()
    {
        source.clip = clip;
        source.Play();
    }
}

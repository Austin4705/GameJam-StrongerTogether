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
        AudioSource.PlayClipAtPoint(clip, transform.position);

        yield return new WaitForSeconds(clip.length+0.1f); //extra second added for buffer

        Destroy(gameObject);
    }
}

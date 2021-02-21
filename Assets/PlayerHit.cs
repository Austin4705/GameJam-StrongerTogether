using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

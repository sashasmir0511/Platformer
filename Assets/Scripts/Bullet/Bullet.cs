using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    public float TimeDestroy = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

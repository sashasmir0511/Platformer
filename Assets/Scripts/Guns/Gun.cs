using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Flash;
    public Transform Spawn;
    public float BulletSpeed = 20f;
    public float ShotPeriod = 0.2f;
    public UnityEvent EventOnShot;
    public ParticleSystem ShotEffect;

    private float _timeShot = 0f;

    // Update is called once per frame
    void Update()
    {
        _timeShot += Time.unscaledDeltaTime;
        if (_timeShot >= ShotPeriod && Input.GetMouseButton(0))
        {
            _timeShot = 0f;
            Shot();
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        Flash.SetActive(true);
        Invoke("HideFlash", 0.6f);
        ShotEffect.Play();
        EventOnShot.Invoke();
    }

    void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullet(int numberOfBullet)
    {

    }
}

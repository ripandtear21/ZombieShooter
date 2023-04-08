using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletScript : MonoBehaviour
{
    public UnityEvent OnBulletHit;

    void OnCollisionEnter(Collision collision)
    {
        OnBulletHit.Invoke();
    }
}

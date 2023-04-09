using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> rigidBodies;

    private void Start()
    {
        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = true;
        }
    }

    public void SetRigidBodiesKinematic(bool isKinematic)
    {
        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = isKinematic;
        }
    }
}

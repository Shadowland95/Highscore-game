using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public abstract class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Activate(other);
    }

    public abstract void Activate(Collider collider);

    public void ChangeColour(Renderer renderer)
    {
        renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); 
    }
}

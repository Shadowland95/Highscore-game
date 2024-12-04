using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : TriggerZone
{
    public Powerup[] powerup;

    float speed = 20f;
    public int totalPUChances;

    float cooldown = 0;

    public void Start()
    {
        totalPUChances = 0;
        foreach (Powerup PU in powerup) 
        {
            totalPUChances += PU.chance;
        }
    }

    public override void Activate(Collider collider)
    {
        if (cooldown > 0) return;

        Powerup chosenPU = null;
        int PUCountdown = Random.Range(0, totalPUChances);
        foreach (Powerup PU in powerup) 
        {
            PUCountdown -= PU.chance;
            if (PUCountdown < 0)
            {
                chosenPU = PU;
                break;
            }
        }

        if (chosenPU == null) return;
        chosenPU.UsePowerup(collider.attachedRigidbody);
        cooldown = chosenPU.cooldown;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        cooldown -= Time.deltaTime;
    }
}

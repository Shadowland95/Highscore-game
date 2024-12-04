using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/boost")]

public class Boost : Powerup
{
    public override void UsePowerup(Rigidbody rb)
    {
        rb.AddRelativeForce(Vector3.forward * power, ForceMode.VelocityChange);
    }
}

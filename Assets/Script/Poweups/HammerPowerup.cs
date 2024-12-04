using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/hammer")]

public class HammerPowerup : Powerup
{
    public override void UsePowerup(Rigidbody rb)
    {
        Debug.Log("HAMMER TIME");
    }
}

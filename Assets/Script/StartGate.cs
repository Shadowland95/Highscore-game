using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : TriggerZone
{
    public override void Activate(Collider collider)
    {
        //Change colour of marble
        ChangeColour(collider.GetComponent<Renderer>());

        if (Timer.instance != null)
        {
            Timer.instance.StartTimer();
        }
    }
}

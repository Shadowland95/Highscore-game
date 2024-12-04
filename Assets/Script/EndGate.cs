using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : TriggerZone
{
    HighScoreSystem highscore;

    public void Start()
    {
        highscore = FindAnyObjectByType<HighScoreSystem>();
    }

    public override void Activate(Collider collider)
    {
        if(Timer.instance)
        {
            Debug.Log(Timer.instance.CurrentTime());
            highscore.NewScore(Timer.instance.CurrentTime());
        }
    }
}

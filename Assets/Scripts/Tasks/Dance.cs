using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Dance : Node
{
    private float TimeRemaining = 10f;
    public override void InitializeNode(string descriptor = " ")
    {
        base.InitializeNode(descriptor);
        // set the time that the AI should dance for
        if (float.TryParse(descriptor, out float value))
        {
            TimeRemaining = value;
        }
    }
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        // dance until the time is up
        TimeRemaining -= deltaTime;
        if (TimeRemaining < 0)
        {
            finishExcecute(true);
        }
        Debug.Log("I'm doing a dance!");
    }

}

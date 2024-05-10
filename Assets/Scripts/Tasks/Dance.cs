using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Dance : Node
{
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        Debug.Log("I do be dancin tho");
    }

}

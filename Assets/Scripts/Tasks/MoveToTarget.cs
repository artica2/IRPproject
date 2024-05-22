using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MoveToTarget : Node
{
    public GameObject target; // target to move towards
    public float speed = 3; // speed to move

    public override void InitializeNode(string descriptor = " ")
    {
        // OBJs are hardcoded as no sensing/vision set up on the AI
        if (descriptor == "Red")
        {
            target = TreeBuilder.instance.targetOBJRed;
        } else if (descriptor == "Green")
        {
            target = TreeBuilder.instance.targetOBJGreen;
        } else if (descriptor == "Blue")
        {
            target = TreeBuilder.instance.targetOBJBlue ;
        }
        base.InitializeNode();
    }
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        // work out direction to move and move there with speed 'speed'
        Vector3 displacement = target.transform.position - obj.transform.position;
        Vector3 direction = displacement.normalized;
        obj.transform.position += direction * speed * deltaTime;
        if (displacement.magnitude < 3) // when close enough, task has completed
        {
            finishExcecute(true);
        }
    }
}

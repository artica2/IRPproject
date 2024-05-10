using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : Node
{
    public GameObject target;
    public float speed = 3;
    // Start is called before the first frame update
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        Vector3 displacement = target.transform.position - obj.transform.position;
        Vector3 direction = displacement.normalized;
        obj.transform.position += direction * speed * deltaTime;
        if (displacement.magnitude < 3)
        {
            finishExcecute(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

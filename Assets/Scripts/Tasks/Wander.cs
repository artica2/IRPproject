using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Node
{
    private Vector3 randomPosition;
    private float radius;
    public float speed = 3;

    public override void InitializeNode(string descriptor = " ")
    {
        base.InitializeNode(descriptor);
        if (!float.TryParse(descriptor, out radius))
        {
            radius = 10f;
        }
        randomPosition = Vector3.zero;
    }

    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        if (randomPosition == Vector3.zero)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += obj.transform.position;
            randomDirection.y = obj.transform.position.y;
            randomPosition = randomDirection;
        }

        Vector3 displacement = randomPosition - obj.transform.position;
        Vector3 direction = displacement.normalized;
        obj.transform.position += direction * speed * deltaTime;

        if (displacement.magnitude < 3)
        {
            // wander never finishes execute as its base behaviour
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += obj.transform.position;
            randomDirection.y = obj.transform.position.y;
            randomPosition = randomDirection;
        }
    }
}

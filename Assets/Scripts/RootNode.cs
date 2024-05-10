using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : Node
{
    public int currentNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        
        if (currentNode == NumberOfChildren)
        {
            currentNode = 0; // start tree again
        }
        behaviourTree.currentNode = Children[currentNode]; // tell the tree which node is active
        Children[currentNode].isActiveNode = true;
        currentNode++;
    }
}

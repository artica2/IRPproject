using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNode : Node
{
    public int currentNode; // which of the children is active

    public override void ExecuteNode(float deltaTime, GameObject obj)
    {    
        if (currentNode == NumberOfChildren)
        {
            currentNode = 0; // start tree again
        }
        if (Children.Count != 0)
        {
            behaviourTree.currentNode = Children[currentNode]; // tell the tree which node is active
            Children[currentNode].isActiveNode = true;
            currentNode++;
        }
    }
}

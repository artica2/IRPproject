using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public int currentNode; // which child is active

    public override void InitializeNode(string descriptor = " ")
    {
        base.InitializeNode();
        TreeBuilder.instance.contextNode = this; // as this is a flow node, it should be set as the context node
    }

    // Update is called once per frame
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
        // iterate through each child until either one fails or they all succeed
        if (Children[currentNode].finishedExecuting)
        {
            if (Children[currentNode].isSuccess) // if child executed successfully
            {
                currentNode++; // go to the next node
                if (currentNode != NumberOfChildren)
                {
                    behaviourTree.currentNode = Children[currentNode]; // tell the tree which node is active
                    Children[currentNode].isActiveNode = true;
                } else
                {
                    finishExcecute(true); // if all children have succeeded, sequence has succeeded
                }
            } else // child has failed
            {
                finishExcecute(false);
            }
        } else
        {
            behaviourTree.currentNode = Children[currentNode]; // tell the tree which node is active
            Children[currentNode].isActiveNode = true;
        }
        

    }


}

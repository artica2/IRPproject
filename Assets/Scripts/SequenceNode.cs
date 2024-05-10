using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public int currentNode;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void ExecuteNode(float deltaTime, GameObject obj)
    {
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

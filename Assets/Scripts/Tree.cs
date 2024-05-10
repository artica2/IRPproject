using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public RootNode rootNode;
    public Node currentNode;
    public GameObject AI;

    // Start is called before the first frame update
    void Start()
    {
        if (rootNode != null)
        {
            currentNode = rootNode;
            rootNode.isActiveNode = true;
        }   
    }

    // Update is called once per frame
    public void Execute()
    {
        if(currentNode.finishedExecuting == true)
        {
            currentNode.isActiveNode = false; // current Node is no longer active
            currentNode = currentNode.Parent; // go up in the tree
            currentNode.isActiveNode = true; // tell the new node it is active
        }
        else
        {
            
            currentNode.ExecuteNode(Time.deltaTime, AI);
            
        }
    }

}

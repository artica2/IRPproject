using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public RootNode rootNode; // tree root
    public Node currentNode; // active node
    public GameObject AI; // object being controlled
    public List<Node> nodes = new List<Node>(); // all nodes belonging to the tree

    // Start is called before the first frame update
    void Start()
    {
        if (rootNode != null)
        {
            currentNode = rootNode; // set the root node as the first node to be executed
            rootNode.isActiveNode = true;
        }   
    }

    // Update is called once per frame
    public void Execute()
    {
        if(currentNode.finishedExecuting == true) // if the current node has finished executing, move to the next
        {
            currentNode.isActiveNode = false; // current Node is no longer active
            currentNode = currentNode.Parent; // go up in the tree
            currentNode.isActiveNode = true; // tell the new node it is active
        } else // if the current node has not finished executing, continue executing it.
        {
            currentNode.ExecuteNode(Time.deltaTime, AI); 
        }
    }

}

using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node
{
    public bool finishedExecuting = false; // has the node finished executing
    public Node Parent; // the node's parent
    public List<Node> Children; // the node's children
    public int NumberOfChildren; // number of children
    public bool isActiveNode; // whether the node is the currently executing node
    public Tree behaviourTree; // the behaviour tree the node belongs to
    public bool isSuccess; // whether the node was successful in its execution

    // initialize the node
    public virtual void InitializeNode(string descriptor = " ")
    {
        Children = new List<Node>();
    }

    // parent class to be overwritten by children
    public virtual void ExecuteNode(float deltaTime, GameObject obj)
    {
        
    }

    public bool finishExcecute(bool success)
    {
        // tell the tree excecution is finished
        finishedExecuting = true;
        // return whether the node executed successfully
        isSuccess = success;
        return isSuccess;
    }

    public virtual void AddChild(Node child)
    {
        // add a child to the node
        Children.Add(child);
        NumberOfChildren++;
        child.Parent = this;
        this.behaviourTree.nodes.Add(child);
    }

}

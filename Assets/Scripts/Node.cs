using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node
{
    public bool finishedExecuting = false;
    public Node Parent;
    public List<Node> Children;
    public int NumberOfChildren;

    public bool isActiveNode;

    public Tree behaviourTree;

    public bool isSuccess;

    public void InitializeNode()
    {
        Children = new List<Node>();
    }

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
        Children.Add(child);
        NumberOfChildren++;
        child.Parent = this;
    }

}

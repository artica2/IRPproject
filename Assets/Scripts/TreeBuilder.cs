using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBuilder : MonoBehaviour
{
    private Tree behaviourTree;

    public GameObject targetOBJ;

    public static TreeBuilder instance;

    public Node contextNode;

    public Input InputField;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        behaviourTree = new Tree();
        behaviourTree.AI = this.gameObject;
        RootNode root = new RootNode();
        root.InitializeNode();
        behaviourTree.rootNode = root;
        root.isActiveNode = true;
        root.behaviourTree = behaviourTree;
        behaviourTree.currentNode = root;
        contextNode = root;
        // BASE STUFF
        SequenceNode sequenceNode = new SequenceNode();
        sequenceNode.InitializeNode();
        root.AddChild(sequenceNode);
        sequenceNode.behaviourTree = behaviourTree;
        MoveToTarget moveToTarget = new MoveToTarget();
        moveToTarget.InitializeNode();
        sequenceNode.AddChild(moveToTarget);
        moveToTarget.target = targetOBJ;
        moveToTarget.behaviourTree = behaviourTree;
        Dance dance = new Dance();
        dance.InitializeNode();
        sequenceNode.AddChild(dance);

    }

    private void Update()
    {
        if (behaviourTree != null)
        {
            behaviourTree.Execute();
        }
    }
    public List<string> ParseString(string stringToParse)
    {
        List<string> list = new List<string>();
        string targetString = string.Empty;
        for (int i = 0; i < stringToParse.Length; i++)
        {
            if (stringToParse[i] == ' ')
            {
                string dupeString = targetString;
                list.Add(dupeString);
                targetString = string.Empty;
            } else
            {
                targetString += stringToParse[i];
            }
        }
        list.Add(targetString);
        return list;
    }

}
